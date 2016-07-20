using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class changeScene : MonoBehaviour {

    public void nextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

 /*
    void nextScene(string scene)
    {
        StartCoroutine(wait(scene));
    }
    IEnumerator wait(string scene)
    {
        float fadeTime = GameObject.Find("Option").GetComponent<fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(scene);

    }
    */
}
