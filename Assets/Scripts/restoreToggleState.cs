using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class restoreToggleState : MonoBehaviour
{
    
    public void restoreState(string toggleName)
    {
        Toggle tog = GameObject.Find(toggleName).GetComponent<Toggle>();
        if (PlayerPrefs.GetInt("mute") == 1)
            tog.isOn = false;
        else
            tog.isOn = true;
            
    }
}
