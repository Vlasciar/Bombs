using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game_Controller : MonoBehaviour
{
    public static int Score;
    public TextMesh Score_Text;
    public TextMesh HighScore;
    public TextMesh NewHighScore;
    public TextMesh Play;
    //public static bool Game_Started = false;
    public static bool Game_Lost = false;
    public static bool Game_Running = false;
    public GameObject line;
    public GameObject Touch_Button;
    public GameObject Explosion_Trigger;
    void Awake()
    {
        //PlayerPrefs.SetInt("HighScore", 0);/////
        Play.text = "Hold 2 fingers to start";
        HighScore.gameObject.SetActive(false);
    }
    float Run_Time;
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
            if(Check_Restart())
            {
                Restart();
            }
        }
    }
    void Run_Routine()
    {
        Play.gameObject.SetActive(false);
        line.SetActive(true);
        Touch_Button.SetActive(false);
        Run_Time += Time.deltaTime;

    }
    bool Check_Restart()//checks if restart was pressed
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.name == "Play")
                {
                    return true;
                }

                //OR with Tag

                if (raycastHit.collider.CompareTag("PlayTag"))
                {
                    return true;
                }
            }
        }
        return false;
    }
    void Lose_Screen()// runs after geme is lost and before restart is pressed
    {
        Game_Running = false;
        line.SetActive(false);
        HighScore.gameObject.SetActive(true);
        Play.gameObject.SetActive(true);
        if (Score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Score);
            NewHighScore.gameObject.SetActive(true);
        }
            
        HighScore.text = String.Concat("High Score: ", PlayerPrefs.GetInt("HighScore").ToString());
        Play.text = "Restart";        
        Run_Time = 0;     
    }
    void Restart()// runs when restart is pressed
    {
        Score = 0;
        Play.gameObject.SetActive(false);
        Score_Text.gameObject.SetActive(true);
        NewHighScore.gameObject.SetActive(false);
        HighScore.gameObject.SetActive(false);
        Game_Lost = false;
    }
}

