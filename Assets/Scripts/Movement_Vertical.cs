using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Vertical : MonoBehaviour
{
    //            x   y                    x    y
    //corners   -7.5  +3_________________+7.5   +3 
    //          |              1                   |
    //          |                                  |
    //          | 0                              2 |
    //          |                3                 |
    //          -7.5  -3_________________+7.5   -3
    const float LimitX = 9.5f;
    const float LimitY = 5.5f;
    public float Density=0.5f;
    float StartX, StartY;
    public float DestinationX, DestinationY;
    public static bool[] SpawnPointsBusy;
    int SpawnPointsNumber;
    int SpawnPointID = 0;
    void Start()
    {
        transform.position = new Vector3(LimitX*2, LimitY*2, 0);
        SpawnPointsNumber = (int)(LimitX * 2 / Density)+2;
        SpawnPointsBusy = new bool[SpawnPointsNumber];
        for (int i = 0; i < SpawnPointsNumber; i++)
        {
            SpawnPointsBusy[i] = false;
        }
        Generate_Path();    
    }

    public float speed=0.05f;
    public int frame = 0;
    void FixedUpdate()
    {
        float posX;
        float posY;
        float distance = speed * frame;
        posX = StartX;      
        posY = StartY + distance;

        if (distance >= 2 * LimitX)
        {
            Game_Controller.Score++;
            Number_Anim.Scored = true;
            SpawnPointsBusy[SpawnPointID] = false;
            Destroy(gameObject);
        }
       
        transform.position = new Vector3(posX, posY, 0);

        frame++;
    }
    int EdgeID;
    void Generate_Path()
    {
        EdgeID = Random.Range(0, 2);
       
        int fuse = 128;
        switch (EdgeID)
        {
            case 0:
                StartY = -LimitY;              
                while (fuse>=0)
                {
                    SpawnPointID = Random.Range(0, SpawnPointsNumber);
                    if (!SpawnPointsBusy[SpawnPointID]) break;
                    fuse--;
                    if (fuse == 0) Destroy(gameObject);
                }
                SpawnPointsBusy[SpawnPointID] = true;
                StartX = (float)(SpawnPointID/2-SpawnPointID) * Density;
                DestinationX = StartX;
                DestinationY = LimitY;
                break;
            case 1:
                StartY = LimitY;
                speed = -speed;
                while (fuse >= 0)
                {
                    SpawnPointID = Random.Range(0, SpawnPointsNumber);
                    if (!SpawnPointsBusy[SpawnPointID]) break;
                    fuse--;
                    if (fuse == 0) Destroy(gameObject);
                }
                SpawnPointsBusy[SpawnPointID] = true;
                StartX = (float)(SpawnPointID / 2 - SpawnPointID) * Density;
                DestinationX = StartX;
                DestinationY = -LimitY;
                break;
        }
    }


}
