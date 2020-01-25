using UnityEngine;
using System.Collections;


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
    public bool Finger_Busy = false;
    static bool[] FID_Busy = new bool[2];
    public int FID;
    void Update()
    {
        if (!Finger_Busy)
        {
            foreach (Touch touch in Input.touches)
            {
                if (!FID_Busy[touch.fingerId])
                {
                    Vector2 pos = touch.position;
                    pos.x = ((pos.x - width) * Xscale) / width;
                    pos.y = ((pos.y - height) * Yscale) / height;
                    if (Vector2.Distance(pos, transform.position) <= 1 || Game_Controller.Run_Time < 0.25f)
                    {
                        FID = touch.fingerId;
                        FID_Busy[touch.fingerId] = true;
                        Finger_Busy = true;
                        break;
                    }
                }
            }
        }
        if (Finger_Busy)
        {            
            Follow_Fingers();
        }
    }
    public GameObject Other_Finger;
    void Follow_Fingers()
    {
        try 
        {
            Input.GetTouch(FID);
        }       
        catch
        {
            FID_Busy[FID] = false;
            Finger_Busy = false;
            return;
        }


        Touch touch = Input.GetTouch(FID);
        if (touch.phase == TouchPhase.Moved)// Move the cube if the screen has the finger moving.//FID == touch.fingerId &&
        {
            Vector2 pos = touch.position;
            Vector2 last_pos = transform.position;
            pos.x = ((pos.x - width) * Xscale) / width;
            pos.y = ((pos.y - height) * Yscale) / height;
            // Position the finger.
            if (Vector2.Distance(pos, transform.position) <= Radius || Game_Controller.Run_Time < 0.25f)
            {
                transform.position = pos;
            }
            //reposition if laser lenght is to short
            if (Vector2.Distance(transform.position, Other_Finger.transform.position) < Radius)
            {
                transform.position = last_pos;
                Set_Circular_Position(pos);
            }
        }
        if (touch.phase == TouchPhase.Ended)
        {
            FID_Busy[touch.fingerId] = false;
            Finger_Busy = false;
        }        
    }
    public float Radius;
    void Set_Circular_Position(Vector2 B)//touch point
    {
        Vector2 A = Other_Finger.transform.position;//Center of circle
        Vector2 C;//poin on circle
        float distance = Vector2.Distance(B,A);
        C.x = A.x + Radius * ((B.x - A.x) / distance);
        C.y = A.y + Radius * ((B.y - A.y) / distance);
        transform.position = new Vector2(C.x, C.y);
    }
}