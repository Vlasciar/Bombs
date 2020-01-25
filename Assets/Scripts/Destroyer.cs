using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{  
    public float Time_To_Destroy = 2f;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (Time_To_Destroy > 0)
        {
           Destroy(gameObject, Time_To_Destroy);  
        }
    }
    float time = 0;
    void Update()
    {
        if (tag == "Explosion" && time < 0.25f)
        {
            if (Camera_Shake.Shake == false)
            {
                Camera_Shake.Shake = true;
            }
        }
        time += Time.deltaTime;
    }
    public void Destroy_Object()
    {
        Destroy(gameObject);
    }
    public void Deactivate_Object()
    {
        this.gameObject.SetActive(false);
    }
    AudioSource audio;
    public AudioClip Explosion;
    void Sound_Explosion()
    {
        audio.clip = Explosion;
        audio.Play(0);
    }
}
