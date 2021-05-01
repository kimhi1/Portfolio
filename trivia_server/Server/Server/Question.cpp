#include "Question.h"

Question::Question(int id, string question, string correctAnswer, string answer2, string answer3, string answer4)
{
	this->_id = id;
	this->_question = question;
	this->_correctAnswerIndex = rand() % 4;	// random number between 0 and 3
	this->_answers[this->_correctAnswerIndex] = correctAnswer;
	this->_answers[(this->_correctAnswerIndex + 1) % 4] = answer2;
	this->_answers[(this->_correctAnswerIndex + 2) % 4] = answer3;
	this->_answers[(this->_correctAnswerIndex + 3) % 4] = answer4;
}

int Question::getId()
{
	return this->_id;
}

string Question::getQuestion()
{
	return this->_question;
}

string* Question::getAnswers()
{
	return this->_answers;
}

int Question::getCorrectAnswerIndex()
{
	return this->_correctAnswerIndex;
}