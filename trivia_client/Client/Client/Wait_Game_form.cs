using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Client
{
    public partial class Wait_Game_form : Form
    {

        private NetworkStream _clientStream;

        private Game_form _GameWin;
        private string _roomName;

        private Menu_form _mf;

        private const string FAIL = "Failed to fetch question";

        public Wait_Game_form()
        {
            InitializeComponent();
            _clientStream = null;
            _GameWin = null;
            _mf = null;
        }

        public void setMenuForm(Menu_form mf)
        {
            this._mf = mf;
        }

        public void setGame(Game_form GameWin, Menu_form mf)
        {
            this._GameWin = GameWin;
            this._GameWin.setMenuWin(mf);
        }

        public void initNames(string name, string roomName)
        {
            usernameLabel.Text = name;
            Room_name_to_wait.Text += roomName;
            _roomName = roomName;
        }

        // init the 3 fields which will be presented to the user
        public void initAdmin(int playersNo, int questionNo, int time)
        {
            maxNumberPlayerLabel.Text = playersNo.ToString();
            numberOfQuestionLabel.Text = questionNo.ToString();
            timeLabel.Text = time.ToString();
            Leave__Room.Visible = false;
            closeRoomButton.Visible = true;
            maxNumberPlayerLabel.Visible = true;
            PlayerLabel.Visible = true;
            Start_Game.Visible = true;
        }

        public void initNormal(int questionNo, int time)
        {
            //set location for desgin
            QuestionsLabel.Location = PlayerLabel.Location;
            numberOfQuestionLabel.Location = maxNumberPlayerLabel.Location;

            numberOfQuestionLabel.Text = questionNo.ToString();
            timeLabel.Text = time.ToString();
            Leave__Room.Visible = true;
            closeRoomButton.Visible = false;
            maxNumberPlayerLabel.Visible = false;
            PlayerLabel.Visible = false;
            Start_Game.Visible = false;
        }

        // set network stream for communication
        public void setStream(NetworkStream clientStream)
        {
            this._clientStream = clientStream;
        }

        // notice - this is the LEAVE button
        private void Leave_Or_Close_Room_Click(object sender, EventArgs e)
        {
            string message = Protocol.LEAVE_ROOM_SEND;
            Helpers.sendMessage(message, _clientStream);
            // we will go back to menu once we will receive answer about this
        }

        // close room button
        private void closeRoomButton_Click(object sender, EventArgs e)
        {
            string message = Protocol.CLOSE_ROOM_SEND;
            Helpers.sendMessage(message, _clientStream);
            // notice - we will go back to menu once we will know that it closed successfully
        }

        // answer from server about closing the room
        public void closeRoomAnswer()
        {
            // if we got here, the room is closing, and we shall exit
            promptLabel.Visible = false;
            backToMenu();
        }

        // answer about leaving the room
        public void leaveRoomAnswer()
        {
            string message = Helpers.getMessage(1, _clientStream);
            if (message == Protocol.LEAVE_ROOM_SUCCESS)
            {
                backToMenu();
            }
        }

        public void initName (string username)
        {
            listPlayer.Items.Clear();
            listPlayer.Items.Add(username);
        }

        // called when need to update user list
        public void usersAnswer()
        {
            string name;
            int playerNo, i, nameLen;

            playerNo = int.Parse(Helpers.getMessage(1, _clientStream)); // first byte is number of players

            // first clean the users list box
            listPlayer.Items.Clear();

            // for each player name recieved, add to users list box
            for (i = 0; i < playerNo; i++)
            {
                nameLen = int.Parse(Helpers.getMessage(2, _clientStream));
                name = Helpers.getMessage(nameLen, _clientStream);
                listPlayer.Items.Add(name);
            }
        }

        // start the game button clicked
        private void Start_Game_Click(object sender, EventArgs e)
        {
            initForJoin();
            _GameWin.setWaitWin(null);
            promptLabel.Visible = false;
            this.Hide();
            Helpers.sendMessage(Protocol.START_GAME_SEND, _clientStream);
            _GameWin.ShowDialog();
            this.Close();
        }

        public void initForJoin()
        {
            _GameWin.Visible = false;
            _GameWin.setStream(_clientStream);
            _GameWin.setUsernameLabel(usernameLabel.Text);
            _GameWin.setRoomName(_roomName);
            _GameWin.setQuestionNo(int.Parse(numberOfQuestionLabel.Text));
            _GameWin.setQuestionTime(int.Parse(timeLabel.Text));
            _GameWin.startTicker();
            _GameWin.setWaitWin(this);
        }

        private void backToMenu()
        {
            this.Hide();
            if(_mf != null)
            {
                _mf.Visible = true;
            }
            this.Close();
        }
       
    }
}
