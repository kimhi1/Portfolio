#ifndef RECIEVED_MESSAGE_H
#define RECIEVED_MESSAGE_H

#include <string>
#include <vector>
#include <WinSock2.h>
#include <Windows.h>
#include "User.h"

using namespace std;

class RecievedMessage
{
public:
	RecievedMessage(SOCKET, int);
	RecievedMessage(SOCKET, int, vector<string>);

	SOCKET getSock();
	User* getUser();
	int getMessageCode();
	vector<string>& getValues();

	void setUser(User*);

private:
	SOCKET _sock;
	User* _user;
	int _messageCode;
	vector<string> _values;
};

#endif