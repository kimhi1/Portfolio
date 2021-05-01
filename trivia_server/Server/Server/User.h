#ifndef USER_H
#define USER_H

class Room;
class Game;

#include <WinSock2.h>
#include <Windows.h>
#include <string>
#include "Room.h"
#include "Game.h"
#include "Helper.h"
#include "Protocol.h"

using namespace std;

class User
{
public:
	User(string, SOCKET);

	void setGame(Game*);
	void send(string);
	void clearGame();
	bool createRoom(int, string, int, int, int);
	bool joinRoom(Room*);
	void leaveRoom();
	int closeRoom();
	bool leaveGame();
	void clearRoom();

	string getUserName();
	SOCKET getSocket();
	Room* getRoom();
	Game* getGame();

private:
	string _username;
	Room* _currRoom;
	Game* _currGame;
	SOCKET _sock;
};

#endif