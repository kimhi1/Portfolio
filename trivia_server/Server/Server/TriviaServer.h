#ifndef TRIVIA_SERVER_H
#define TRIVIA_SERVER_H


#include <string>
#include <WinSock2.h>
#include <Windows.h>
#include "User.h"
#include "Room.h"
#include "DataBase.h"
#include "RecievedMessage.h"
#include "Validator.h"
#include <map>
#include <thread>
#include <iostream>
#include <chrono>
#include <mutex>
#include <condition_variable>
#include <queue>

#define PORT 8820

using namespace std;

class TriviaServer
{
public:
	TriviaServer();
	~TriviaServer();

	void serve();

private:
	void bindAndListen();// V
	void accept();// V
	void clientHandler(SOCKET socket);// V
	void safeDeleteUser(RecievedMessage* message); // V

	User* handleSignin(RecievedMessage* message); // V
	bool handleSignup(RecievedMessage* message); 
	void handleSignout(RecievedMessage* message); // V

	void handleLeaveGame(RecievedMessage* message);
	void handleStartGame(RecievedMessage* message);
	void handlePlayerAnswer(RecievedMessage* message);

	bool handleCreateRoom(RecievedMessage* message); // V
	bool handleCloseRoom(RecievedMessage* message); // V
	bool handleJoinRoom(RecievedMessage* message); // V
	bool handleLeaveRoom(RecievedMessage* message); // V
	void handleGetUsersInRoom(RecievedMessage* message); //V
	void handleGetRooms(RecievedMessage* message); // V

	void handleGetBestScores(RecievedMessage* message);
	void handleGetPersonalStatus(RecievedMessage* message);

	void handleRecievedMessages();	// V
	void handleMessage(RecievedMessage* message);	// V
	void addRecievedMessage(RecievedMessage* message);	// V
	RecievedMessage* buildRecieveMessage(SOCKET socket, int msgCode);	//V

	User* getUserByName(string name); // V
	User* getUserBySocket(SOCKET sock); // V
	Room* getRoomById(int id); // V


	SOCKET _socket;
	map<SOCKET, User*> _connectedUsers;
	DataBase _db;
	map<int, Room*> _roomsList;
	mutex _mtxRecievedMessages;
	condition_variable _queCond;
	queue<RecievedMessage*> _queRcvMessages;
	static int _roomIdSequence;

};

#endif
