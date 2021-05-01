#include "DataBase.h"

#define DATABASE_ERROR "Database Error, coundn't open database"
#define GET_ID_QUERY "SELECT last_insert_rowid();"

// ctor - open database
DataBase::DataBase()
{
	char* zErrMsg = 0;
	bool flag = true;

	// connection to the database
	int rc = sqlite3_open(DB_PATH, &_db);

	// if can't open database, throw exception
	if (rc)
	{
		sqlite3_close(_db);
		throw exception(ERROR_DETAILS);
	}
}

DataBase::~DataBase()
{
	sqlite3_close(_db);
}

// check if number of users with username specified is more than 0
bool DataBase::isUserExists(string username)
{
	int rc;
	char *zErrMsg = 0;
	bool flag = true;
	bool ret = false;
	int ans[1] = { 0 };

	string query = "select username from ";
	query += USERS_TABLE;
	query += " where username='" + username + "';";	// select the username from users table
	
	rc = sqlite3_exec(_db, query.c_str(), this->callbackCount, ans, &zErrMsg);
	if (rc != SQLITE_OK)
	{
		cout << DATABASE_ERROR << endl;
	}
	else
	{
		if (*ans > 0)	// if the number of answers is more than 0, there is such a user !
		{
			ret = true;
		}
	}

	return ret;
}

// inserting new user to database
bool DataBase::addNewUser(string username, string password, string email)
{
	int rc;
	char *zErrMsg = 0;
	bool flag = true;
	bool ret = false;

	string query = "insert into ";
	query += USERS_TABLE;
	query += " (username, password, email, gameNo, correctNo, wrongNo, avgTime) values ('" + username + "', ";
	query += "'" + password + "', ";
	query += "'" + email + "', ";
	query += "0, 0, 0, 0);";	// gameno, correctNo, wrongNo, avgTime starting with 0...

	rc = sqlite3_exec(_db, query.c_str(), NULL, NULL, &zErrMsg);

	return true;
}

// checking if user with these details exists
bool DataBase::isUserAndPassMatch(string username, string password)
{
	int rc;
	char *zErrMsg = 0;
	bool flag = true;
	bool ret = false;
	int ans[1] = { 0 };

	string query = "select username from ";
	query += USERS_TABLE;
	query += " where username='" + username + "' and password='" + password + "';";
	rc = sqlite3_exec(_db, query.c_str(), this->callbackCount, ans, &zErrMsg);	// we count how many users
	if (rc != SQLITE_OK)
	{
		cout << DATABASE_ERROR << endl;
	}
	else
	{
		if (*ans > 0)	// if the number of answers is more than 0, there is such a user !
		{
			ret = true;
		}
	}

	return ret;
}

vector<Question*> DataBase::initQuestions(int questionsNo)
{
	vector<Question*> v;
	vector<Question*> callAns;
	int rc, r, i;
	char *zErrMsg = 0;
	bool flag = true;

	string query = "select * from ";
	query += QUESTIONS_TABLE;
	query += " ;";

	rc = sqlite3_exec(_db, query.c_str(), this->callbackQuestions, &callAns, &zErrMsg);

	// handle situation where there are not enough questions - just leave the vector empty
	if (callAns.size() >= questionsNo)
	{
		// note, random seed already initialized !
		// push random values to v from callAns
		for (i = 0; i < questionsNo; i++)
		{
			r = rand() % (callAns.size());	// get random number (represents index to take value from)
			v.push_back(callAns[r]);	// push the r'th element from src vector to dst vector
			callAns.erase(callAns.begin() + r);	// erase the r'th element in the vector, now vector's size is smaller by 1
		}
	}

	// free memory
	for (i = 0; i < callAns.size(); i++)
	{
		delete callAns[i];	// delete each redundant question allocated in callback
		callAns[i] = NULL;
	}

	
	
	return v;
}

int DataBase::insertNewGame()
{
	int rc;
	char *zErrMsg = 0;
	bool flag = true;
	int ans[1] = { 0 };
	int ret;

	// inserting game
	string query = "insert into t_games (status, start_time) values (0, NOW, NULL);";
	rc = sqlite3_exec(_db, query.c_str(), NULL, NULL, &zErrMsg);

	// getting the ID
	query = GET_ID_QUERY;
	rc = sqlite3_exec(_db, query.c_str(), callbackValue, ans, &zErrMsg);

	ret = ans[0];

	return ret;
}

