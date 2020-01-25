using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Detection : MonoBehaviour
{
    MeshCollider meshCollider;
    LineRenderer lineRenderer;
    public GameObject Explosion_Trigger;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;

        meshCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Mesh mesh = new Mesh();
        lineRenderer.BakeMesh(mesh, true);
        meshCollider.sharedMesh = mesh;
    }
    public GameObject New_Star;
     void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Bomb")
        {
            Instantiate(Explosion_Trigger, col.transform.position, col.transform.rotation);
            Game_Controller.Game_Lost = true;
        }
        if (col.tag == "Star")
        {
            Game_Controller.Score += 5;
            Number_Anim.Scored = true;
            Pick_Ups.Star_Count++;
            New_Star.SetActive(true);
            PlayerPrefs.SetInt("Stars",Pick_Ups.Star_Count);
            Destroy(col.gameObject);
        }
    }
}
