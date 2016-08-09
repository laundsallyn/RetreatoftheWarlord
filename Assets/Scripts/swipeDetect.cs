using UnityEngine;
using System.Collections;

public enum Swipe { None, Up, Down, Left, Right };

public class swipeDetect : MonoBehaviour 
{

	public float minSwipeLength = 200f;
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;
	public GameObject player;
	private playerCode playerCode; 
	public Vector3 offset;
	//Based on the swipe direction we will change the characters row (river row)
	public static Swipe swipeDirection;


	void Start()
	{
	}

	// Update is called once per frame
	void Update () 
	{
		detectSwipe();
		if(swipeDirection != Swipe.None)
			handleCharacter();
	}
	public void detectSwipe ()
	{
		if(PlayerPrefs.GetInt("Pause")==1)
		{
			swipeDirection = Swipe.None;
			return;
		}
		if (Input.touches.Length > 0) 
		{
			Touch t = Input.GetTouch(0);

			if (t.phase == TouchPhase.Began) 
			{
				firstPressPos = new Vector2(t.position.x, t.position.y);
			}

			if (t.phase == TouchPhase.Ended) 
			{
				secondPressPos = new Vector2(t.position.x, t.position.y);
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

				// Make sure it was a legit swipe, not a tap
				if (currentSwipe.magnitude < minSwipeLength) 
				{
					swipeDirection = Swipe.None;
					return;
				}

				currentSwipe.Normalize();

				// Swipe up
				if (currentSwipe.y > 0 &&( currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)) 
				{
					swipeDirection = Swipe.Up;
					// Swipe down
				} 
				else if (currentSwipe.y < 0 && (currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)) 
				{
					swipeDirection = Swipe.Down;
					// Swipe left
				} 
				else if (currentSwipe.x < 0 && (currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)) 
				{
					swipeDirection = Swipe.Left;
					// Swipe right
				} 
				else if (currentSwipe.x > 0 && (currentSwipe.y > -0.5f && currentSwipe.y < 0.5f))
				{
					swipeDirection = Swipe.Right;
				}

	
			}
		} 
		else 
		{
			  if(Input.GetMouseButtonDown(0))
     {
         //save began touch 2d point
        firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
     }
		if(Input.GetMouseButtonUp(0))
     {
            //save ended touch 2d point
        secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
       
            //create vector from the two points
        currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
           
        //normalize the 2d vector
        currentSwipe.Normalize();
 
        //swipe upwards
        if (currentSwipe.y > 0 &&( currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)) 
        {
        	swipeDirection = Swipe.Up;
            // Debug.Log("up swipe");
        }
        //swipe down
        else if (currentSwipe.y < 0 && (currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)) 
        {
        	swipeDirection = Swipe.Down;
            // Debug.Log("down swipe");
        }
        //swipe left
        else if (currentSwipe.x < 0 && (currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)) 
        {
        	swipeDirection = Swipe.Left;
            // Debug.Log("left swipe");
        }
        //swipe right
       else if (currentSwipe.x > 0 && (currentSwipe.y > -0.5f && currentSwipe.y < 0.5f))
        {
        	swipeDirection = Swipe.Right;
            // Debug.Log("right swipe");
        }
    }
    	else{
			swipeDirection = Swipe.None;   
    	}
		}
	}
	public void handleCharacter()
	{

		playerCode playerC = player.GetComponent<playerCode>();
		int tempIndex = playerC.getSpawnIndex();


		if(tempIndex == 0 && swipeDirection == Swipe.Up)
		{
			//Do nothing
		}
		else if(tempIndex == 4 && swipeDirection == Swipe.Down)
		{
			//Do Nothing
		}
		else if(swipeDirection == Swipe.Down)
		{
			player.GetComponent<AudioSource>().Play();
			tempIndex++;
		}
		else if(swipeDirection == Swipe.Up)
		{
			player.GetComponent<AudioSource>().Play();
			tempIndex--;
		}
		//Animate later
		Debug.Log(tempIndex);
		player.transform.position = (playerC.getSpawnPoints()[tempIndex].transform.position + offset);
		playerC.setSpawnIndex(tempIndex);
		
    }

}