bool DataBase::updateGameStatus(int id)
{
	int rc;
	string query = "update ";
	char *zErrMsg = 0;
	query += GAMES_TABLE;
	query += " set status=1, end_time=NOW where game_id=" + to_string(id) + ";";
	rc = sqlite3_exec(_db, query.c_str(), NULL, NULL, &zErrMsg);
	return rc == SQLITE_OK;
}

// handling adding answer to a player in database
bool DataBase::addAnswerToPlayer(int gameId, string username, int questionId, string answer, bool isCorrect, int answerTime)
{
	int rc;
	char *zErrMsg = 0;
	string correct = "0";
	int ans[1] = { 0 };
	float ans2[1] = { 0 };
	int wrongNum, correctNum;
	float avgTime;
	int val1;
	float val2;

	if (isCorrect)
	{
		correct = "1";
	}

	// insert into players answers table
	string query = "insert into ";
	query += PLAYERS_ANSWERS_TABLE;
	query += " (game_id, username, question_id, player_answer, is_correct, answer_time) values(";
	query += to_string(gameId) + ", '" + username + "', " + to_string(questionId) + ", '" + answer + "',";
	query += correct + " , " + to_string(answerTime) + ");";
	rc = sqlite3_exec(_db, query.c_str(), NULL, NULL, &zErrMsg);

	// change stats in users table
	// ----- change correctNo, wrongNo -------
	// get curr values
	query = "select correctNo from ";
	query += USERS_TABLE;
	query += " where username='" + username + "';";
	sqlite3_exec(_db, query.c_str(), callbackValue, ans, &zErrMsg);
	correctNum = ans[0];
	query = "select wrongNo from ";
	query += USERS_TABLE;
	query += " where username='" + username + "';";
	sqlite3_exec(_db, query.c_str(), callbackValue, ans, &zErrMsg);
	wrongNum = ans[0];
	// replace it
	if (isCorrect)
	{
		correct = "correctNo";
		val1 = correctNum + 1;
	}
	else
	{
		correct = "wrongNo";
		val1 = wrongNum + 1;
	}
	query = "update ";
	query += USERS_TABLE;
	query += " set " + correct + "=" + to_string(val1) + " where username='" + username + "';";
	sqlite3_exec(_db, query.c_str(), NULL, NULL, &zErrMsg);

	// ----- change avgTime -----
	// get curr value
	query = "select avgTime from ";
	query += USERS_TABLE;
	query += " where username='" + username + "';";
	sqlite3_exec(_db, query.c_str(), callbackFloatValue, ans2, &zErrMsg);
	avgTime = ans2[0];
	val2 = (avgTime * (correctNum + wrongNum) + answerTime) / (correctNum + wrongNum + 1);	// calculate new average time !


	// set value
	query = "update "; 
	query += USERS_TABLE;
	query += " set avgTime=" + to_string(val2) + " where username='" + username + "';";
	sqlite3_exec(_db, query.c_str(), NULL, NULL, &zErrMsg);

	return rc == SQLITE_OK;
}

vector<string> DataBase::getBestScores()
{
	char *zErrMsg = 0;
	int i = 0;
	vector<pair<string, int>> v;
	vector<string> finalAns;
	string query;
	// push three values which will be replaced (unless there are less than 3 players in our DB)
	for (i = 0; i < BEST_SCORE_LEN; i++)
	{
		v.push_back(make_pair("", -1));
		v.push_back(make_pair("", -1));
		v.push_back(make_pair("", -1));
	}
	
	// send our query
	query = "select username, correctNo from ";
	query += USERS_TABLE;
	query += ";";
	cout << query << endl;
	sqlite3_exec(_db, query.c_str(), callbackBestScores, &v, &zErrMsg);

	// convert all the data into a <string> type vector (final answer)
	for (i = 0; i < BEST_SCORE_LEN; i++)
	{
		if (v[i].second > -1)	// if there is an i'th user
		{
			finalAns.push_back(v[i].first);
			finalAns.push_back(Helper::getPaddedNumber(v[i].second, 6));
		}
	}

	return finalAns;
}

