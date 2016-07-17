using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Toggles always start with checked!
public class audioSwitch : MonoBehaviour {
    Toggle BGMtog,SFXtog;
    Scene now;
    void Awake()
    {
        bool inSettings = now.name == "Settings";
        now = SceneManager.GetActiveScene();
        if(inSettings)
        {
            BGMtog = GameObject.FindGameObjectWithTag("BGM").GetComponent<Toggle>();
            SFXtog = GameObject.FindGameObjectWithTag("SFX").GetComponent<Toggle>();
        }


        //Debug.Log("This is BGMtog");
        //Debug.Log("This is SFXtog");

        if (PlayerPrefs.GetInt("BGM") == 1)
        {
            if(inSettings)
                BGMtog.isOn = false;
            AudioListener.pause = false;
        }
        else {
            if (inSettings)
                BGMtog.isOn = false;
            AudioListener.pause = true;

        }

        //still need to add controls for SFX
        if (PlayerPrefs.GetInt("SFX") == 1)
            if (inSettings)
                SFXtog.isOn = true;
        else
            if (inSettings)
                SFXtog.isOn = false;
    }

    public void BGMControl ()
    {
        if (AudioListener.pause)
        {
            AudioListener.pause = false;
            PlayerPrefs.SetInt("BGM", 1);
        }
        else
        {
            AudioListener.pause = true;
            PlayerPrefs.SetInt("BGM", 0);
        }
        PlayerPrefs.Save();
    }

    public void SFXControl()
    {
        if (SFXtog.isOn)
        {
            PlayerPrefs.SetInt("SFX", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SFX", 0);

        }
    }

}
