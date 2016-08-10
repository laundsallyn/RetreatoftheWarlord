using UnityEngine;
using System.Collections;

public class DisableCanvas : MonoBehaviour {
    public GameObject screen, tutorial;

	public void resume()
    {     
        print("Resuming");

        screen.SetActive(false);
        PlayerPrefs.SetInt("Pause", 0);
        PlayerPrefs.Save();
        GameObject.Find("EnemyPoints").GetComponent<enemySpawnBehavior>().invokeRepeat();
        Time.timeScale= GameObject.Find("EnemyPoints").GetComponent<enemySpawnBehavior>().newTimeScale;
    }
    public void pauseGame()
    {     

        print("Pause Button Clicked");
        screen.SetActive(true);
        PlayerPrefs.SetInt("Pause", 1);
        PlayerPrefs.Save();
        Time.timeScale= 0;
    }
    void Awake()
    {
        print("Awake is called");
        screen.SetActive(false);
        if (PlayerPrefs.GetInt("Tutorial") == 0)
            dismissTutorial();
    }

    public void dismissTutorial()
    {
        tutorial.SetActive(false);
    }
}
