using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{  
    public float Time_To_Destroy = 2f;
    void Start()
    {
        Destroy(gameObject, Time_To_Destroy);  
    }
    float time = 0;
    void Update()
    {
        if (tag == "Explosion" && time < 0.25f)
        {
            if (CameraShake.Shake == false)
            {
                CameraShake.Shake = true;
            }
        }
        time += Time.deltaTime;
    }
    public void Destroy_Object()
    {
        Destroy(gameObject);
    }

}
