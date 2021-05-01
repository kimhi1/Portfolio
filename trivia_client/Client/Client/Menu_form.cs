using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections;
using System.Net.Sockets;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using System.Threading;

namespace Client
{
    public partial class Menu_form : Form
    {
       
        public const string CONNECTION_ERROR = "Lost connection with server";
        public const string FILE_ERROR = "Error reading the config file";
        private const string SIGN_IN = "SIGN IN";
        private const string UNEXPECTED_INPUT = "unexpected server input";
        private const string EMPTY_DETAILS = "Cannot leave empty details...";

        private const string HELLO_TEXT = "Hello, ";
        private const string WRONG_DETAILS = "Wrong details";
        private const string USER_ALREADY_CONNECTED = "Such user already connected";

        // communication
        public const int PROTOCOL_SIZE = 3;

        // config
        private string _ip;
        private int _port;
        private bool _encrypt;

        // normal settings
        private bool _connected;
        private static TcpClient _client;
        private NetworkStream _clientStream;
        private string _username;
        private bool _close;
        private bool _isWaiting;

        // forms
        Status_form StatusWin = new Status_form();
        Scores_form ScoresWin = new Scores_form();
        Create_form CreateWin = new Create_form();
        Join_form JoinWin = new Join_form();
        Sign_up_form Sign_up_Win = new Sign_up_form();
        Wait_Game_form waitWin = new Wait_Game_form();
        Game_form GameWin = new Game_form();

        public Menu_form()
        {
            InitializeComponent();
            _client = new TcpClient();
            promptLabel.Visible = false;
            _username = "";
            _clientStream = null;
            _close = false;  // will be true once we will close the program
            _connected = false;
            _isWaiting = false;
        }

        // Here, we shall start the program
        private void Menu_form_Shown(object sender, EventArgs e)
        {
            string[] data;
            // if it's the first time this form is presented
            if(!_connected)
            {
                // get config data
                data = Helpers.readConfigFile();
                if(data != null)
                {
                    _ip = data[0];
                    _port = int.Parse(data[1]);
                    _encrypt = bool.Parse(data[2]);
                    _connected = true;

                    Thread serverThread = new Thread(ServerThreadListener);

                    // wait for communication
                    serverThread.Start();   // this thread will make the main thread start the game...
                }
                else
                {
                    MessageBox.Show(FILE_ERROR);
                    this.Close();
                }
            }
        }

        // called after receiving reply about sign in
        private void signInAnswer()
        {
            string message = Helpers.getMessage(1, _clientStream);
            promptLabel.Text += SIGN_IN;
            promptLabel.Text += message;
            switch(message)
            {
                case Protocol.SIGN_IN_SUCCESS:
                    promptLabel.Visible = false;
                    // login success ! enable everything we should
                    joinRoomButton.Enabled = true;
                    bestScoresButton.Enabled = true;
                    createRoomButton.Enabled = true;
                    myStatusButton.Enabled = true;
                    // delete everything that shouldn't be
                    signinButton.Visible = false;
                    usernameTextbox.Visible = false;
                    passwordTextbox.Visible = false;
                    usernameLabel.Visible = false;
                    passwordLabel.Visible = false;
                    signupButton.Visible = false;
                    signoutButton.Visible = true;
                    // display hello user label
                    hellouserLabel.Text = HELLO_TEXT + _username;
                    hellouserLabel.Visible = true;

                    break;
                case Protocol.SIGN_IN_ERROR:
                    promptLabel.Visible = true;
                    promptLabel.Text = WRONG_DETAILS;
                    break;
                case Protocol.SIGN_IN_CONNECTED:
                    promptLabel.Visible = true;
                    promptLabel.Text = USER_ALREADY_CONNECTED;
                    break;
            }
        }

        // received message from server with data about my status
        private void myStatusAnswer( )
        {
            double avg;
            string noGames, rightAns, wrongAns, avgStr;

            string message = int.Parse(Helpers.getMessage(4, _clientStream)).ToString();
            noGames = message;

            message = int.Parse(Helpers.getMessage(6, _clientStream)).ToString();
            rightAns = message;

            message = int.Parse(Helpers.getMessage(6, _clientStream)).ToString();
            wrongAns = message;

            avg = int.Parse(Helpers.getMessage(4, _clientStream));
            avg = avg / 100;
            message = avg.ToString();
            avgStr  = message;

            this.StatusWin.setDisplay(noGames, rightAns, wrongAns, avgStr);

        }

