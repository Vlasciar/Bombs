using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Spawner : MonoBehaviour
{
    public GameObject Bomb;
    public float SpawnRate = 2f;
    float m_SpawnRate;
    public float SpawnRateDecrement = 0.05f;
    float Time_Since_Last_Spawn = 0;

    void Start()
    {
        m_SpawnRate = SpawnRate;
    }

    void Update()
    {
        if (Input.touchCount == 2 && !Game_Controller.Game_Lost)
        {
            Spawn_Bomb();
        }
        if (!Game_Controller.Game_Lost)
        {
            m_SpawnRate = SpawnRate;
        }
     }
    void Spawn_Bomb()
    {
        if (m_SpawnRate == SpawnRate)
        {
            Invoke("SpawnRate_Decrement", 0f);
        }
        Time_Since_Last_Spawn += Time.deltaTime;
        if (!Game_Controller.Game_Lost && Input.touchCount == 2 && Time_Since_Last_Spawn >= m_SpawnRate)
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
}
