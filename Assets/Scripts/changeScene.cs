using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class changeScene : MonoBehaviour {

    public void nextScene(string scene)
    {
        if(GameObject.Find("HIT")!= null && !(scene.Equals("GameOver")))
            Destroy(GameObject.Find("HIT"));        
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
