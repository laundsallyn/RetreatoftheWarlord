using UnityEngine;
using System.Collections;

public class checkSetting : MonoBehaviour
{
    void Awake()
    {
        if (PlayerPrefs.GetInt("BGM") == 1)
        {
            Camera.main.GetComponent<AudioSource>().Play();
            // AudioListener.pause = false;
        }
        else 
        {
            Camera.main.GetComponent<AudioSource>().Pause();
            // AudioListener.pause = true;
        }
    }

}
