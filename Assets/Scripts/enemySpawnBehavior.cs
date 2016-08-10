using UnityEngine;
using System.Collections;

public class enemySpawnBehavior : MonoBehaviour 
{
	public GameObject[] enemyPerfabs = new GameObject[2];
	private enemyCode code;
	private GameObject[] enemySpawns = new GameObject[5];
	public float newTimeScale;
	private int numberofMinutes;
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
		 //Spawn rate 
		 InvokeRepeating("spawnEnemy", 3, 1.75f);
		 numberofMinutes = 1;
		 newTimeScale = 1;
	}
	
	public void invokeRepeat()
	{
		InvokeRepeating("spawnEnemy", 0.5f, 1.75f);
	}
	// Update is called once per frame
	void Update() 
	{
		if(PlayerPrefs.GetInt("Pause")==1)
			CancelInvoke();

		if(Time.time> 50.0f*numberofMinutes )
        {
            newTimeScale = newTimeScale +  0.2f;
            Time.timeScale = newTimeScale;
            numberofMinutes +=1;
        }
	}
	public void spawnEnemy()
	{
		int spawnIndex = Random.Range(0,5);
		int typeEnemy = Random.Range(0,2);
		Vector3 offset;
		if(typeEnemy==1)
			offset = new Vector3(0,0.25f,0);
		else
			offset = new Vector3(0,0,0);
		// Debug.Log("EnemySpawning at " + spawnIndex);
		if(enemySpawns[spawnIndex] != null)
		{
			enemyPerfabs[typeEnemy].GetComponent<enemyCode>().spawn = enemySpawns[spawnIndex];
			enemyPerfabs[typeEnemy].GetComponent<enemyCode>().spawnIndex = spawnIndex;
			Instantiate(enemyPerfabs[typeEnemy], (enemySpawns[spawnIndex].transform.position+offset), enemySpawns[spawnIndex].transform.rotation);
		}

	}
}
