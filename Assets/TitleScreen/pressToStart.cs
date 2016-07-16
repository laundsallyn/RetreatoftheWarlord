using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pressToStart : MonoBehaviour {

public void changeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
