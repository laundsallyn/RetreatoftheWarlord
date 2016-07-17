using UnityEngine;
using System.Collections;

public class enemyCode : MonoBehaviour
 {

	// Use this for initialization

	public GameObject spawn; // Spawn point for the enemy gameobject
	public int spawnIndex;

	public float interpVelocity;
	public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;

	void Start()
	{
		Debug.Log("Spawn is " + spawnIndex);
		target = GameObject.Find("Spawn"+(spawnIndex+1));	
	}
	
	// Update is called once per frame
	void Update() 
	{
		handleMovement();
		if(gameObject&&transform.position.x > (targetPos+offset).x)
			Destroy(gameObject);
	}
	

	private	void handleMovement()
	{
		 if (target)
         {
             Vector3 posNoZ = transform.position;
  
             Vector3 targetDirection = (target.transform.position - posNoZ);
  
             interpVelocity = targetDirection.magnitude * 2.0f;
  
             targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 
  
             transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.5f);

         }
	}

}
