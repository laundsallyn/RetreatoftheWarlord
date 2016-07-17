using UnityEngine;
using System.Collections;

public class playerCode : MonoBehaviour {

	// Use this for initialization
	//All the preset points the player can be located at
	private GameObject[] spawnPoints = new GameObject[5];
	//Current position the player is 
	private int currentSpawnIndex;
	void Start () 
	{
		string spawnName = "Spawn";
		for(int n = 0; n < spawnPoints.Length; ++n)
		{
			spawnName = "Spawn" + (n+1);
			spawnPoints[n] = GameObject.Find(spawnName);
		}
		currentSpawnIndex = 0;
		this.transform.position = spawnPoints[currentSpawnIndex].transform.position;
		
				
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
}