        // received message from server about my score
        private void bestScoresAnswer( )
        {
            string[] names = new string[3];
            string[] scoers = new string[3];

            string message = Helpers.getMessage(2, _clientStream);
            int len = int.Parse(message);
            string nameOfUser = Helpers.getMessage(len, _clientStream);
            string scoreOfUser = int.Parse(Helpers.getMessage(6, _clientStream)).ToString();
            names[0] = nameOfUser;
            scoers[0] = scoreOfUser;

            message = Helpers.getMessage(2, _clientStream);
            len = int.Parse(message);
            nameOfUser = Helpers.getMessage(len, _clientStream);
            scoreOfUser = int.Parse(Helpers.getMessage(6, _clientStream)).ToString();
            names[1] = nameOfUser;
            scoers[1] = scoreOfUser;

            message = Helpers.getMessage(2, _clientStream);
            len = int.Parse(message);
            nameOfUser = Helpers.getMessage(len, _clientStream);
            scoreOfUser = int.Parse(Helpers.getMessage(6, _clientStream)).ToString();
            names[2] = nameOfUser;
            scoers[2] = scoreOfUser;

            ScoresWin.setNames(names);
            ScoresWin.setScores(scoers);
        }




        // function for thread which will listen to server
        private void ServerThreadListener()
        {
            bool run = true;
            string message = "";

            // establish communication
            try
            {
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(_ip), _port);
                _client.Connect(serverEndPoint);
                _clientStream = _client.GetStream();
                
                while (run)
                {
                    
                    // wait for message
                    byte[] bufferIn = new byte[PROTOCOL_SIZE];
                    int bytesRead = _clientStream.Read(bufferIn, 0, PROTOCOL_SIZE);

                    // set the message field to be the message we got
                    message = new ASCIIEncoding().GetString(bufferIn);

                    switch(message)
                    {
                        case Protocol.SIGN_IN_RECIEVED:
                            Invoke((MethodInvoker)delegate { signInAnswer(); });
                            break;
                        case Protocol.SIGN_UP_RECIEVED:
                            Invoke((MethodInvoker)delegate { Sign_up_Win.signUpAnswer(); });
                            break;
                        case Protocol.BEST_SCORE_ANS:
                            Invoke((MethodInvoker)delegate { bestScoresAnswer(); });
                            break;
                        case Protocol.STATUS_RECIEVED:
                            Invoke((MethodInvoker)delegate { myStatusAnswer(); });
                            break;
                        case Protocol.CREATE_ROOM_RECIEVED:
                            Invoke((MethodInvoker)delegate { _isWaiting = true; CreateWin.answer(); });
                            break;
                        case Protocol.GET_ROOMS_RECIEVED:
                            Invoke((MethodInvoker)delegate { JoinWin.roomsAnswer(); });
                            break;
                        case Protocol.GET_ROOM_USERS_RECIEVED:
                            Invoke((MethodInvoker)delegate {
                                waitWin.setStream(_clientStream);
                                if(_isWaiting)
                                {
                                    waitWin.usersAnswer();
                                }
                                else
                                {
                                    JoinWin.usersAnswer(); 
                                }
                            });
                            break;
                        case Protocol.JOIN_ROOM_RECIEVED:
                            Invoke((MethodInvoker)delegate { JoinWin.joinAnswer(); });
                            break;
                        case Protocol.LEAVE_ROOM_RECIEVED:
                            Invoke((MethodInvoker)delegate { _isWaiting = false; waitWin.leaveRoomAnswer(); });
                            break;
                        case Protocol.CLOSE_ROOM_RECIEVED:
                            Invoke((MethodInvoker)delegate { _isWaiting = false; waitWin.closeRoomAnswer(); });
                            break;
                        case Protocol.STRAT_GAME_RECIEVED:
                            Invoke((MethodInvoker)delegate { GameWin.NextQuestion(); });
                            break;
                        case Protocol.USER_CHOICE_RECIEVED:
                            Invoke((MethodInvoker)delegate { GameWin.ChekingAnswer(); });
                            break;
                        case Protocol.GAME_END_RECIEVED:
                            Invoke((MethodInvoker)delegate { GameWin.EndGame(); });
                            break;
                        default:
                            throw new Exception(UNEXPECTED_INPUT);
                    }
                    
                }

            }
            catch (Exception e)
            {
                // if the error did not occur because of closing
                if(!_close)
                {
                    Invoke((MethodInvoker)delegate { MessageBox.Show(CONNECTION_ERROR); });
                    Invoke((MethodInvoker)delegate { this.Close(); });
                }
            }
        }

