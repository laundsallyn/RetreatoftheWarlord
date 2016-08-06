using UnityEngine;
using System.Collections;

public class DisableCanvas : MonoBehaviour {
    public GameObject screen;
    public GameObject tutorial;
	public void resume()
    {
        screen.SetActive(false);
        PlayerPrefs.SetInt("Pause", 0);
        PlayerPrefs.Save();
    }
    public void pauseGame()
    {
        print("Pause Button Clicked");
        screen.SetActive(true);
        PlayerPrefs.SetInt("Pause", 1);
        PlayerPrefs.Save();
    }
    void Awake()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 0)
            tutorial.SetActive(false);
        else
            tutorial.SetActive(true);
        screen.SetActive(false);
    }

    public void dismissTutorial()
    {
            tutorial.SetActive(false);
    }
    // Update is called once per frame
    //void Update()
    //{
    //    if (paused)
    //        screen.SetActive(false);
    //    else
    //        screen.SetActive(true);

    //}
}
