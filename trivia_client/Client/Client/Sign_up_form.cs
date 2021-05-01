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
using System.Threading;

namespace Client
{
    public partial class Sign_up_form : Form
    {
        private NetworkStream _clientStream;

        private const string SUCCESS = "Signed up successfully!";
        private const string OTHER = "problem while trying to sign up";
        private const string USERNAME_ILLEGAL = "The username is not legal";
        private const string PASS_ILLEGAL = "The passsword is not legal";
        private const string USERNAME_EXISTS = "The username already exists";

        public Sign_up_form()
        {
            InitializeComponent();
            _clientStream = null;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            promptLabel.Visible = false;
            this.Hide();
            this.Close();
        }

        public void signUpAnswer()
        {
            string message = Helpers.getMessage(1, _clientStream);
            promptLabel.Visible = true;
            switch(message)
            {
                case Protocol.SIGN_UP_SUCCESS:
                    promptLabel.Text = SUCCESS;
                    break;
                case Protocol.SIGN_UP_USERNAME_EXISTS:
                    promptLabel.Text = USERNAME_EXISTS;
                    break;
                case Protocol.SIGN_UP_USERNAME_ILLEGAL:
                    promptLabel.Text = USERNAME_ILLEGAL;
                    break;
                case Protocol.SIGN_UP_PASS_ILLEGAL:
                    promptLabel.Text = PASS_ILLEGAL;
                    break;
                case Protocol.SIGN_UP_OTHER:
                    promptLabel.Text = OTHER;
                    break;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text.ToString();
            string password = passwordTextbox.Text.ToString();
            string email = emailTextbox.Text.ToString();
            string userLen = username.Length.ToString().PadLeft(2, '0');
            string passLen = password.Length.ToString().PadLeft(2, '0');
            string emailLen = email.Length.ToString().PadLeft(2, '0');

            string message = Protocol.SIGN_UP_SEND + userLen + username +
                passLen + password + emailLen + email;

            Helpers.sendMessage(message, _clientStream);
        }


        public void setStream(NetworkStream clientStream)
        {
            this._clientStream = clientStream;
        }
    }
}
