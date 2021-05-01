using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Game_form : Form
    {

        private const string RESULTS_STRING = "Results:\n";
        private const string SCORED_STRING = " scored: ";
        private const string GAME_END_STRING = "GAME ENDED";
        private const string CORRECT_STRING = "Correct!";
        private const string WRONG_STRING = "Wrong :(";

        private const string FIRST_ANS = "1";
        private const string SECOND_ANS = "2";
        private const string THIRD_ANS = "3";
        private const string FOURTH_ANS = "4";


        private NetworkStream _clientStream;
        private Wait_Game_form _wait_win;
        private Menu_form _mf;

        private string _ans;
        private int _count, _questionNo, _score, _questionTime;

        public Game_form()
        {
            InitializeComponent();
            _count = 1;
            _questionNo = 0;
            _score = 0;
            _ans = "1";
            _questionTime = 0;
            _wait_win = null;
            _mf = null;
            correctLabel.Visible = false;
        }

        public void setWaitWin(Wait_Game_form wf)
        {
            this._wait_win = wf;
        }

        public void setMenuWin(Menu_form mf)
        {
            this._mf = mf;
        }

        public void setUsernameLabel(string name)
        {
            usernameLabel.Text = name;
        }

        // set network stream for communication
        public void setStream(NetworkStream clientStream)
        {
            this._clientStream = clientStream;
        }

        public void startTicker()
        {
            timer.Enabled = true;
        }

        public void setRoomName(string roomName)
        {
            roomNameLabel.Text = roomName;
        }

        public void setQuestionTime(int questionTime)
        {
            timeLabel.Text = questionTime.ToString();
            _questionTime = questionTime;
            
        }

        public void setQuestionNo(int questionNo)
        {
            questionNoLabel.Text = "1/" + questionNo.ToString();
            _questionNo = questionNo;
        }

        public void NextQuestion()
        {
            // check if that's the first question, if it is and this is a joined player, load this screen
            if (_count == 1 && _wait_win != null)
            {
                _wait_win.Hide();
                _mf.Visible = false;
                this.Show();
            }

            handleNextQuestion();

            _count++;
            // notice - a message about finishing the game will arrive soon, we will listen to it
        }

        private void handleNextQuestion()
        {
            int questionLen, lenAns;

            questionLen = int.Parse(Helpers.getMessage(3, _clientStream));

            if (questionLen != int.Parse(Protocol.START_GAME_FAIL))
            {

                questionLabel.Text = Helpers.getMessage(questionLen, _clientStream);

                lenAns = int.Parse(Helpers.getMessage(3, _clientStream));
                ans1Button.Text = Helpers.getMessage(lenAns, _clientStream);

                lenAns = int.Parse(Helpers.getMessage(3, _clientStream));
                ans2Button.Text = Helpers.getMessage(lenAns, _clientStream);

                lenAns = int.Parse(Helpers.getMessage(3, _clientStream));
                ans3Button.Text = Helpers.getMessage(lenAns, _clientStream);

                lenAns = int.Parse(Helpers.getMessage(3, _clientStream));
                ans4Button.Text = Helpers.getMessage(lenAns, _clientStream);

                // also enable all of the buttons and re-initialize the timer
                enable();
            }
            else
            {
                this.Hide();
                this.Close();
            }
        }

        public void EndGame()
        {
            // when the game is finished, show all of the results and close the window
            int usersNo = int.Parse(Helpers.getMessage(1, _clientStream));
            int usernameLen, score, i;
            string username;
            string message = RESULTS_STRING;

            for(i = 0 ; i < usersNo; i++)
            {
                usernameLen = int.Parse(Helpers.getMessage(2, _clientStream));
                username = Helpers.getMessage(usernameLen, _clientStream);
                score = int.Parse(Helpers.getMessage(2, _clientStream));
                message += (username + SCORED_STRING + score + "\n");
            }

            questionNoLabel.Text = GAME_END_STRING;
            timer.Enabled = false;

            // show message to user
            MessageBox.Show(message);

            // re-initialize the fields for the next game & come back to menu
            this.Hide();    // no need to close window since used Show() method instead of showdialog()
            _count = 1;
            _questionNo = 0;
            _score = 0;
            scoreLabel.Text = "0";
            _ans = "1";
            _questionTime = 0;
            correctLabel.Visible = false;
        }

        public void ChekingAnswer()
        {
            string isCorrect = Helpers.getMessage(1, _clientStream);

            correctLabel.Visible = true;
            if(isCorrect == Protocol.USER_CHOICE_CORRECT)
            {
                _score++;
                correctLabel.Text = CORRECT_STRING;
            }
            else
            {
                correctLabel.Text = WRONG_STRING;
            }

            questionNoLabel.Text = (_count).ToString() + "/" + _questionNo;
            scoreLabel.Text = SCORED_STRING + _score.ToString();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            _count = 1;
            _questionNo = 0;
            _score = 0;
            scoreLabel.Text = "0";
            _ans = "1";
            _questionTime = 0;
            correctLabel.Visible = false;
            Helpers.sendMessage(Protocol.GAME_END_SEND, _clientStream);
            this.Hide();
            this.Close();
        }

        private void enable()
        {
            timeLabel.Text = _questionTime.ToString();
            timer.Enabled = true;
            ans1Button.Enabled = true;
            ans2Button.Enabled = true;
            ans3Button.Enabled = true;
            ans4Button.Enabled = true;
        }

        private void disableAfterClick()
        {
            timer.Enabled = false;
            ans1Button.Enabled = false;
            ans2Button.Enabled = false;
            ans3Button.Enabled = false;
            ans4Button.Enabled = false;
        }

        private void ans1Button_Click(object sender, EventArgs e)
        {
            _ans = FIRST_ANS;
            string time = timeLabel.Text.PadLeft(2, '0');

            Helpers.sendMessage(Protocol.USER_CHOICE_SEND + _ans + time, _clientStream);
            disableAfterClick();
        }

        private void ans2Button_Click(object sender, EventArgs e)
        {
            _ans = SECOND_ANS;
            string time = timeLabel.Text.PadLeft(2, '0');

            Helpers.sendMessage(Protocol.USER_CHOICE_SEND + _ans + time, _clientStream);
            disableAfterClick();
        }

        private void ans3Button_Click(object sender, EventArgs e)
        {
            _ans = THIRD_ANS;
            string time = timeLabel.Text.PadLeft(2, '0');

            Helpers.sendMessage(Protocol.USER_CHOICE_SEND + _ans + time, _clientStream);
            disableAfterClick();
        }

        private void ans4Button_Click(object sender, EventArgs e)
        {
            _ans = FOURTH_ANS;
            string time = timeLabel.Text.PadLeft(2, '0');

            Helpers.sendMessage(Protocol.USER_CHOICE_SEND + _ans + time, _clientStream);
            disableAfterClick();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int timeCurr = int.Parse(timeLabel.Text) - 1;
            timeLabel.Text = timeCurr.ToString();

            if(timeCurr == 0)
            {
                if (_count - 1 <= _questionNo)  // if we shouldn't have end already
                {
                    Helpers.sendMessage(Protocol.USER_CHOICE_SEND + Protocol.GAME_OUT_OF_TIME + "00", _clientStream);
                    timeLabel.Text = _questionTime.ToString();
                }
                else
                {
                    timer.Enabled = false;
                }
            }
            if (_count - 1 > _questionNo)
            {
                timer.Enabled = false;
            }
        }
    }
}
