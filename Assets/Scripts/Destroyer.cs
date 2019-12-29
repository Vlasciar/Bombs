using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Animator Anim;
    void Start()
    {
        Destroy(gameObject, 2f);
        Anim = GetComponent<Animator>();
    }

    public void Destroy_Object()
    {
        Destroy(gameObject);
    }

}
