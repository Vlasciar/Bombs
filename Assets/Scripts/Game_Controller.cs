using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    public static int Score;
    public TextMesh Score_Text;
    public TextMesh Play;
    public static bool Game_Started = false;
    public static bool Game_Lost = false;
    public GameObject line;
    void Awake()
    {
        Play.text = "Hold 2 fingers to start";
    }
    void Update()
    {
        Score_Text.text = "Score: " + Score;
        if (!Game_Started && Input.touchCount == 2 && !Game_Lost)
        {          
            Game_Started = true;
            Play.gameObject.SetActive(false);
            line.SetActive(true);
        }
        if(Input.touchCount < 2 || Game_Lost)
        {
            Game_Started = false;
            line.SetActive(false);
        }
        if(Game_Lost)
        {
            Play.gameObject.SetActive(true);
            Play.text = "Restart";
            if(Check_Restart())
            {
                Restart();
            }
        }
        Spawn_Bomb();   
       
    }
    public GameObject Bomb;
    public float SpawnRate = 1f;
    float Time_Since_Last_Spawn = 0;
    void Spawn_Bomb()
    {
        Time_Since_Last_Spawn += Time.deltaTime;
        if(Game_Started && Time_Since_Last_Spawn >= SpawnRate)
        {
            Time_Since_Last_Spawn = 0;
            Instantiate(Bomb);
        }
    }
    bool Check_Restart()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log("dsf");
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
    void Restart()
    {
        Score = 0;
        Play.gameObject.SetActive(false);
        Game_Lost = false;
    }
}

