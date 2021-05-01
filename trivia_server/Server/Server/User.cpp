#include "User.h"

#define ROOM_EXISTS "FAILED TO CREATE ROOM - ALREADY HAS ROOM"
#define CREATE_SUCCESS "0"
#define CREATE_FAIL "1"

User::User(string username, SOCKET sock)
{
	this->_username = username;
	this->_sock = sock;
	this->_currGame = NULL;
	this->_currRoom = NULL;
}

string User::getUserName()
{
	return this->_username;
}

SOCKET User::getSocket()
{
	return this->_sock;
}

Room* User::getRoom()
{
	return this->_currRoom;
}

Game* User::getGame()
{
	return this->_currGame;
}

void User::send(string message)
{
	Helper::sendData(this->_sock, message);
}

void User::setGame(Game* gm)
{
	this->_currGame = gm;
	this->_currRoom = NULL;
}

bool User::createRoom(int roomId, string roomName, int maxUsers, int questionsNo, int questionTime)
{
	if (this->_currRoom == NULL)
	{
		this->_currRoom = new Room(roomId, this, roomName, maxUsers, questionsNo, questionTime);
		send(to_string(CREATE_ROOM_ANS) + CREATE_SUCCESS);
		return true;
	}
	else
	{
		cout << ROOM_EXISTS << endl;
	}
	send(to_string(CREATE_ROOM_ANS) + CREATE_FAIL);
	return false;
}

bool User::joinRoom(Room* newRoom)
{
	if (this->_currRoom == NULL)
	{
		newRoom->joinRoom(this);
		this->_currRoom = newRoom;
		return true;
	}
	return false;
}

void User::leaveRoom()
{
	if (this->_currRoom != NULL)
	{
		this->_currRoom->leaveRoom(this);
		this->_currRoom = NULL;
	}
}

int User::closeRoom()
{
	int idRoom = -1;

	if (this->_currRoom != NULL)
	{
		idRoom = this->_currRoom->closeRoom(this);
		delete this->_currRoom;
		this->_currRoom = NULL;
	}
	return idRoom;
}

bool User::leaveGame()
{
	if (this->_currGame != NULL)
	{
		return this->_currGame->leaveGame(this);
	}

	return false;
}

void User::clearGame()
{
	this->_currGame = NULL;
}

void User::clearRoom()
{
	this->_currRoom = NULL;
}