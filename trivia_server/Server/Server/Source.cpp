#include "TriviaServer.h"
#include <iostream>

#define STARTUP_FAILED "WSAStartup Failed"

#pragma comment(lib, "Ws2_32.lib")

int main()
{
	WSADATA wsa_data = {};
	if (WSAStartup(MAKEWORD(2, 2), &wsa_data) != 0)
		throw std::exception(STARTUP_FAILED);

	srand(time(NULL));	// we are going to use random...

	TriviaServer ts;
	ts.serve();

	try
	{
		WSACleanup();
	}
	catch (...) {}

	return 0;
}