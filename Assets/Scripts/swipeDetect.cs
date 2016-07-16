using UnityEngine;
using System.Collections;

public enum Swipe { None, Up, Down, Left, Right };

public class swipeDetect : MonoBehaviour 
{

	public float minSwipeLength = 200f;
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	//Based on the swipe direction we will change the characters row (river row)
	public static Swipe swipeDirection;

	// Update is called once per frame
	void Update () 
	{
		detectSwipe();
	}
	public void detectSwipe ()
	{
		if (Input.touches.Length > 0) {
			Touch t = Input.GetTouch(0);

			if (t.phase == TouchPhase.Began) {
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
				if (currentSwipe.y > 0 &&( currentSwipe.x > -0.5f || currentSwipe.x < 0.5f)) 
				{
					swipeDirection = Swipe.Up;
					// Swipe down
				} 
				else if (currentSwipe.y < 0 && (currentSwipe.x > -0.5f || currentSwipe.x < 0.5f)) 
				{
					swipeDirection = Swipe.Down;
					// Swipe left
				} 
				else if (currentSwipe.x < 0 && (currentSwipe.y > -0.5f || currentSwipe.y < 0.5f)) 
				{
					swipeDirection = Swipe.Left;
					// Swipe right
				} 
				else if (currentSwipe.x > 0 && (currentSwipe.y > -0.5f || currentSwipe.y < 0.5f))
				{
					swipeDirection = Swipe.Right;
				}
			}
		} 
		else 
		{
			swipeDirection = Swipe.None;   
		}
	}
}