// return the personal status of a username
vector<string> DataBase::getPersonalStatus(string username)
{
	char *zErrMsg = 0;
	vector<string> v;
	string query = "select gameNo, correctNo, wrongNo, avgTime from ";
	query += USERS_TABLE;
	query += " where username = '" + username + "';";
	sqlite3_exec(_db, query.c_str(), callbackPersonalStatus, &v, &zErrMsg);

	return v;
}

// count how many times this callback is called, used to count rows
int DataBase::callbackCount(void* notUsed, int argc, char** argv, char** azCol)
{
	int* n = (int*)notUsed;
	(*n)++;
	return 0;
}

// returns all the questions (modifie the notUsed argument)
int DataBase::callbackQuestions(void* notUsed, int argc, char** argv, char** azCol)
{
	vector<Question*>*  res = (vector<Question*>*)notUsed;

	Question* currQuest;

	currQuest = new Question(atoi(argv[0]), argv[1], argv[2], argv[3], argv[4], argv[5]);

	res->push_back(currQuest);

	return 0;
}

// function increment the "gameNo" field in the users table
void DataBase::incrementUserGames(string username)
{
	int rc;
	char *zErrMsg = 0;
	int ans[1] = { 0 };
	int value;

	// get current value
	string query = "select gameNo from ";
	query += USERS_TABLE;
	query += " where username = '" + username + "';";
	// get value + 1
	rc = sqlite3_exec(_db, query.c_str(), callbackValue, ans, &zErrMsg);
	value = ans[0] + 1;
	// update in database the new value
	query = "update ";
	query += USERS_TABLE;
	query += " set gameNo=" + to_string(value) + " where username='" + username + "';";
	rc = sqlite3_exec(_db, query.c_str(), NULL, NULL, &zErrMsg);
}


int DataBase::callbackBestScores(void* notUsed, int argc, char** argv, char** azCol)
{
	// in the query, we select "username", "correctNo" fields... keep track of top three scorers.
	string username = argv[0];
	int val = stoi(argv[1]);
	vector<pair<string, int>>* res = (vector<pair<string, int>>*) notUsed;;
	int temp;
	string stemp;


	// place the new username in the top 3 if he should be there
	if (val > (*res)[0].second)
	{
		(*res)[2].second = (*res)[1].second;
		(*res)[2].first = (*res)[1].first;
		(*res)[1].second = (*res)[0].second;
		(*res)[1].first = (*res)[0].first;
		(*res)[0].second = val;
		(*res)[0].first = username;
	}
	else if (val > (*res)[1].second)
	{
		(*res)[2].second = (*res)[1].second;
		(*res)[2].first = (*res)[1].first;
		(*res)[1].second = val;
		(*res)[1].first = username;
	}
	else if (val > (*res)[2].second)
	{
		(*res)[2].second = val;
		(*res)[2].first = username;
	}

	return 0;
}

int DataBase::callbackPersonalStatus(void* notUsed, int argc, char** argv, char** azCol)
{
	vector <string>* res = (vector <string>*)notUsed;
	float f;
	string s = "";
	int n;
	res->push_back(Helper::getPaddedNumber(stoi(argv[0]),4));	// push gameNo - 4 bytes
	res->push_back(Helper::getPaddedNumber(stoi(argv[1]), 6));	// push correctNo - 6
	res->push_back(Helper::getPaddedNumber(stoi(argv[2]), 6));	// wrongNo - 6
	f = stof(argv[3]);
	n = (int)(f * 100);
	res->push_back(Helper::getPaddedNumber(n, 4));	// push average time
	res->push_back(s);	// avgTime - 4
	return 0;
}

int DataBase::callbackValue(void* notUsed, int argc, char** argv, char** azCol)
{
	int* res = (int*)notUsed;
	*res = stoi(argv[0]);
	return 0;
}

int DataBase::callbackFloatValue(void* notUsed, int argc, char** argv, char** azCol)
{
	float* res = (float*)notUsed;
	
	*res = stof(argv[0]);
	return 0;
}

