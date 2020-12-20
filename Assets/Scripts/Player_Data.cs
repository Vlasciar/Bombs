using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player_Data 
{
    public int HighScore;
    public int Stars;
    public int Tutorial;
    public Player_Data()
    {
        HighScore = Game_Controller.HighScore;
        Stars = Pick_Ups.Star_Count;
        /*if (Game_Controller.showTutorial == true)
            Tutorial = 1;
        else if(Game_Controller.showTutorial == false)
            Tutorial = 0;*/
    }
}
