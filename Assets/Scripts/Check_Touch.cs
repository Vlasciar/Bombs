using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Touch : MonoBehaviour
{

    public static bool Check(string touched)//checks if the tag is correct
    {
        if ((Input.touchCount > 0))
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if ((Input.GetTouch(i).phase == TouchPhase.Began))
                {
                    Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    RaycastHit raycastHit;
                    if (Physics.Raycast(raycast, out raycastHit))
                    {
                        /* 
                          if (raycastHit.collider.name == touched)
                         {
                             return true;
                         }
                         */

                        if (raycastHit.collider.CompareTag(touched))
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
