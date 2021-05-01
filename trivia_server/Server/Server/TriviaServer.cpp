#include "TriviaServer.h"

#define BINDING "Server is binding"
#define READY "SERVER IS READY TO ACCEPT CLIENT"
#define CLIENT_DETECTED "Detected a client"
#define RECEIVED_CODE "Recieved code: "
#define GOT_SIGN_IN "GOT SIGN IN MESSAGE "
#define SIGN_UP "SIGN UP"
#define SIGN_OUT "SIGN OUT: name: "
#define GAME_START "GAME STARTING, SENDING FIRST QUESTION"
#define ROOM_CREATE_SUCCESS "Room created successfully"
#define ROOM_REMOVED "Room removed "
#define ROOM_FOUND "Found the room "
#define BEST_SCORE_NONE "00000000"
#define PERSONAL_STATUS_NONE "0000"
#define EXIT_REQUEST "Exit request"
#define CLOSING_SOCKET "closing socket"
#define CLIENT_EXCEPTION_CAUGHT "Caught exception with client, sending exit message"
#define DESTRUCTOR_ERROR "Error in destructor"
#define DELETE_USER_ERR "Error deleting a user"

int TriviaServer::_roomIdSequence = 0;

// create a socket
TriviaServer::TriviaServer()
{
	string err;
	this->_socket = ::socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);

	if (_socket == INVALID_SOCKET)
	{
		throw std::exception(__FUNCTION__ " - socket");
	}
		
}


// delete all the rooms, users, and socket
TriviaServer::~TriviaServer()
{
	map<int, Room*>::iterator roomIt;
	map<SOCKET, User*>::iterator userIt;
	try
	{
		// delete all the rooms
		for (roomIt = _roomsList.begin(); roomIt != _roomsList.end(); ++roomIt)
		{
			delete roomIt->second;
		}
		_roomsList.clear();

		// delete all connected users
		for (userIt = _connectedUsers.begin(); userIt != _connectedUsers.end(); ++userIt)
		{
			delete userIt->second->getGame();
			delete userIt->second;
		}
		_connectedUsers.clear();

		// close socket
		::closesocket(_socket);

	}
	catch (...) 
	{
		cout << DESTRUCTOR_ERROR << endl;
	}
}

// waiting for connections, creates thread for each client, create thread for handling messages
void TriviaServer::serve()
{
	cout << BINDING << endl;
	bindAndListen();

	// create thread for handling messages
	thread t(&TriviaServer::handleRecievedMessages, this);
	t.detach();

	cout << READY << endl;

	while (true)
	{
		accept();
	}
}

