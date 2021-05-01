#ifndef GAME_H
#define GAME_H

class User;

#include <string>
#include <vector>
#include <map>
#include "User.h"
#include "DataBase.h"
#include "Question.h"
#include "Protocol.h"

using namespace std;

#define OVER_TINE 5
#define CORRECT_ANS "1"
#define UNCORRECT_ANS "0"
#define OVER_TIME_ANS "5"

class Game
{
public:
	Game(int, const vector<User*>&, int, DataBase&);
	~Game();

	void sendFirstQuestion();
	void handleFinishGame();
	bool handleNextTurn();
	bool handleAnswerFromUser(User*, int, int);
	bool leaveGame(User*);
	int getID();

private:
	bool insertGameToDB();
	void initQuestionsFromDB();
	void sendQuestionsToAllUsers();

	vector<Question*> _questions;
	vector<User*> _players;
	int _qutestions_no;
	int _currQuestionIndex;
	DataBase& _db;
	map<string, int> _results;
	int _currentTurnAnswers;
	int _id;
};

#endif