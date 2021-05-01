#include "Validator.h"

// check if the password is valid
bool Validator::isPasswordValid(string pass)
{
	bool b1 = pass.length() >= 4;	// at least for chars
	bool b2 = pass.find(' ') == string::npos;	// no backspaces
	bool b3 = containDigitUpperLower(pass);	// contains digit, uppercase letter, lowercase letter
	return b1 && b2 && b3;
}

// check if username is valid
bool Validator::isUsernameValid(string name)
{
	// first char is a letter (also check that the length is not 0)
	bool b1 = (name.length() > 0) &&
		(name[0] >= FIRST_LOWER && name[0] <= LAST_LOWER) || (name[0] >= FIRST_UPPER && name[0] <= LAST_UPPER);
	bool b2 = name.find(' ') == string::npos;	// no backspaces
	return b1 && b2;
}

// true if string contain uppercase letter, lowercase letter and a digit
bool Validator::containDigitUpperLower(string str)
{
	bool dig = false;
	bool upper = false;
	bool lower = false;
	int i = 0;
	char ch;

	for (i = 0; i < str.length(); i++)
	{
		ch = str[i];
		if (ch >= FIRST_DIGIT && ch <= LAST_DIGIT)
		{
			dig = true;
		}
		else if (ch >= FIRST_LOWER && ch <= LAST_LOWER)
		{
			lower = true;
		}
		else if (ch >= FIRST_UPPER && ch <= LAST_UPPER)
		{
			upper = true;
		}
	}

	return lower && upper && dig;
}
