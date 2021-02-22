using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Line : MonoBehaviour
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
    float StartX, StartY;
    public float DestinationX, DestinationY;
    float Opp, Adj;//Distance between start/end 
    float Tan;//Tangent
    void Start()
    {
        Generate_Path();
        //Debug.Log("Start: " + StartX + " " + StartY + "\n Destination: " + DestinationX + " " + DestinationY);
        transform.position = new Vector3(StartX, StartY, 0);
        Opp = -(StartX - DestinationX);// ADJESENT side lenght
        Adj = -(StartY - DestinationY);// OPPOSITE side lenght
        Tan = Mathf.Abs(Opp) / Mathf.Abs(Adj); 
    }

    public float speed;
    int frame = 0;
    void FixedUpdate()
    {      
        float posX;
        float posY;
        float distance = speed * frame;
        if (EdgeID == 0 || EdgeID == 2)
        {
            posX = StartX + distance * Mathf.Sign(Opp);
            posY = StartY + distance / Tan * Mathf.Sign(Adj);
            if (distance >= 2 * LimitX)
            {
                Game_Controller.Score++;
                Number_Anim.Scored = true;
                Destroy(gameObject);
            }                  
        }
        else
        {
            posX = StartX + distance * Tan * Mathf.Sign(Opp);
            posY = StartY + distance * Mathf.Sign(Adj);
            if (distance >= 2 * LimitY)
            {
                Game_Controller.Score+= (int)Obstacle_Spawner.multiplier;
                Number_Anim.Scored = true;
                Destroy(gameObject);                
            } 
        }       
        transform.position = new Vector3(posX, posY, 0);
        
        frame++;
    }

    int EdgeID;
    void Generate_Path()
    {
        EdgeID = Random.Range(0, 4);
        switch (EdgeID)
        {
            case 0:
                StartX = -LimitX;
                StartY = Random.Range(-LimitY, LimitY);

                DestinationX = LimitX;
                DestinationY = Random.Range(-LimitY, LimitY);
                break;
            case 1:
                StartX = Random.Range(-LimitX, LimitX);
                StartY = LimitY;

                DestinationX = Random.Range(-LimitX, LimitX);
                DestinationY = -LimitY;
                break;
            case 2:
                StartX = LimitX;
                StartY = Random.Range(-LimitY, LimitY);

                DestinationX = -LimitX;
                DestinationY = Random.Range(-LimitY, LimitY);
                break;
            case 3:
                StartX = Random.Range(-LimitX, LimitX);
                StartY = -LimitY;

                DestinationX = Random.Range(-LimitX, LimitX);
                DestinationY = LimitY;
                break;
        }
    }
   
     
}
