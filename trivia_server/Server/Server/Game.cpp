#include "Game.h"

#define ERR_INSERT "FAIL - INSERT GAME!"
#define ERR_NUM_QUESTIONS "Error - too many questions"

Game::Game(int id, const vector<User*>& players, int questionsNo, DataBase& db) : _db(db)
{
	int i = 0;

	if (this->_db.insertNewGame() < 0)
	{
		throw(ERR_INSERT);
	}
	else
	{
		this->_questions = this->_db.initQuestions(questionsNo);
		if (this->_questions.size() == 0)	// if therea are not enough questions
		{
			throw invalid_argument(ERR_NUM_QUESTIONS);
		}
		this->_players = players;
		this->_id = id;
		this->_qutestions_no = questionsNo;
		this->_currentTurnAnswers = 0;
		this->_currQuestionIndex = 0;

		for (i = 0; i < this->_players.size(); i++)
		{
			this->_results.insert(pair<string, int>(this->_players[i]->getUserName(), NULL));
			this->_players[i]->setGame(this);
		}
	}
}

int Game::getID()
{
	return this->_id;
}

Game::~Game()
{
	int i = 0;

	if (this->_questions.empty() == false && this->_players.empty() == false)
	{
		for (i = 0; i < this->_questions.size(); i++)
		{
			delete this->_questions[i];
		}

		for (i = 0; i < this->_players.size(); i++)
		{
			delete this->_players[i];
		}
	}
}

// sending the next question to all of the users in the game
void Game::sendQuestionsToAllUsers()
{
	int i = 0;

	this->_currentTurnAnswers = 0;

	if (!this->_questions.empty())
	{
		string question = this->_questions[this->_currQuestionIndex]->getQuestion();
		string* answers = this->_questions[this->_currQuestionIndex]->getAnswers();

		string message = to_string(QUESTION_DETAILS_ANS) + 
			Helper::getPaddedNumber(question.length(),3) + question +
			Helper::getPaddedNumber(answers[0].length(), 3) + answers[0] + 
			Helper::getPaddedNumber(answers[1].length(), 3) + answers[1] + 
			Helper::getPaddedNumber(answers[2].length(), 3) + answers[2] + 
			Helper::getPaddedNumber(answers[3].length(), 3) + answers[3];

		for (i = 0; i < this->_players.size(); i++)
		{
			try
			{
				this->_players[i]->send(message);
			}
			catch (...) {}
		}
	}
}

void Game::handleFinishGame()
{
	int i = 0;
	string name, nameLen;
	string message = to_string(END_GAME_ANS) + to_string(this->_players.size());

	this->_db.updateGameStatus(this->getID());

	for (i = 0; i < this->_players.size(); i++)
	{
		name = this->_players[i]->getUserName();
		nameLen = Helper::getPaddedNumber(name.length(), 2);
		message += nameLen + name + Helper::getPaddedNumber(this->_results.find(name)->second, 2);
	}
	for (i = 0; i < this->_players.size(); i++)
	{
		try
		{
			this->_players[i]->send(message);
		}
		catch (...) {}
	}
}

void Game::sendFirstQuestion()
{
	int i = 0;

	// now, increment the "gameNo" database field of all the users in this game
	for (i = 0; i < _players.size(); i++)
	{
		_db.incrementUserGames(_players[i]->getUserName());
	}
	// start the Game !
	this->sendQuestionsToAllUsers();
}

bool Game::handleNextTurn()
{
	if (this->_players.empty())
	{
		this->handleFinishGame();
		return false;
	}
	else if (this->_currentTurnAnswers == _players.size())
	{
		if (this->_currQuestionIndex == this->_qutestions_no - 1)
		{
			this->handleFinishGame();
		}
		else
		{
			this->_currQuestionIndex++;
			this->sendQuestionsToAllUsers();
		}
	}

	return true;
}

// handling answer from a user
bool Game::handleAnswerFromUser(User* user, int answerNo, int time)
{
	this->_currentTurnAnswers++;

	int correct = this->_questions[this->_currQuestionIndex]->getCorrectAnswerIndex();
	if (answerNo != 5)
	{
		answerNo = (answerNo + 3 ) % 4;
	}

	if (correct == answerNo)
	{
		this->_results.find(user->getUserName())->second++;
		this->_db.addAnswerToPlayer(this->getID(), user->getUserName(), this->_questions[this->_currQuestionIndex]->getId()
			, this->_questions[this->_currQuestionIndex]->getAnswers()[answerNo], true, time);
		user->send(to_string(USER_CHOICE_ANS) + CORRECT_ANS); // 0 - correct answer
	}
	else if (answerNo == OVER_TINE)
	{
		this->_db.addAnswerToPlayer(this->getID(), user->getUserName(), this->_questions[this->_currQuestionIndex]->getId()
			, "", false, time);
		user->send(to_string(USER_CHOICE_ANS) + OVER_TIME_ANS); // 2 - over time
	}
	else  // wrong answer
	{
		this->_db.addAnswerToPlayer(this->getID(), user->getUserName(), this->_questions[this->_currQuestionIndex]->getId()
			, this->_questions[this->_currQuestionIndex]->getAnswers()[answerNo], false, time);
		user->send(to_string(USER_CHOICE_ANS) + UNCORRECT_ANS); // 1 - not correct answer
	}
	

	return handleNextTurn();
}

// handling user leaving the game
bool Game::leaveGame(User* user)
{
	vector<User*>::iterator playersIt;
	vector<User*>::iterator playerToErase;
	bool found = false;

	for (playersIt = this->_players.begin(); playersIt != this->_players.end(); ++playersIt)
	{
		if (user == *playersIt)
		{
			playerToErase = playersIt;
			found = true;
		}
	}
	if (found)
	{
		this->_players.erase(playerToErase);
	}

	return handleNextTurn();
}
