using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number_Anim : MonoBehaviour
{

    public static bool Scored = false;
    Animation anim;
    void Start()
    {
        anim = GetComponent<Animation>();
    }
    void Update()
    {
        if(Scored)
        {
            anim.Play("Score_Up");
            Scored = false;
        }
    }
}
