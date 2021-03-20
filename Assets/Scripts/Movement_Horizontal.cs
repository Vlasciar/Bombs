using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Horizontal : MonoBehaviour
{
    //            x   y                    x    y
    //corners   -7.5  +3_________________+7.5   +3 
    //          |              1                   |
    //          |                                  |
    //          | 0                              2 |
    //          |                3                 |
    //          -7.5  -3_________________+7.5   -3
    const float LimitX = 10f;
    const float LimitY = 6f;
    public float Density = 1f;
    float StartX, StartY;
    public float DestinationX, DestinationY;
    public static bool[] SpawnPointsBusy;
    int SpawnPointsNumber;
    int SpawnPointID = 0;
    void Start()
    {
        transform.position = new Vector3(LimitX * 2, LimitY * 2, 0);
        SpawnPointsNumber = (int)(LimitY * 2 / Density);
        SpawnPointsBusy = new bool[SpawnPointsNumber];
        for (int i = 0; i < SpawnPointsNumber; i++)
        {
            SpawnPointsBusy[i] = false;
        }
        Generate_Path();
    }

    public float speed = 0.05f;
    int frame = 0;
    void FixedUpdate()
    {
        float posX;
        float posY;
        float distance = speed * frame;
        posX = StartX + distance;
        posY = StartY;

        if (Mathf.Abs(distance) >= 2 * LimitX)
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
                StartX = -LimitX;
                while (fuse >= 0)
                {
                    SpawnPointID = Random.Range(0, SpawnPointsNumber);
                    if (!SpawnPointsBusy[SpawnPointID]) break;
                    fuse--;
                    if (fuse == 0) Destroy(gameObject);
                }
                SpawnPointsBusy[SpawnPointID] = true;
                StartY = ((float)SpawnPointID  - (float)SpawnPointsNumber / 2) * Density;
                DestinationY = StartY;
                DestinationX = LimitX;
                break;
            case 1:
                StartX = LimitX;
                speed = -speed;
                while (fuse >= 0)
                {
                    SpawnPointID = Random.Range(0, SpawnPointsNumber);
                    if (!SpawnPointsBusy[SpawnPointID]) break;
                    fuse--;
                    if (fuse == 0) Destroy(gameObject);
                }
                SpawnPointsBusy[SpawnPointID] = true;
                StartY = ((float)SpawnPointID  - (float)SpawnPointsNumber / 2) * Density;
                DestinationY = StartY;
                DestinationX = -LimitX;
                break;
        }
    }


}
