#include "Room.h"

#define CLOSE_ROOM_PROMPT "Checking if can close the room..."

Room::Room(int id, User* admin, string name, int maxUsers, int questionNo, int questionTime)
{
	this->_id = id;
	this->_admin = admin;
	this->_name = name;
	this->_questionNo = questionNo;
	this->_questionTime = questionTime;
	this->_maxUsers = maxUsers;

	this->_users.push_back(admin);
}

vector<User*> Room::getUsers()
{
	return this->_users;
}

int Room::getQuestionsNo()
{
	return this->_questionNo;
}

int Room::getId()
{
	return this->_id;
}

string Room::getName()
{
	return this->_name;
}

string Room::getUsersAsString(vector<User*> UserList, User* excludeUser)
{
	unsigned i = 0;
	string userString;

	for (i = 0; i < UserList.size(); i++)
	{
		if (UserList[i] != excludeUser)
		{
			userString = userString + UserList[i]->getUserName() + "##";
		}
	}

	return userString;
}

string Room::getUsersListMessage()
{
	unsigned i = 0;
	string userString = to_string(ROOM_USERS_ANS) + to_string(this->_users.size());

	for (i = 0; i < this->_users.size(); i++)
	{
		userString = userString + Helper::getPaddedNumber(_users[i]->getUserName().length(), 2) + _users[i]->getUserName();
	}

	return userString;
}

void Room::sendMessage(User* excludeUser, string message)
{
	unsigned i = 0;

	try
	{
		for (i = 0; i < this->_users.size(); i++)
		{
			this->_users[i] != excludeUser ? this->_users[i]->send(message) : 0;
		}
	}
	catch (...) {}
}

void Room::sendMessage(string message)
{
	this->sendMessage(NULL, message);
}

// join user to the room
bool Room::joinRoom(User* user)
{
	if (this->_users.size() < (unsigned)_maxUsers)
	{
		this->_users.push_back(user); 
		
		user->send(to_string(JOIN_ROOM_ANS) + "0" + Helper::getPaddedNumber(_questionNo, 2) + Helper::getPaddedNumber(_questionTime, 2));
		this->sendMessage(this->getUsersListMessage());
		return true;
	}
	else
	{
		user->send(to_string(JOIN_ROOM_ANS) + "1");
	}

	return false;
}

// user leave the room
void Room::leaveRoom(User* user)
{
	vector<User*>::iterator it = this->_users.begin();

	while (*it != user && it != this->_users.end())
	{
		it++;
	}
		
	this->_users.erase(it);
	user->send(to_string(LEAVE_ROOM_ANS) + "0");
	this->sendMessage(this->getUsersListMessage());
}

int Room::closeRoom(User* user)
{
	unsigned i = 0;

	cout << CLOSE_ROOM_PROMPT << endl;

	if (user->getUserName() == this->_admin->getUserName())
	{
		this->sendMessage(to_string(CLOSE_ROOM_ANS));

		for (i = 0; i < this->_users.size(); i++)
		{
			this->_users[i] != this->_admin ? this->_users[i]->clearRoom() : 0;
		}

		return this->_id;
	}
	return -1;
}