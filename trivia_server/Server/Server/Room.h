#ifndef ROOM_H
#define ROOM_H

class User;

#include <vector>
#include "User.h"
#include "Protocol.h"
#include <string>

using namespace std;

class Room
{
public:
	Room(int id, User* admin, string name, int maxUsers, int questionNo, int questionTime);

	bool joinRoom(User* user);
	void leaveRoom(User* user);
	int closeRoom(User* user);

	vector<User*> getUsers();
	string getUsersListMessage();
	int getQuestionsNo();
	int getId();
	string getName();


private:
	string getUsersAsString(vector<User*> UserList, User* excludeUser);
	void sendMessage(User*, string);
	void sendMessage(string);

	vector<User*> _users;
	User* _admin;
	int _maxUsers;
	int _questionTime;
	int _questionNo;
	string _name;
	int _id;
};

#endif