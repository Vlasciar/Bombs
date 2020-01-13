using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_Volume : MonoBehaviour
{
    public Sprite Volume_On;
    public Sprite Volume_Off;
    public SpriteRenderer Rend;
    public static bool Volume_Status = true;
    void Start()
    {
        Rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Check_Touch.Check("Volume_Icon"))
        {
            Volume_Status = !Volume_Status;
            if(Volume_Status)
            {
                Rend.sprite = Volume_On;
            }
            else
            {
                Rend.sprite = Volume_Off;
            }
        }
    }
}
