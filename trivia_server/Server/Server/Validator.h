#ifndef VALIDATOR_H
#define VALIDATOR_H

#define FIRST_DIGIT '0'
#define LAST_DIGIT '9'
#define FIRST_UPPER 'A'
#define LAST_UPPER 'Z'
#define FIRST_LOWER 'a'
#define LAST_LOWER 'z'

#include <string>

using namespace std;

class Validator
{
public:
	static bool isPasswordValid(string pass);
	static bool isUsernameValid(string name);
private:
	static bool containDigitUpperLower(string str);
};

#endif