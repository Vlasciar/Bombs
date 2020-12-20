using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game_Controller : MonoBehaviour
{
    public static int Score;
    public static int HighScore;
    //public static bool showTutorial;
    public Toggle Tutorial;
    public TextMesh Score_Text;
    public TextMesh HighScore_Text;
    public TextMesh NewHighScore;
    public TextMesh Play;
    //public static bool Game_Started = false;
    public static bool Game_Lost = false;
    public static bool Game_Running = false;
    public GameObject Stars_Count;
    public GameObject line;
    public GameObject Touch_Button;
    public GameObject Explosion_Trigger;
    public GameObject Frame;
    void Awake()
    {
        //PlayerPrefs.SetInt("HighScore", 0);//COMMENT THIS OUT ON BUILD!!!!!1
        PlayerPrefs.SetInt("Tutorial",1);//COMMENT THIS OUT ON BUILD!!!!@1
        Play.text = "";
        HighScore_Text.gameObject.SetActive(false);
        Load_Player();
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            Frame.SetActive(false);
        }
    }
    public static float Run_Time;
    void Update()
    {
        Score_Text.text = "" + Score;
        if(!Game_Lost && Input.touchCount == 2)
        {
            Game_Running = true;
        }
        if (Game_Running)//game running normally
        {
            Run_Routine();               
        }             
        if(Game_Lost)
        {
            Lose_Screen();            

            if(Check_Touch.Check("PlayTag"))
            {
                Play.gameObject.GetComponent<Animation>().Play();
                Invoke("Restart", 0.4f);
            }
        }
        if(Tutorial.isOn)
        {           
            PlayerPrefs.SetInt("Tutorial", 0);
            Save_Player();
        }
    }
    void Run_Routine()// - runs continous
    {
        Frame.SetActive(false);
        Play.gameObject.SetActive(false);
        line.SetActive(true);
        Touch_Button.SetActive(false);
        Run_Time += Time.deltaTime;

    }
    void Lose_Screen()// runs after geme is lost and before restart is pressed - runs continous
    {
        Save_Player();//saves for the highscore 
        Stars_Count.SetActive(true);
        Game_Running = false;
        line.SetActive(false);
        HighScore_Text.gameObject.SetActive(true);
        Play.gameObject.SetActive(true);
        if (Score > HighScore)
        {
            HighScore = Score;
            NewHighScore.gameObject.SetActive(true);
        }

        HighScore_Text.text = String.Concat("High Score: ", HighScore);
        Play.text = "Restart";        
        Run_Time = 0;     
    }
    public void Restart()// runs when restart is pressed - runs on press
    {
        Stars_Count.SetActive(false);
        Play.gameObject.SetActive(false);        
        Score_Text.gameObject.SetActive(true);
        NewHighScore.gameObject.SetActive(false);
        HighScore_Text.gameObject.SetActive(false);
        Touch_Button.SetActive(true);
        Game_Lost = false;
        if (!Game_Running)
        {
            Obstacle_Spawner.m_SpawnRate = 2;//resets the spawn rate
            Score = 0;
            Pick_Ups.Revive_Cost = 5;
        }
    }

    public void Save_Player()
    {
        Save_System.Save_Player();
    }

    public void Load_Player()
    {
        Player_Data data = Save_System.Load_Player();

        Game_Controller.HighScore = data.HighScore;
        Pick_Ups.Star_Count = data.Stars;
    }
}

