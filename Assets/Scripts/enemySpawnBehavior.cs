using UnityEngine;
using System.Collections;

public class enemySpawnBehavior : MonoBehaviour 
{
	public GameObject enemyPerfab;
	private enemyCode code;
	private GameObject[] enemySpawns = new GameObject[5];
	// Use this for initialization
	void Start() 
	{
		 code = GameObject.Find("EnemyCodeHolder").GetComponent<enemyCode>();
		 if(code == null)
		 	Debug.Log("Enemy Code not Found");
	
		 for(int n = 0; n < enemySpawns.Length; ++n)
		 {
		 	enemySpawns[n] = GameObject.Find("EnemySpawn" + (n+1));
		 }
		 InvokeRepeating("spawnEnemy", 2, 1);
	}
	
	// Update is called once per frame
	void Update() 
	{

	}
	public void spawnEnemy()
	{
		int spawnIndex = Random.Range(0,5);
		// Debug.Log("EnemySpawning at " + spawnIndex);
		if(enemySpawns[spawnIndex] != null)
		{
			enemyPerfab.GetComponent<enemyCode>().spawn = enemySpawns[spawnIndex];
			enemyPerfab.GetComponent<enemyCode>().spawnIndex = spawnIndex;
			Instantiate(enemyPerfab, (enemySpawns[spawnIndex].transform.position + new Vector3(.7f,.8f,0)), enemySpawns[spawnIndex].transform.rotation);
		}

	}
}
