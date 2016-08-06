using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// Toggles always start with checked!
public class audioSwitch : MonoBehaviour {
    private Button BGMbut, SFXbut, tutorialButton;
    void Awake()
    {
        BGMbut = GameObject.FindGameObjectWithTag("BGM").GetComponent<Button>();
        SFXbut = GameObject.FindGameObjectWithTag("SFX").GetComponent<Button>();
        tutorialButton = GameObject.FindGameObjectWithTag("CButton").GetComponent<Button>();

        if (PlayerPrefs.GetInt("BGM") == 1)
        {
            BGMbut.GetComponentInChildren<Text>().text = "on";
            AudioListener.pause = false;
        } else {
            BGMbut.GetComponentInChildren<Text>().text = "off";
            AudioListener.pause = true;
        }

        //still need to add controls for SFX
        if (PlayerPrefs.GetInt("SFX") == 1)
            SFXbut.GetComponentInChildren<Text>().text = "on";
        else
            SFXbut.GetComponentInChildren<Text>().text = "off";

        if(PlayerPrefs.GetInt("Tutorial") == 1)
            tutorialButton.GetComponentInChildren<Text>().text = "on";
        else
            tutorialButton.GetComponentInChildren<Text>().text = "off";
    }

    public void BGMControl ()
    {
        if (AudioListener.pause)
        {
            AudioListener.pause = false;
            PlayerPrefs.SetInt("BGM", 1);
            BGMbut.GetComponentInChildren<Text>().text = "on";
        }
        else
        {
            AudioListener.pause = true;
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

    public void tutorial()
    {
        if (tutorialButton.GetComponentInChildren<Text>().text == "on")
        {
            PlayerPrefs.SetInt("Tutorial", 0);
            tutorialButton.GetComponentInChildren<Text>().text = "off";
        }
        else
        {
            PlayerPrefs.SetInt("Tutorial", 1);
            tutorialButton.GetComponentInChildren<Text>().text = "on";
        }

    }

}
