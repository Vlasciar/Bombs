using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Ups : MonoBehaviour
{
    public static int Star_Count;
    public static int Revive_Cost = 5;
    public TextMesh Stars_Text;
    public TextMesh Revive_Text;
    void Start()
    {
        Controller_Script = GetComponent<Game_Controller>();
        Spawner_Script = GetComponent<Obstacle_Spawner>();
    }
    Obstacle_Spawner Spawner_Script;
    Game_Controller Controller_Script;
    void Update()
    {
        Stars_Text.text = Star_Count.ToString();
        Revive_Text.text = "Revive for: " + Revive_Cost;
        if (Star_Count >= Revive_Cost && Check_Touch.Check("ReviveTag")) 
        {
            Revive_Text.gameObject.GetComponent<Animation>().Play();
            Invoke("Revive", 0.4f);           
        }
    }
    void Revive()
    {
        Pick_Ups.Star_Count -= Revive_Cost;
        Save_System.Save_Player();//saves for star count
        Game_Controller.Game_Running = true;
        Controller_Script.Restart();
        Revive_Cost *= 2;
        Spawner_Script.SpawnRate_Decrement();
    }
}
