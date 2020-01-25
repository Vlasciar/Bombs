using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player_Data 
{
    public int HighScore;
    public int Stars;
    public Player_Data()
    {
        HighScore = Game_Controller.HighScore;
        Stars = Pick_Ups.Star_Count;
    }
}
