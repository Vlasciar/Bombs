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
    public GameObject line;
    public GameObject Touch_Button;
    public GameObject Explosion_Trigger;
    void Awake()
    {
        //PlayerPrefs.SetInt("HighScore", 0);/////
        Play.text = "Hold 2 fingers to start";
        HighScore.gameObject.SetActive(false);
        m_SpawnRate = SpawnRate;
    }
    float Run_Time;
    float Finger_Up_Time;
    void Update()
    {
        Score_Text.text = "" + Score;
        if (Input.touchCount == 2 && !Game_Lost)
        {
            Play.gameObject.SetActive(false);            
            
            line.SetActive(true);
            Touch_Button.SetActive(false);
            Run_Time += Time.deltaTime;
            Finger_Up_Time = 0;
            Spawn_Bomb();
        }


        if (Input.touchCount < 2 || Game_Lost)
        {
            line.SetActive(false);
            if(Run_Time > 0)
            {
                Finger_Up_Time += Time.deltaTime;
            }
        }
        if(Game_Lost)
        {
            Lose_Screen();            
            if(Check_Restart())
            {
                Restart();
            }
        }

        if (Input.touchCount < 2 && !Game_Lost && Finger_Up_Time > 0.15f)
        {
            Game_Lost = true;
            Instantiate(Explosion_Trigger, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        }
    }
    public GameObject Bomb;
    public float SpawnRate = 2f;
    float m_SpawnRate;
    public float SpawnRateDecrement = 0.05f;
    float Time_Since_Last_Spawn = 0;
    void Spawn_Bomb()
    {
        if(m_SpawnRate == SpawnRate)
        {
            Invoke("SpawnRate_Decrement", 0f);
        }
        Time_Since_Last_Spawn += Time.deltaTime;
        if(!Game_Lost && Input.touchCount == 2 && Time_Since_Last_Spawn >= m_SpawnRate)
        {
            Time_Since_Last_Spawn = 0;            
            Instantiate(Bomb);
        }
    }
    void SpawnRate_Decrement()
    {
        if (m_SpawnRate > 0.5f)
        {
            m_SpawnRate -= (SpawnRateDecrement - 0.01f * ((2 - m_SpawnRate) * 2));
        }
        Invoke("SpawnRate_Decrement", SpawnRate);
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
        Finger_Up_Time = 0;
        m_SpawnRate = SpawnRate;
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

