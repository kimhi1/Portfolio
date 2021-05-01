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
    public partial class Create_form : Form
    {
        private NetworkStream _clientStream;
        private const string FIELDS_ERROR = "The fields are unvalid";
        private const string FAIL = "Failed to create the room";

        Wait_Game_form _waitWin;

        //parmeters for create wait window
        string _playerNo;
        string _questionNo;
        string _time;
        string _roomName;
        string _username;

        public Create_form()
        {
            InitializeComponent();
            _clientStream = null;
            _waitWin = null;
            _username = "";
        }

        public void setUsernameLabel(string name)
        {
            usernameLabel.Text = name;
            _username = name;
        }

        public void setWaitWin(Wait_Game_form waitWin)
        {
            this._waitWin = waitWin;
        }

        // called when answer recieved
        public void answer()
        {
            string message = Helpers.getMessage(1, _clientStream);
            if(message == Protocol.CREATE_ROOM_SUCCESS)
            {
                // if room created
                _waitWin.setStream(_clientStream);
                _waitWin.initAdmin(int.Parse(_playerNo), int.Parse(_questionNo), int.Parse(_time));
                _waitWin.initNames(usernameLabel.Text, _roomName);
                _waitWin.initName(_username);
                _waitWin.Visible = true;
            }
            else
            {
                // if there was an error
                errorLabel.Visible = true;
                errorLabel.Text = FAIL;
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            this.Hide();
            this.Close();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string message;
            _roomName = roomNameTextbox.Text.ToString();
            _playerNo = playerNumberTextbox.Text.ToString();
            _questionNo = questionNumberTextBox.Text.ToString().PadLeft(2, '0');
            _time = timeTextbox.Text.ToString().PadLeft(2,'0');

            string roomNameLen =  _roomName.Length.ToString().PadLeft(2, '0');   /// get length of room name (in 2 bytes)
            
            if(_playerNo == "" || _playerNo.Length > 1 || _roomName == "" || _questionNo == "" || _questionNo.Length > 2 || _time == "" || _time.Length > 2)
            {
                errorLabel.Visible = true;
                errorLabel.Text = FIELDS_ERROR;
            }
            else
            {
                errorLabel.Visible = false;
                message = Protocol.CREATE_ROOM_SEND + roomNameLen + _roomName + _playerNo + _questionNo + _time;
                Helpers.sendMessage(message, _clientStream);
                _waitWin.Visible = false;
                this.Hide();
                this.Close();
                _waitWin.ShowDialog();
            }
        }

        public void setStream(NetworkStream clientStream)
        {
            this._clientStream = clientStream;
        }

        private void questionNumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
