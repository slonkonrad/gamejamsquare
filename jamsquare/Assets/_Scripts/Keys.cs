using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys
{

    public class Sounds
    {
        public class Backgrounds
        {
            public static string GAME_BACKGROUND = "SummerTown";
        }

        public class Sound_Effects
        {

        }
    }
    
    public class Inputs
    {
        public static string A_BUTTON_1 = "A_ButtonPlayer1";
        public static string A_BUTTON_2 = "A_ButtonPlayer2";

        public static string B_BUTTON_1 = "B_ButtonPlayer1";
        public static string B_BUTTON_2 = "B_ButtonPlayer2";

        public static string X_BUTTON_1 = "X_ButtonPlayer1";
        public static string X_BUTTON_2 = "X_ButtonPlayer2";

        public static string Y_BUTTON_1 = "Y_ButtonPlayer1";
        public static string Y_BUTTON_2 = "Y_ButtonPlayer2";

        public static string[] A_BUTTON ={ A_BUTTON_1, A_BUTTON_2 };
        public static string[] B_BUTTON = { B_BUTTON_1, B_BUTTON_2 };
        public static string[] X_BUTTON = { X_BUTTON_1, X_BUTTON_2 };
        public static string[] Y_BUTTON = { Y_BUTTON_1, Y_BUTTON_2 };

        public static string LB_BUTTON_1 = "LB_ButtonPlayer1";
        public static string LB_BUTTON_2 = "LB_ButtonPlayer2";

        public static string RB_BUTTON_1 = "RB_ButtonPlayer1";
        public static string RB_BUTTON_2 = "RB_ButtonPlayer2";

        public static string[] LB_BUTTON = { LB_BUTTON_1, LB_BUTTON_2 };
        public static string[] RB_BUTTON = { RB_BUTTON_1, RB_BUTTON_2 };

        public static string LT_BUTTON_1 = "LT_ButtonPlayer1";
        public static string LT_BUTTON_2 = "LT_ButtonPlayer2";

        public static string RT_BUTTON_1 = "RT_ButtonPlayer1";
        public static string RT_BUTTON_2 = "RT_ButtonPlayer2";

        public static string[] LT_BUTTON = { LT_BUTTON_1, LT_BUTTON_2 };
        public static string[] RT_BUTTON = { RT_BUTTON_1, RT_BUTTON_2 };

        public static string LEFT_ANALOG_H_PLAYER_1= "LeftAnalogH_Player1";
        public static string LEFT_ANALOG_H_PLAYER_2 = "LeftAnalogH_Player2";

        public static string LEFT_ANALOG_V_PLAYER_1 = "LeftAnalogV_Player1";
        public static string LEFT_ANALOG_V_PLAYER_2 = "LeftAnalogV_Player2";

        public static string RIGHT_ANALOG_H_PLAYER_1 = "RightAnalogH_Player1";
        public static string RIGHT_ANALOG_H_PLAYER_2 = "RightAnalogH_Player2";

        public static string RIGHT_ANALOG_V_PLAYER_1 = "RightAnalogV_Player1";
        public static string RIGHT_ANALOG_V_PLAYER_2 = "RightAnalogV_Player2";

        public static string[] LEFTANALOG_H = { LEFT_ANALOG_H_PLAYER_1, LEFT_ANALOG_H_PLAYER_2 };
        public static string[] LEFTANALOG_V = { LEFT_ANALOG_V_PLAYER_1, LEFT_ANALOG_V_PLAYER_2 };

        public static string[] RIGHTANALOG_H = { RIGHT_ANALOG_H_PLAYER_1, RIGHT_ANALOG_H_PLAYER_2 };
        public static string[] RIGHTANALOG_V = { RIGHT_ANALOG_V_PLAYER_1, RIGHT_ANALOG_V_PLAYER_2 };
    }

    public class Players
    {
        public static int PLAYER_ONE = 0;
        public static int PLAYER_TWO = 1;

    }

    
    public class Animations
    {

        public static string[] RUN_ANIMATIONS = { "Running_Animation2" , "Running_Animation3" ,
                                                 "Running_Animation4" , "Running_Animation5","Running_Animation6",
                                                  "Running_Animation7","Running_Animation8","Running_Animation9"};
        public static float[] RUN_ANIMARIONS_SPEED = {1,2.12f,                        //Konrad nie bij
                                                      1,1,0.5f,
                                                      0.54f,2.8f,2.34f};

        public static string[] IDLE_ANIMATIONS = { "Idle_Animation1", "Idle_Animation2", "Idle_Animation3" };
        public static float[] IDLE_ANIMARIONS_SPEED = { 5, 6, 7 };

        public static string[] WALK_ANIMATIONS = { "Walk_Animation1" };
        public static float[] WALK_ANIMARIONS_SPEED = { 5};

        public static string STOP_ANIMATIONS = "Stop_Animation";

    }
}
