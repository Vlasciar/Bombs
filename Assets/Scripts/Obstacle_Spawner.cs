using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    public GameObject Bomb;
    public GameObject Star;
    const float SpawnRate = 2f;
    public static float m_SpawnRate;
    float SpawnRateDecrement = 0.05f;
    float Time_Since_Last_Spawn = 0;

    void Start()
    {
        m_SpawnRate = SpawnRate;
    }
    
    void Update()
    {
        if (Game_Controller.Game_Running)
        {
            Spawn_Bomb();
            Spawn_Star_Check();
        }
        if (Game_Controller.Game_Lost)
        {
            //m_SpawnRate = SpawnRate;
            CancelInvoke();// cancel the decrement function
        }       
     }
    void Spawn_Bomb()
    {
        if (m_SpawnRate == SpawnRate)
        {
            Invoke("SpawnRate_Decrement", 0f);
        }
        Time_Since_Last_Spawn += Time.deltaTime;
        if (Time_Since_Last_Spawn >= m_SpawnRate)
        {
            Time_Since_Last_Spawn = 0;
            Instantiate(Bomb);
        }
    }
    public void SpawnRate_Decrement()
    {
        if (m_SpawnRate > 0.5f)
        {
            m_SpawnRate -= (SpawnRateDecrement - 0.01f * ((2 - m_SpawnRate) * 2));//decrease the spawn rate less when its shorter
        }
        Invoke("SpawnRate_Decrement", SpawnRate);//decrease spawn rate every 2 sec
    }
    public AnimationCurve Chance_Curve;
    float Spawn_Chance;
    float Time_Since_Last_Check;
    void Spawn_Star_Check()
    {
        Time_Since_Last_Check += Time.deltaTime;
        Spawn_Chance = this.Chance_Curve.Evaluate((float)Game_Controller.Score / 100);
        if (Time_Since_Last_Check >= 1)
        {
            if ((int)Random.Range(0, 5 / Spawn_Chance) == 0)//from 2%chance to 10% to spawn each second
            {
                Instantiate(Star);
            }
            Time_Since_Last_Check = 0;
        }
    }
}
