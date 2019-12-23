using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public static bool Game_Started = false;
    public GameObject line;
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Game_Started = true;
            line.SetActive(true);
        }
        else
        {
            Game_Started = false;
            line.SetActive(false);
        }
        Spawn_Bomb();
    }
    public GameObject Bomb;
    public float SpawnRate = 1f;
    float Time_Since_Last_Spawn = 0;
    void Spawn_Bomb()
    {
        Time_Since_Last_Spawn += Time.deltaTime;
        if(Time_Since_Last_Spawn >= SpawnRate)
        {
            Time_Since_Last_Spawn = 0;
            Instantiate(Bomb);
        }
    }
}

