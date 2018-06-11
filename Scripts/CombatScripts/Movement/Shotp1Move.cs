using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotp1Move : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);

	int direction = findDirection();

	public static int findDirection()
	{
		int dir = 1;

		if(CP1Move.facingRight == true)
		{
			dir = 1;
		}
		else if(CP1Move.facingRight == false)
		{
			dir = -1;
		}

		return dir;
	}

	private Vector2 movement;

	// Update is called once per frame
	void Update () 
	{
		Debug.Log (CP1Move.facingRight);

		movement = new Vector2 (
			speed.x * direction, speed.y * 0);
	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody2D> ().velocity = movement;
	}
}
