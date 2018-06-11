using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

	public int damage = 10;

	public bool isEnemyShot = false;

	void DecideDamage()
	{
		if (transform.name == "Shot(Clone)") {
			Debug.Log("HIT");
			damage = GetUnitStats.p1Damage;
		} else if (transform.name == "Shot2(Clone)") {
			damage = GetUnitStats.p2Damage;

		}
	}

	void Start()
	{
		DecideDamage ();
	}


	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 5);
	}
}
