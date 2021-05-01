#include "RecievedMessage.h"

RecievedMessage::RecievedMessage(SOCKET sock, int messageCode)
{
	this->_sock = sock;
	this->_messageCode = messageCode;
}

RecievedMessage::RecievedMessage(SOCKET sock, int messageCode, vector<string> values) : RecievedMessage(sock, messageCode)
{
	this->_values = values;
}

SOCKET RecievedMessage::getSock()
{
	return this->_sock;
}

User* RecievedMessage::getUser()
{
	return this->_user;
}

int RecievedMessage::getMessageCode()
{
	return this->_messageCode;
}

vector<string>& RecievedMessage::getValues()
{
	return this->_values;
}

void RecievedMessage::setUser(User* user)
{
	this->_user = user;
}
