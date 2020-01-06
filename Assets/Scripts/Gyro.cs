using UnityEngine;
using System.Collections;

public class Gyro : MonoBehaviour
{

    public float shake = 0.1f;
    public float smoothness = 0.01f;
    public float Max_Yoffset = 0.4f;
    public float Max_Xoffset = 0.5f;
    void Awake()
    {
        Input.gyro.enabled = true;
    }
    void Update()
    {
        //if (Mathf.Abs(transform.position.x) > Max_Xoffset) m_smoothness = -smoothness;//reverse direction if max offset is reached
        if (Mathf.Abs(transform.position.x - Input.gyro.rotationRateUnbiased.y)> shake)
        {
            if (Input.gyro.rotationRateUnbiased.y > transform.position.x)
            {
                transform.position += new Vector3(-smoothness, 0, 0);
                if (Mathf.Abs(transform.position.x) > Max_Xoffset)
                    transform.position += new Vector3(smoothness, 0, 0);//Revert movement
            }          
            if (Input.gyro.rotationRateUnbiased.y < transform.position.x)
            {
                transform.position += new Vector3(smoothness, 0, 0);
                if (Mathf.Abs(transform.position.x) > Max_Xoffset)
                    transform.position += new Vector3(-smoothness, 0, 0);
            }
        }
        
        if (Mathf.Abs(transform.position.y - Input.gyro.rotationRateUnbiased.x) > shake)
        {
            if (Input.gyro.rotationRateUnbiased.x > transform.position.y)
            {
                transform.position += new Vector3(0, smoothness, 0);
                if (Mathf.Abs(transform.position.y) > Max_Yoffset)
                    transform.position += new Vector3(0, -smoothness, 0);
            }

            if (Input.gyro.rotationRateUnbiased.x < transform.position.y)
            {
                transform.position += new Vector3(0, -smoothness, 0);
                if (Mathf.Abs(transform.position.y) > Max_Yoffset)
                    transform.position += new Vector3(0, smoothness, 0);
            }
        }
    }
}