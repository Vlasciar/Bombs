using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initial_Explosion : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2f);
    }
    public GameObject Explosion;
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Bomb")
        {
            Instantiate(Explosion, col.transform.position, col.transform.rotation);
            Destroy(col.gameObject);
        }
        if (col.tag == "Star")
        {
            Destroy(col.gameObject);
        }
    }
    
    void Update()
    {
        if(!Game_Controller.Game_Lost)
        {
            Animation anim;
            anim = GetComponent<Animation>();
            anim.enabled = false;
            transform.localScale = new Vector3(40, 40, 40);
            Destroy(gameObject, 0.1f);
        }
        
    }
}
