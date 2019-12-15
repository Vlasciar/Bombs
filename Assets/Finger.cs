using UnityEngine;
using System.Collections;
using UnityEngine.iOS;

public class Finger : MonoBehaviour
{ 
    private Vector3 position;
    private float width;
    private float height;
    
    public int FID = 0;
    public float Xscale = 8.5f;
    public float Yscale = 5f;

    void Start()
    {

        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;        
        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }
    

    void Update()
    {
        if (Game_Controller.Game_Started)
        {         
            Follow_Fingers();          
        }
    }

    void Follow_Fingers()
    {

        Touch touch = Input.GetTouch(FID);

        if (FID == touch.fingerId && touch.phase == TouchPhase.Moved)// Move the cube if the screen has the finger moving.
        {---------------------------------------
            Vector2 pos = touch.position;
            pos.x = ((pos.x - width) * Xscale) / width;
            pos.y = ((pos.y - height) * Yscale) / height;
            position = new Vector3(pos.x, pos.y, 0.0f);

            // Position the cube.
            transform.position = position;
        }
    }
}