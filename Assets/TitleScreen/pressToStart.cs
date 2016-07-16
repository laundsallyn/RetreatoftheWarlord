using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pressToStart : MonoBehaviour {

public void nextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
