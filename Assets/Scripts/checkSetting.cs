using UnityEngine;
using System.Collections;

public class checkSetting : MonoBehaviour
{
    void Awake()
    {
        if (PlayerPrefs.GetInt("BGM") == 1)
        {
            AudioListener.pause = false;
        }
        else {
            AudioListener.pause = true;
        }
    }

}
