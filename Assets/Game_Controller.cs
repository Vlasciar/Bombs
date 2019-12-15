using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public static bool Game_Started = false;
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Game_Started = true;
        }
    }
}
