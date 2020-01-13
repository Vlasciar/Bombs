using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaos_Controller : MonoBehaviour
{

    void Start()
    {
        
    }

    float Laser_Length;
    public Finger Finger1;
    public Finger Finger2;
    float Max_Chaos;
    public AnimationCurve Chaos_Curve;

    void Update()
    {
        //Debug.Log(DigitalRuby.LightningBolt.LightningBoltScript.ChaosFactor);
        Laser_Length = Vector2.Distance(Finger1.transform.position, Finger2.transform.position);
        Max_Chaos = this.Chaos_Curve.Evaluate(Laser_Length);
       // Debug.Log("Ln "+Laser_Length + "CH " + Max_Chaos);
        if (Finger1.Finger_Busy && Finger2.Finger_Busy)
        {
            if(DigitalRuby.LightningBolt.LightningBoltScript.ChaosFactor > 0.01f)
                DigitalRuby.LightningBolt.LightningBoltScript.ChaosFactor -= 0.01f;
        }
        else
        {
            if (Game_Controller.Game_Running)
            {
               // Finger_Up_Time += Time.deltaTime;
                if (DigitalRuby.LightningBolt.LightningBoltScript.ChaosFactor < Max_Chaos)
                    DigitalRuby.LightningBolt.LightningBoltScript.ChaosFactor += 0.1f;
                if (DigitalRuby.LightningBolt.LightningBoltScript.ChaosFactor > Max_Chaos)
                    DigitalRuby.LightningBolt.LightningBoltScript.ChaosFactor = Max_Chaos;
            }
        }
    }

}