void TriviaServer::bindAndListen()
{
	struct sockaddr_in sa = { 0 };

	sa.sin_port = htons(PORT); // port that server will listen to
	sa.sin_family = AF_INET;   // must be AF_INET
	sa.sin_addr.s_addr = INADDR_ANY;    // when there are few ip's for the machine. We will use always "INADDR_ANY"

	// again stepping out to the global namespace
	// Connects between the socket and the configuration (port and etc..)
	if (::bind(_socket, (struct sockaddr*)&sa, sizeof(sa)) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - bind");

	// Start listening for incoming requests of clients
	if (::listen(_socket, SOMAXCONN) == SOCKET_ERROR)
		throw std::exception(__FUNCTION__ " - listen");
}

// accepting new clients and creating thread for each one
void TriviaServer::accept()
{
	// this accepts the client and create a specific socket from server to this client
	SOCKET client_socket = ::accept(_socket, NULL, NULL);

	if (client_socket == INVALID_SOCKET)
	{
		throw std::exception(__FUNCTION__);
	}

	cout << CLIENT_DETECTED << endl;

	// Create new thread for client
	thread clientThread(&TriviaServer::clientHandler, this, client_socket);
	clientThread.detach();
}

/*
input:
	socket of a client
output:
	function gets message from client, while the messages are not exit Message:
	then push them into queue, and wait for answer
*/
void TriviaServer::clientHandler(SOCKET socket)
{
	int messageCode;
	RecievedMessage* toPush = NULL;

	try
	{
		messageCode = Helper::getMessageTypeCode(socket);

		// while client is not exiting
		while (messageCode != EXT_REQ && messageCode != 0)
		{
			cout << RECEIVED_CODE << messageCode << endl;
			// get the object we shall push to queue
			toPush = buildRecieveMessage(socket, messageCode);
			// push to queue
			addRecievedMessage(toPush);
			// get message code again
			messageCode = Helper::getMessageTypeCode(socket);
		}
		// end the connection
		toPush = buildRecieveMessage(socket, EXT_REQ);
		addRecievedMessage(toPush);
	}
	catch (exception e)	// if exception occured, end the connection and close thread
	{
		// end the connection
		cout << CLIENT_EXCEPTION_CAUGHT << endl;
		toPush = buildRecieveMessage(socket, EXT_REQ);
		addRecievedMessage(toPush);
	}
}

void TriviaServer::safeDeleteUser(RecievedMessage* message)
{
	handleSignout(message);

	// close socket of user
	try
	{
		::closesocket(message->getSock());
	}
	catch (exception e)
	{
		cout << DELETE_USER_ERR << endl;
	}
}

User* TriviaServer::handleSignin(RecievedMessage* message)
{
	User* user = NULL;
	string name, pass;
	name = message->getValues()[0];
	pass = message->getValues()[1];

	cout << GOT_SIGN_IN << endl;

	if (_db.isUserAndPassMatch(name, pass))
	{
		if (getUserByName(name) == NULL)
		{
			// create new user
			user = new User(name, message->getSock());
			// add to user list
			_connectedUsers.insert(pair<SOCKET, User*>(message->getSock(), user));
			// send message - success...
			user->send(SIGN_IN_SUCESS);
		}
		else
		{
			// error - the user is already signed in
			Helper::sendData(message->getSock(), SIGN_IN_ALREADY_CONNECTED);
		}
	}
	else
	{
		// error - name or pass are not correct
		Helper::sendData(message->getSock(), SIGN_IN_WRONG_DETAILS);
	}

	return user;
}

bool TriviaServer::handleSignup(RecievedMessage* message)
{
	string username, password, email;
	bool ret = false;
	username = message->getValues()[0];
	password = message->getValues()[1];
	email = message->getValues()[2];

	cout << SIGN_UP << endl;

	if (!Validator::isPasswordValid(password))	// if pass not valid
	{
		Helper::sendData(message->getSock(),SIGN_UP_PASS_ILLEGAL);
	}
	else if (!Validator::isUsernameValid(username)) // if username not valid
	{
		Helper::sendData(message->getSock(), SIGN_UP_USERNAME_ILLEGAL);
	}
	else if (_db.isUserExists(username))	// if there is already such a user
	{
		Helper::sendData(message->getSock(), SIGN_UP_USERNAME_EXISTS);
	}
	else
	{
		if (_db.addNewUser(username, password, email))
		{
			// added succesfully
			Helper::sendData(message->getSock(), SIGN_UP_SUCCESS);
			ret = true;
		}
		else
		{
			// problem with adding to database
			Helper::sendData(message->getSock(), SIGN_UP_OTHER);
		}
	}

	return ret;
}

// called once a user wish to sign out
void TriviaServer::handleSignout(RecievedMessage* message)
{
	User* user = getUserBySocket(message->getSock());

	if (user != NULL)
	{
		cout << SIGN_OUT << user->getUserName() << endl;
		handleCloseRoom(message);
		handleLeaveRoom(message);
		handleLeaveGame(message);
		_connectedUsers.erase(_connectedUsers.find(message->getSock()));
	}

}

// when user exists
void TriviaServer::handleLeaveGame(RecievedMessage* message)
{
	User* user = getUserBySocket(message->getSock());
	Game* game = user->getGame();
	if (!user->leaveGame())	// if game is not active anymore, delete the game
	{
		delete game;
	}
}

void TriviaServer::handleStartGame(RecievedMessage* message)
{
	Game* game = NULL;
	Room* room = NULL;
	User* user = getUserBySocket(message->getSock());
	
	if (user != NULL)
	{
		try
		{
			room = user->getRoom();
			game = new Game(room->getId(), room->getUsers(), room->getQuestionsNo(), _db);
			_roomsList.erase(_roomsList.find(room->getId()));	// erase the current room.
			cout << GAME_START << endl;
			game->sendFirstQuestion();
		}
		catch (exception e)
		{
			user->send(QUESTION_DETAILS_ERR);
		}
	}
	
}

// handling answer from a player
void TriviaServer::handlePlayerAnswer(RecievedMessage* message)
{
	User* user = getUserBySocket(message->getSock());
	Game* game = user->getGame();
	int answerNumber = stoi(message->getValues()[0]);
	int timeInSec = stoi(message->getValues()[1]);
	if (game != NULL)
	{
		if (!game->handleAnswerFromUser(user, answerNumber, timeInSec))
		{
			delete game;
			user->setGame(NULL); 
		}
	}
}

// creating a room, adding it to the list of rooms
bool TriviaServer::handleCreateRoom(RecievedMessage* message)
{
	User* user = getUserBySocket(message->getSock());
	bool ret = false;
	string roomName;
	int playersNumber, questionNumber, questionTimeInSec;

	if (user != NULL)
	{
		roomName = message->getValues()[0];
		playersNumber = stoi(message->getValues()[1]);
		questionNumber = stoi(message->getValues()[2]);
		questionTimeInSec = stoi(message->getValues()[3]);
		_roomIdSequence++;

		// check if there arent too many questions
		if (this->_db.initQuestions(questionNumber).size() != 0)
		{
			if (user->createRoom(_roomIdSequence, roomName, playersNumber, questionNumber, questionTimeInSec))
			{
				cout << ROOM_CREATE_SUCCESS << endl;
				_roomsList.insert(pair<int, Room*>(_roomIdSequence, user->getRoom()));
				ret = true;
			}
		}
		else
		{
			ret = false;
			user->send(to_string(CREATE_ROOM_ANS) + "1");
		}

		
	}

	return ret;
}

// closes a room, erase it from the list
bool TriviaServer::handleCloseRoom(RecievedMessage* message)
{
	User* user = getUserBySocket(message->getSock());
	Room* room = user->getRoom();
	bool ret = false;
	int id;

	if (room != NULL)
	{
		ret = true;
		id = user->closeRoom();
		if (id != -1)
		{
			_roomsList.erase(_roomsList.find(id));	// erase this specific room (find interator by id)
			cout << ROOM_REMOVED << endl;
		}
	}

	return ret;
}

bool TriviaServer::handleJoinRoom(RecievedMessage* message)
{
	User* user = getUserBySocket(message->getSock());
	Room* room = NULL;
	bool ret = false;
	int roomId;

	if (user != NULL)
	{
		roomId = stoi(message->getValues()[0]);
		room = getRoomById(roomId);
		if (room != NULL)
		{
			cout << ROOM_FOUND << endl;
			user->joinRoom(room);
			ret = true;
		}
		else
		{
			// didn't find the room, send message to user
			user->send(JOIN_ROOM_OTHER);
		}

	}

	return ret;
}
bool TriviaServer::handleLeaveRoom(RecievedMessage* message)
{
	User* user = getUserBySocket(message->getSock());
	bool ret = false;
	if (user != NULL)
	{
		if (user->getRoom() != NULL)
		{
			ret = true;
			user->leaveRoom();
		}
	}
	return ret;
}

void TriviaServer::handleGetUsersInRoom(RecievedMessage* message)
{
	User* user = getUserBySocket(message->getSock());
	Room* room = NULL;
	int roomId = stoi(message->getValues()[0]);

	if (user != NULL)
	{
		
		room = getRoomById(roomId);
		if (room != NULL)
		{
			user->send(room->getUsersListMessage());
		}
		else
		{
			//didn't find the room
			user->send(ROOM_USERS_ERR);
		}
	}

}

void TriviaServer::handleGetRooms(RecievedMessage* message)
{
	User* user = getUserBySocket(message->getSock());
	string toSend = to_string(EXISTING_ROOMS_ANS);					// add protcol start
	toSend += Helper::getPaddedNumber(_roomsList.size(), 4);	// add number of rooms( 4 bytes in length)
	map<int, Room*>::iterator it;

	// iterate through rooms, append them to the message according to protocol
	for (it = _roomsList.begin(); it != _roomsList.end(); ++it)
	{
		toSend += Helper::getPaddedNumber(it->second->getId(), 4);	// 4 bytes in length- ID
		toSend += Helper::getPaddedNumber(it->second->getName().length() , 2);	//name length (in 2 bytes)
		toSend += it->second->getName();	// add the name
	}
	user->send(toSend);	// send list of rooms to user
}


void TriviaServer::handleGetBestScores(RecievedMessage* message)
{
	User* user = getUserBySocket(message->getSock());
	string toSend = to_string(BEST_SCORE_ANS);	// starting with 3 digits of protocol
	vector<string> bestScores = _db.getBestScores();	// ordered like this: username, score | username, score | ...
	string name, result;
	int i = 0;
	for (i = 0; i < 6; i+=2)	// send the 3 top users
	{
		if (i < bestScores.size())
		{
			name = bestScores[i];
			result = bestScores[i + 1];
			toSend += (Helper::getPaddedNumber(name.length(), 2) + name + result);
		}
		else
		{
			toSend += BEST_SCORE_NONE;	// if there are less than 3 users, fill with 8 zero s (2 - name size, 6 -result)
		}
	}
	user->send(toSend);
}

void TriviaServer::handleGetPersonalStatus(RecievedMessage* message)
{
	User* user = getUserBySocket(message->getSock());
	string toSend = to_string(SELF_STATUS_ANS);	// starting with 3 digits of protocol
	vector<string> personalStatus = _db.getPersonalStatus(user->getUserName());

	if (personalStatus.size() > 3)	// if the user has personal status (and everything is not 0)
	{
		toSend += personalStatus[0];
		toSend += personalStatus[1];
		toSend += personalStatus[2];
		toSend += personalStatus[3];
	}
	else
	{
		// the user don't have personal status, all of the the details are 0 right now
		toSend += PERSONAL_STATUS_NONE;	// fill all 4 fields with 0
	}

	user->send(toSend);

}

// handling messages pushed to queue
void TriviaServer::handleRecievedMessages()
{
	std::unique_lock<mutex> locker(_mtxRecievedMessages, std::defer_lock);
	RecievedMessage* message = NULL;
	while (true)
	{
		// wait for message to be pushed, get the message
		locker.lock();
		_queCond.wait(locker);
		message = _queRcvMessages.front();
		_queRcvMessages.pop();
		locker.unlock();

		// handle the message
		message->setUser(getUserBySocket(message->getSock()));	// init user by searching for his socket
		handleMessage(message);	// call the right handler function according to message
	}
}

// call the right handler function according to message
void TriviaServer::handleMessage(RecievedMessage* message)
{
	switch (message->getMessageCode())
	{
	case SIGN_IN_REQ:  
		handleSignin(message);
		break;
	case SIGN_OUT_REQ:
		handleSignout(message);
		break;
	case SIGN_UP_REQ:
		handleSignup(message);
		break;
	case EXISTING_ROOMS_REQ:
		handleGetRooms(message);
		break;
	case ROOM_USERS_REQ:
		handleGetUsersInRoom(message);
		break;
	case JOIN_ROOM_REQ:
		handleJoinRoom(message);
		break;
	case LEAVE_ROOM_REQ:
		handleLeaveRoom(message);
		break;
	case CREATE_ROOM_REQ:
		handleCreateRoom(message);
		break;
	case CLOSE_ROOM_REQ:
		handleCloseRoom(message);
		break;
	case START_GAME_REQ:
		handleStartGame(message);
		break;
	case USER_CHOICE_REQ:
		handlePlayerAnswer(message);
		break;
	case END_GAME_REQ:
		handleLeaveGame(message);
		break;
	case BEST_SCORE_REQ:
		handleGetBestScores(message);
		break;
	case SELF_STATUS_REQ:
		handleGetPersonalStatus(message);
		break;
	case EXT_REQ:
		cout << EXIT_REQUEST << endl;
		handleSignout(message);
		cout << CLOSING_SOCKET << endl;
		::closesocket(message->getSock());
		break;
	}
}

void TriviaServer::addRecievedMessage(RecievedMessage* message)
{
	_mtxRecievedMessages.lock();		// lock mutex
	_queRcvMessages.push(message);		// push message
	_mtxRecievedMessages.unlock();		// onlock mutex
	_queCond.notify_one();				// notify message handler thread that message was received
}


// Build ReceivedMessage object according to the message code. function makes sure to push the parameters to the vector inside the object
RecievedMessage* TriviaServer::buildRecieveMessage(SOCKET socket, int msgCode)
{
	RecievedMessage* message = NULL;
	vector<string> params;
	int n;

	// if there are parameters, init them according to the protocol (each msg has its own params)
	switch (msgCode)
	{
	case SIGN_IN_REQ:
		n = Helper::getIntPartFromSocket(socket, 2);
		params.push_back(Helper::getStringPartFromSocket(socket, n));
		n = Helper::getIntPartFromSocket(socket, 2);
		params.push_back(Helper::getStringPartFromSocket(socket, n));
		break;
	case SIGN_UP_REQ:
		n = Helper::getIntPartFromSocket(socket, 2);
		params.push_back(Helper::getStringPartFromSocket(socket, n));
		n = Helper::getIntPartFromSocket(socket, 2);
		params.push_back(Helper::getStringPartFromSocket(socket, n));
		n = Helper::getIntPartFromSocket(socket, 2);
		params.push_back(Helper::getStringPartFromSocket(socket, n));
		break;
	case ROOM_USERS_REQ:
		params.push_back(Helper::getStringPartFromSocket(socket, 4));
		break;
	case JOIN_ROOM_REQ:
		params.push_back(Helper::getStringPartFromSocket(socket, 4));
		break;
	case CREATE_ROOM_REQ:
		n = Helper::getIntPartFromSocket(socket, 2);
		params.push_back(Helper::getStringPartFromSocket(socket, n));
		params.push_back(Helper::getStringPartFromSocket(socket, 1));
		params.push_back(Helper::getStringPartFromSocket(socket, 2));
		params.push_back(Helper::getStringPartFromSocket(socket, 2));
		break;
	case USER_CHOICE_REQ:
		params.push_back(Helper::getStringPartFromSocket(socket, 1));
		params.push_back(Helper::getStringPartFromSocket(socket, 2));
		break;
	default:
		message = new RecievedMessage(socket, msgCode);
	}
	if (message == NULL)
	{
		message = new RecievedMessage(socket, msgCode, params);
	}

	return message;
}

// get user by name
User* TriviaServer::getUserByName(string name)
{
	User* ret = NULL;
	map<SOCKET, User*>::iterator it;

	for (it = _connectedUsers.begin(); it != _connectedUsers.end(); ++it)
	{
		if (it->second->getUserName() == name)
		{
			ret = it->second;
		}
	}

	return ret;
}

// search user by socket
User* TriviaServer::getUserBySocket(SOCKET sock)
{
	User* ret = NULL;
	map<SOCKET, User*>::iterator it = _connectedUsers.find(sock);
	if (it != _connectedUsers.end())
	{
		ret = it->second;
	}
	return ret;
}

// searches for room by id
Room* TriviaServer::getRoomById(int id)
{
	std::map<int, Room*>::iterator it = _roomsList.find(id);
	Room* ret = NULL;

	if (it != _roomsList.end())	// if found , else return null
	{
		ret = it->second;
	}

	return ret;
}
