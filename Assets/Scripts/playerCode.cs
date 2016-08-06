using UnityEngine;
using System.Collections;

public class playerCode : MonoBehaviour {

	// Use this for initialization
	//All the preset points the player can be located at
	private GameObject[] spawnPoints = new GameObject[5];
	//Current position the player is 
	public int currentSpawnIndex;
	void Start () 
	{
		string spawnName = "Spawn";
		for(int n = 0; n < spawnPoints.Length; ++n)
		{
			spawnName = "Spawn" + (n+1);
			spawnPoints[n] = GameObject.Find(spawnName);
		}
		this.transform.position = (spawnPoints[currentSpawnIndex].transform.position + new Vector3(0,.5f,0));

		
				
	}
	public int getSpawnIndex()
	{
		return currentSpawnIndex;
	}
	public void setSpawnIndex(int indexNew)
	{
		currentSpawnIndex = indexNew;
	} 
	public GameObject[] getSpawnPoints()
	{
		return spawnPoints;
	}
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnCollisionEnter(Collision col)
	{
		// Debug.	Log(col.gameObject.name);
		if(col.gameObject.name == "Enemy1(Clone)" ||col.gameObject.name == "Enemy2(Clone)" )
		{
			GameObject.Find("HIT").GetComponent<AudioSource>().Play();
			GameObject.Find("Main Camera").GetComponent<changeScene>().nextScene("GameOver");	
			// Debug.Break();	
		}
	}
}
