using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number_Anim : MonoBehaviour
{

    public static bool Scored = false;
    Animation anim;
    void Start()
    {
        audio = GetComponent<AudioSource>();
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
    AudioSource audio;
    public AudioClip Audio_Scored;
    void Sound_Scored()
    {
        audio.clip = Audio_Scored;
        audio.Play(0);
    }
}
