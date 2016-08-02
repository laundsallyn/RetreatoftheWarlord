using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {

	// Use this for initialization


    public void pauseGame()
    {
        if (Time.timeScale == 1.0F)
            Time.timeScale = 0F;
        else
            Time.timeScale = 1.0F;
    }
}

