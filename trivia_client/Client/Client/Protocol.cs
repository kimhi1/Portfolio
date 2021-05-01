using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Protocol
    {
        public const string SIGN_IN_SEND = "200";
        public const string SIGN_IN_RECIEVED = "102";
        public const string SIGN_IN_SUCCESS = "0";
        public const string SIGN_IN_ERROR = "1";
        public const string SIGN_IN_CONNECTED = "2";

        public const string SIGN_UP_SEND = "203";
        public const string SIGN_UP_RECIEVED = "104";
        public const string SIGN_UP_SUCCESS = "0";
        public const string SIGN_UP_PASS_ILLEGAL = "1";
        public const string SIGN_UP_USERNAME_EXISTS = "2";
        public const string SIGN_UP_USERNAME_ILLEGAL = "3";
        public const string SIGN_UP_OTHER = "4";

        public const string SIGN_OUT_SEND = "201";

        public const string BEST_SCORE_REQ = "223";
        public const string BEST_SCORE_ANS = "124";
        public const string SELF_STATUS_REQ = "225";
        public const string SELF_STATUS_ANS = "126";

        public const string JOIN_ROOM_SEND = "209";
        public const string JOIN_ROOM_RECIEVED = "110";
        public const string JOIN_ROOM_SUCCESS = "0";
        public const string JOIN_ROOM_FULL = "1";
        public const string JOIN_ROOM_OTHER = "2";

        public const string GET_ROOMS_SEND = "205";
        public const string GET_ROOMS_RECIEVED = "106";

        public const string GET_ROOM_USERS_SEND = "207";
        public const string GET_ROOM_USERS_RECIEVED = "108";

        public const string CREATE_ROOM_SEND = "213";
        public const string CREATE_ROOM_RECIEVED = "114";
        public const string CREATE_ROOM_SUCCESS = "0";
        public const string CREATE_ROOM_FAIL = "1";

        public const string CLOSE_ROOM_SEND = "215";
        public const string CLOSE_ROOM_RECIEVED = "116";



        public const string LEAVE_ROOM_SEND = "211";
        public const string LEAVE_ROOM_RECIEVED = "112";
        public const string LEAVE_ROOM_SUCCESS = "0";

        public const string START_GAME_SEND = "217";
        public const string STRAT_GAME_RECIEVED = "118";
        public const string START_GAME_FAIL = "0";
        public const string GAME_OUT_OF_TIME = "5";

        public const string USER_CHOICE_SEND = "219";
        public const string USER_CHOICE_RECIEVED = "120";
        public const string USER_CHOICE_CORRECT = "1";

        public const string GAME_END_RECIEVED = "121";

        public const string GAME_END_SEND = "222";

        public const string STATUS_SEND = "225";
        public const string STATUS_RECIEVED = "126";

        public const string EXIT = "299";
    }
}
