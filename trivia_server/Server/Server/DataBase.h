#ifndef DATABASE_H
#define DATABASE_H

#include <string>
#include <iostream>
#include <vector>
#include <unordered_map>
#include <stdlib.h>  
#include <time.h>
#include "Helper.h"
#include "Question.h"
#include "sqlite3.h"

#define DB_PATH "MyDB.db"
#define GAMES_TABLE "t_games"
#define QUESTIONS_TABLE "t_questions"
#define USERS_TABLE "t_users"
#define PLAYERS_ANSWERS_TABLE "t_players_answers"
#define ERROR_DETAILS "Can't open database"
#define BEST_SCORE_LEN 3



using namespace std;

class DataBase
{
public:
	DataBase();
	~DataBase();

	bool isUserExists(string); 
	bool addNewUser(string, string, string); 
	bool isUserAndPassMatch(string, string); 
	vector<Question*> initQuestions(int);
	int insertNewGame(); //return fail = return -1
	bool updateGameStatus(int);
	bool addAnswerToPlayer(int, string, int, string, bool, int);

	vector<string> getBestScores();
	vector<string> getPersonalStatus(string username);

	void incrementUserGames(string username);	

private:
	static int callbackCount(void*, int, char**, char**);
	static int callbackQuestions(void*, int, char**, char**);
	static int callbackBestScores(void*, int, char**, char**);
	static int callbackPersonalStatus(void*, int, char**, char**);
	static int callbackValue(void*, int, char**, char**);
	static int 	callbackFloatValue(void*, int, char**, char**);
	
	sqlite3* _db;

};

#endif