using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaos_Controller : MonoBehaviour
{

    void Start()
    {
        
    }

    float Laser_Length;
    public GameObject Finger1;
    public GameObject Finger2;
    void Update()
    {
        //Debug.Log(DigitalRuby.LightningBolt.LightningBoltScript.ChaosFactor);
        Laser_Length = Vector2.Distance(Finger1.transform.position, Finger2.transform.position);
        Debug.Log(Laser_Length);
        if (Input.touchCount == 2)
        {
            DigitalRuby.LightningBolt.LightningBoltScript.ChaosFactor = 0.05f;
        }
        if (Input.touchCount < 2)
        {
            if (Game_Controller.Game_Running)
            {
               // Finger_Up_Time += Time.deltaTime;
                if (DigitalRuby.LightningBolt.LightningBoltScript.ChaosFactor < 0.7)
                    DigitalRuby.LightningBolt.LightningBoltScript.ChaosFactor += 0.1f;
            }
        }
    }

}
