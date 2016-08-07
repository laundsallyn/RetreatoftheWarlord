using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// Toggles always start with checked!
public class audioSwitch : MonoBehaviour {
    Button BGMbut,SFXbut;
    void Awake()
    {
        BGMbut = GameObject.FindGameObjectWithTag("BGM").GetComponent<Button>();
        SFXbut = GameObject.FindGameObjectWithTag("SFX").GetComponent<Button>();

        if (PlayerPrefs.GetInt("BGM") == 1)
        {
            BGMbut.GetComponentInChildren<Text>().text = "on";
            // Camera.main.GetComponent<AudioSource>().Play();
            Camera.main.GetComponent<AudioSource>().mute = false;

        } 
        else 
        {
            BGMbut.GetComponentInChildren<Text>().text = "off";
            // AudioListener.pause = true;
            Camera.main.GetComponent<AudioSource>().mute = true;
        }

        //still need to add controls for SFX
        if (PlayerPrefs.GetInt("SFX") == 1)
        {
            SFXbut.GetComponentInChildren<Text>().text = "on";
        }
        else
        {
            SFXbut.GetComponentInChildren<Text>().text = "off";
        }
    }

    public void BGMControl ()
    {
        if (BGMbut.GetComponentInChildren<Text>().text.Equals("off"))
        {
            // AudioListener.pause = false;
            Camera.main.GetComponent<AudioSource>().mute = false;
            PlayerPrefs.SetInt("BGM", 1);
            BGMbut.GetComponentInChildren<Text>().text = "on";
        }
        else
        {
            // AudioListener.pause = true;
            Camera.main.GetComponent<AudioSource>().mute = true;
            PlayerPrefs.SetInt("BGM", 0);
            BGMbut.GetComponentInChildren<Text>().text = "off";
        }
        PlayerPrefs.Save();
    }

    public void SFXControl()
    {
        if (SFXbut.GetComponentInChildren<Text>().text == "on") {
            PlayerPrefs.SetInt("SFX", 0);
            SFXbut.GetComponentInChildren<Text>().text = "off";
        }
        else
        {
            PlayerPrefs.SetInt("SFX", 1);
            SFXbut.GetComponentInChildren<Text>().text = "on";
        }
        
    }

}
