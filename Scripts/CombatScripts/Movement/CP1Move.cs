using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP1Move : MonoBehaviour {

	public static float maxSpeed = 10f;
	public static bool facingRight = true;

	public AudioClip gunShot;
	AudioSource audioSource;

	Animator anim;

	public bool grounded = false;
	private bool hasJumped = false;

	public float jumpForce;


	void Start()
	{
		anim = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
		Debug.Log ("P1: " + GetUnitStats.p1Anim);

		anim.runtimeAnimatorController = Resources.Load (GetUnitStats.p1Anim) as RuntimeAnimatorController;

	}

	void Update()
	{
		if (Countdown.canBegin == true)
		{
			if (!grounded && GetComponent<Rigidbody2D> ().velocity.y == 0) {
				grounded = true;
			}

			if(Input.GetButtonDown("P1-A-Button") && grounded == true){
				Debug.Log ("Key Pressed");
				hasJumped = true;
			}

			if (hasJumped) {
				GetComponent<Rigidbody2D> ().AddForce (transform.up * jumpForce);
				grounded = false;
				hasJumped = false;
			}

			// 5 - Shooting
			bool shoot = Input.GetButtonDown("P1-B-Button");
			shoot |= Input.GetButtonDown("Fire2");
			// Careful: For Mac users, ctrl + arrow is a bad idea

			if (shoot)
			{
				audioSource.PlayOneShot (gunShot, 0.2f);
				WeaponScript weapon = GetComponent<WeaponScript>();
				if (weapon != null)
				{
					// false because the player is not an enemy
					weapon.Attack(false);
				}
			}
		}



	}

	void FixedUpdate()
	{
		if (Countdown.canBegin == true) 
		{
			float move = Input.GetAxis ("HorizontalP1");
			if (move != 0) {
				anim.SetBool ("isWalking", true);
				anim.SetFloat ("input_x", move);

			} else {
				anim.SetBool ("isWalking", false);
			}
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);


			if (move > 0 && !facingRight) {
				Flip ();
			} 
			else if (move < 0 && facingRight) {
				Flip ();
			}
		}


	

	}

	public void Flip()
	{
		facingRight = !facingRight;

	}

}