        private void Menu_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            _close = true;
            // hide the window
            this.Hide();
            // notify server
            if(_clientStream != null)
            {
                try
                {
                    // send exit message by protocol
                    byte[] buffer = new ASCIIEncoding().GetBytes(Protocol.EXIT);
                    _clientStream.Write(buffer, 0, PROTOCOL_SIZE);
                    _clientStream.Flush();
                }
                catch (SocketException err)
                { }
            }
            
            // close objects
            _client.Close();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text.ToString();
            string password = passwordTextbox.Text.ToString();
            string userLen = username.Length.ToString().PadLeft(2, '0');
            string passLen = password.Length.ToString().PadLeft(2, '0');
            string message = Protocol.SIGN_IN_SEND + userLen + username + passLen + password;

            _username = username;
            //set username in top right corner of window
            StatusWin.setUsernameLabel(_username);
            ScoresWin.setUsernameLabel(_username);
            JoinWin.setUsernameLabel(_username);
            CreateWin.setUsernameLabel(_username);

            if(username == "" || password == "")
            {
                promptLabel.Visible = true;
                promptLabel.Text = EMPTY_DETAILS;
            }
            else
            {
                // send message to server
                try
                {
                    NetworkStream clientStream = _client.GetStream();
                    byte[] buffer = new ASCIIEncoding().GetBytes(message);
                    clientStream.Write(buffer, 0, message.Length);
                    clientStream.Flush();
                }
                catch (SocketException err)
                { }
                promptLabel.Visible = false;
            }           
        }


        // Button clicks callbacks
        private void My_status_Click(object sender, EventArgs e)    // send to server
        {
            Helpers.sendMessage(Protocol.STATUS_SEND, _clientStream);
            this.Hide();
            StatusWin.ShowDialog();
            this.Show();
        }

        private void Quit_Click(object sender, EventArgs e) 
        {
            this.Close();   // call the form closing callback
        }

        private void Best_scores_Click(object sender, EventArgs e)  // send to server
        {
            Helpers.sendMessage(Protocol.BEST_SCORE_REQ, _clientStream);
            this.Hide();
            ScoresWin.ShowDialog();
            this.Show();
        }

        private void Create_room_Click(object sender, EventArgs e)  
        {
            CreateWin.setStream(_clientStream); // move to create room window
            CreateWin.setWaitWin(waitWin);
            waitWin.setGame(GameWin, this);
            this.Hide();
            CreateWin.ShowDialog();
            this.Show();
        }

        private void Join_room_Click(object sender, EventArgs e)
        {
            this._isWaiting = false;
            JoinWin.setStream(_clientStream); // move to join room window
            JoinWin.setMenuWin(this);
            JoinWin.setWaitWin(waitWin);
            waitWin.setGame(GameWin, this);
            JoinWin.loadData();
            this.Hide();
            JoinWin.ShowDialog();
            this.Visible = false;
            this.Show();
        }

        private void Sign_up_Click(object sender, EventArgs e)
        {
            Sign_up_Win.setStream(_clientStream);    // move to sign up window
            this.Hide();
            Sign_up_Win.ShowDialog();
            this.Show();
        }

        private void signoutButton_Click(object sender, EventArgs e)
        {
            Helpers.sendMessage(Protocol.SIGN_OUT_SEND, _clientStream);
            // disable everything
            joinRoomButton.Enabled = false;
            bestScoresButton.Enabled = false;
            createRoomButton.Enabled = false;
            myStatusButton.Enabled = false;
            // make some things visible - like username text box visible
            signinButton.Visible = true;
            usernameTextbox.Visible = true;
            passwordTextbox.Visible = true;
            usernameLabel.Visible = true;
            passwordLabel.Visible = true;
            signupButton.Visible = true;
            signoutButton.Visible = false;
            // display hello user label
            hellouserLabel.Visible = false;
            
        }

        public void setIsWaiting(bool isWaiting)
        {
            this._isWaiting = isWaiting;
        }
    }
}
