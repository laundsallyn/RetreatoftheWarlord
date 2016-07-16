using UnityEngine;
using System.Collections;

public class audioSwitch : MonoBehaviour {

    // Use this for initialization


    public void audioControl () {
        if (AudioListener.pause)
            AudioListener.pause = false;
        else
            AudioListener.pause = true;
    }
}
