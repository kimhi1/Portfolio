#ifndef QUESTION_H
#define QUESTION_H

#include <string>
#include <stdlib.h>
#include <time.h>

using namespace std;

class Question
{
public:
	Question(int id, string question, string correctAnswer, string answer2, string answer3, string answer4);

	int getId();
	string getQuestion();
	string* getAnswers();
	int getCorrectAnswerIndex();
private:
	string _question;
	string _answers[4];
	int _id;
	int _correctAnswerIndex;
};

#endif