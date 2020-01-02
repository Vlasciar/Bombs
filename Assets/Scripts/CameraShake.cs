using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Animation Anim;
    public static bool Shake;
    void Start()
    {
        Anim = GetComponent<Animation>();
    }

    void Update()
    {
        if(!Anim.isPlaying && Shake)
        {
            Anim.Play("Shake");
        }
        Shake = false;        
    }
}
