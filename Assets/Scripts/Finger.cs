using UnityEngine;
using System.Collections;
using UnityEngine.iOS;

public class Finger : MonoBehaviour
{ 
    private Vector3 position;
    private float width;
    private float height;
    

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
    //public Finger other_finger;
    void Follow_Fingers()
    {
        Touch touch = Input.GetTouch(FID);
        
        if (touch.phase == TouchPhase.Moved)// Move the cube if the screen has the finger moving.//FID == touch.fingerId &&
        {
            Vector2 pos = touch.position;
            pos.x = ((pos.x - width) * Xscale) / width;
            pos.y = ((pos.y - height) * Yscale) / height;
            position = new Vector3(pos.x, pos.y, 0.0f);

            // Position the cube.`
            transform.position = position;
        }
    }

    public int FID;
    public float touch_radius = 3;

    /* bool Check_Valid_Touch()
    {
        Touch touch = Input.GetTouch(FID);

        Vector2 pos = touch.position;
        float x1 = ((pos.x - width) * Xscale) / width;
        float y1 = ((pos.y - height) * Yscale) / height;
        float x2 = transform.position.x, y2 = transform.position.y;

        if (Mathf.Sqrt(Mathf.Pow((x2 - x1), 2) + Mathf.Pow((y2 - y1), 2)) <= touch_radius)
            return true;
        else return false;

        
    }*/
}