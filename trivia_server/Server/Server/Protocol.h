// login in
#define SIGN_IN_REQ 200				// sign in request
#define SIGN_IN_SUCESS "1020"
#define SIGN_IN_WRONG_DETAILS "1021"
#define SIGN_IN_ALREADY_CONNECTED "1022"
#define SIGN_IN_ANS 102				// sign in replay (answer)
#define SIGN_OUT_REQ 201			// sign out request
#define SIGN_UP_REQ 203				// sign up request
#define SIGN_UP_ANS 104	
#define SIGN_UP_SUCCESS "1040"
#define SIGN_UP_PASS_ILLEGAL "1041"
#define SIGN_UP_USERNAME_EXISTS "1042"
#define SIGN_UP_USERNAME_ILLEGAL "1043"
#define SIGN_UP_OTHER "1044"

// rooms
#define EXISTING_ROOMS_REQ 205		// request for getting all existing rooms
#define EXISTING_ROOMS_ANS 106		// answer for all rooms
#define ROOM_USERS_REQ 207			// request for getting all users of specific room
#define ROOM_USERS_ANS 108			// answer
#define ROOM_USERS_ERR "1080"
#define JOIN_ROOM_REQ 209			// join
#define JOIN_ROOM_ANS 110	
#define JOIN_ROOM_FULL "1101"
#define JOIN_ROOM_OTHER "1102"	
#define LEAVE_ROOM_REQ 211			// leave
#define LEAVE_ROOM_ANS 112	
#define CREATE_ROOM_REQ 213			// create
#define CREATE_ROOM_ANS 114
#define CLOSE_ROOM_REQ 215			//close
#define CLOSE_ROOM_ANS 116

// game
#define START_GAME_REQ 217	
#define QUESTION_DETAILS_ANS 118	// send question and 4 answers to all users, answer for 217
#define QUESTION_DETAILS_ERR "1180"
#define USER_CHOICE_REQ 219
#define USER_CHOICE_ANS 120
#define END_GAME_ANS 121
#define END_GAME_REQ 222

// stats & profile
#define BEST_SCORE_REQ 223
#define BEST_SCORE_ANS 124
#define SELF_STATUS_REQ 225			// show personal details
#define SELF_STATUS_ANS 126

// exit application
#define EXT_REQ 299
