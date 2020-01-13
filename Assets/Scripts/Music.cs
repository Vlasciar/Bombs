using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    AudioSource audio;
    bool is_Transitioning_In;
    bool is_Transitioning_Out;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 0;

        Sound_Track_0();
        is_Transitioning_In = true;
    }

    void Update()
    {
        if(is_Transitioning_In)
        {
            Transition_In();
        }
        else if (is_Transitioning_Out)
        {
            Transition_Out();
        }
        if (Game_Controller.Game_Lost && audio.clip != Track_0)
        {
            if(audio.volume != 0)
            {
                is_Transitioning_Out = true;
            }
            else if(!IsInvoking("Sound_Track_0"))
            {
                Invoke("Sound_Track_0", 0.66f);
            }           
        }
        else if(Input.touchCount == 2 && !Game_Controller.Game_Lost) //if game started
        {
            if(Game_Controller.Score < 35 && audio.clip != Track_1)
            {
                if (audio.volume != 0)//transition out
                {
                    is_Transitioning_Out = true;
                }
                else//after transition play next track
                {
                    Sound_Track_1();
                }
            }
            else if (Game_Controller.Score < 110 && Game_Controller.Score >=35 && audio.clip != Track_2)
            {
                if (audio.volume != 0)
                {
                    is_Transitioning_Out = true;
                }
                else
                {
                    Sound_Track_2();
                }
            }
            else if(Game_Controller.Score >= 110 && audio.clip != Track_3)
            {
                if (audio.volume != 0)
                {
                    is_Transitioning_Out = true;
                }
                else
                {
                    Sound_Track_3();
                }
            }
        }       
        if (Master_Volume.Volume_Status && (Master_Volume.Volume_Status != last_frame_vol_stat))
        {
            audio.volume = Volume_Music;
        }
        if (!Master_Volume.Volume_Status)
        {
            audio.volume = 0;
        }
        last_frame_vol_stat = Master_Volume.Volume_Status;
    }
    bool last_frame_vol_stat = true;
    public float Volume_Music;
    void Transition_In()
    {
        is_Transitioning_Out = false;
        if (audio.volume < Volume_Music)
        {
            audio.volume += Volume_Music / 100;
        }
        else
        {
            is_Transitioning_In = false;
        }
    }
    void Transition_Out()
    {
        is_Transitioning_In = false;
        if (audio.volume > 0)
        {
            audio.volume -= Volume_Music / 50;
        }
        else
        {
            is_Transitioning_Out = false;
        }
    }
    public AudioClip Track_0;
    void Sound_Track_0()
    {
            audio.clip = Track_0;
            audio.Play(0);
            is_Transitioning_In = true;                
    }


    public AudioClip Track_1;
    void Sound_Track_1()
    {

            audio.clip = Track_1;
            audio.Play(0);
            is_Transitioning_In = true;
    }

    public AudioClip Track_2;
    void Sound_Track_2()
    {
            audio.clip = Track_2;
            audio.Play(0);
            is_Transitioning_In = true;
    }


    public AudioClip Track_3;
    void Sound_Track_3()
    {
            audio.clip = Track_3;
            audio.Play(0);
            is_Transitioning_In = true;
    }
}
