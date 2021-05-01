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
    public partial class Join_form : Form
    {
        private const string FULL = "The room is already full";
        private const string OTHER = "Cannot join the room because of unknown reason";

        private NetworkStream _clientStream;
        List<string> _roomsId;   // list of rooms id
        string _currId;
        private Wait_Game_form _waitWin;
        private Menu_form _mf;

        //parmeters for create wait window
        int _playerNo;
        int _questionsNo;
        int _time;
        string _roomName;

        public Join_form()
        {
            InitializeComponent();
            _clientStream = null;
            _roomsId = new List<string>();
            _currId = "";
            _waitWin = null;
            _mf = null;
        }

        public void setUsernameLabel(string name)
        {
            usernameLabel.Text = name;
        }

        public void setMenuWin(Menu_form mf)
        {
            this._mf = mf;
        }

        public void setWaitWin(Wait_Game_form waitWin)
        {
            this._waitWin = waitWin;
            waitWin.setMenuForm(this._mf);
        }

        // function will present the list of rooms
        public void loadData()
        {
            roomsListbox.Items.Clear();
            usersListbox.Items.Clear();
            _roomsId.Clear();
            _currId = "";
            Helpers.sendMessage(Protocol.GET_ROOMS_SEND, _clientStream);
        }

        // recieved answer about list of rooms
        public void roomsAnswer()
        {
            int i, roomNameLen;
            string roomId;

            int roomNo = int.Parse(Helpers.getMessage(4,_clientStream));    // first 4 bytes represent rooms count

            // clear both list boxes
            roomsListbox.Items.Clear();
            usersListbox.Items.Clear();
            _roomsId.Clear();

            for(i = 0; i < roomNo; i++)
            {
                roomId = Helpers.getMessage(4, _clientStream);
                roomNameLen = int.Parse(Helpers.getMessage(2, _clientStream));
                _roomName = Helpers.getMessage(roomNameLen, _clientStream);
                // now, after we got the room's name, present it in the list
                roomsListbox.Items.Add(_roomName);
                _roomsId.Add(roomId);
            }

        }

        // recieved answer about list of users in this room
        public void usersAnswer()
        {
            int i;
            int nameLen;
            string name;

                _playerNo = int.Parse(Helpers.getMessage(1, _clientStream)); // first byte is number of players

                // first clean the users list box
                usersListbox.Items.Clear();

                // for each player name recieved, add to users list box
                for (i = 0; i < _playerNo; i++)
                {
                    nameLen = int.Parse(Helpers.getMessage(2, _clientStream));
                    name = Helpers.getMessage(nameLen, _clientStream);
                    usersListbox.Items.Add(name);
               }
        }

        // answer from server about joining the room
        public void joinAnswer()
        {
            string ans = Helpers.getMessage(1, _clientStream);
            
            switch(ans)
            {
                case Protocol.JOIN_ROOM_SUCCESS:
                    // joined !
                    _mf.setIsWaiting(true);
                    _questionsNo = int.Parse(Helpers.getMessage(2, _clientStream));
                    _time = int.Parse(Helpers.getMessage(2, _clientStream));
                    promptLabel.Visible = false;
                    _waitWin.initNormal(_questionsNo, _time);
                    _waitWin.initNames(usernameLabel.Text, _roomName);
                    _waitWin.initForJoin();
                    break;
                case Protocol.JOIN_ROOM_FULL:
                    // the room is full
                    promptLabel.Visible = true;
                    promptLabel.Text = FULL;
                    break;
                case Protocol.JOIN_ROOM_OTHER:
                    // failed because of other reason
                    promptLabel.Visible = true;
                    promptLabel.Text = OTHER;
                    break;
            }
        }


        private void Back_Click(object sender, EventArgs e)
        {
            promptLabel.Visible = false;
            _mf.Visible = true;
            this.Hide();
            this.Close();
        }

        // clicked join button - join to this room
        private void joinButton_Click(object sender, EventArgs e)
        {
            // when this button is clicked, we shall send a request to the server - join the room
            if(_currId != "")
            {
                string message = Protocol.JOIN_ROOM_SEND + _currId;
                Helpers.sendMessage(message, _clientStream);

                this.Hide();
                _waitWin.ShowDialog();
                _waitWin.Visible = false;
                this.Close();
            }
        }

        public void setStream(NetworkStream clientStream)
        {
            this._clientStream = clientStream;
        }

        // clicked refresh - load the rooms and users again
        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.loadData();             // re-loads the data
        }

        // called when choosing a room
        private void roomsListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = roomsListbox.SelectedIndex;
            string id, message;

            if(index >= 0)
            {
                id = _roomsId[index]; // note that id is already padded
                _currId = id;
                message = Protocol.GET_ROOM_USERS_SEND + id;
                Helpers.sendMessage(message, _clientStream);
            }
            else
            {
                _currId = "";
            }
        }

    }
}
