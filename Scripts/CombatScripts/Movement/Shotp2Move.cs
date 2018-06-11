using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotp2Move : MonoBehaviour {
	public Vector2 speed = new Vector2(10, 10);

	int direction = findDirection();

	public static int findDirection()
	{
		int dir = 1;

		if(CP2Move.facingRight == true)
		{
			dir = 1;
		}
		else if(CP2Move.facingRight == false)
		{
			dir = -1;
		}

		return dir;
	}

	private Vector2 movement;

	// Update is called once per frame
	void Update () 
	{

		movement = new Vector2 (
			speed.x * direction, speed.y * 0);
	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody2D> ().velocity = movement;
	}
}
