using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class p1Health : MonoBehaviour {

	public float maxHealth;
	//when connecting, call the currenthealth from the HoldData script in other scene
	public float currentHealth;
	public bool isEnemy;
	public Slider healthBar;


	public GameObject damageBurst;
	public GameObject damageNumber;



	// Use this for initialization
	void Start () {
		maxHealth = GetUnitStats.p1Health;
		currentHealth = maxHealth;
		healthBar.value = calculateHealth();
	}

	public float calculateHealth()
	{
		return currentHealth / maxHealth;
	}

	public void Damage( float damage)
	{
		currentHealth = currentHealth - damage;
		if (damageNumber != null) {
		//	clone.GetComponent<FloatingNumbers> ().damageNumber = damage;
			var dn = Instantiate(damageNumber);
			dn.GetComponent<FloatingNumbers> ().damageNumber = damage;
			dn.transform.position = transform.position;
			dn.transform.rotation = Quaternion.Euler (Vector3.zero);
		}
		Instantiate (damageBurst, transform.position, transform.rotation);

	}

	void OnTriggerEnter2D( Collider2D otherCollider)
	{
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();

		if (shot != null) {
			if (shot.isEnemyShot != isEnemy) {
				Damage (shot.damage);
				Destroy (shot.gameObject);
			}
		}
	}
	public void Death()
	{
		if (currentHealth <= 0) {
			Debug.Log ("Dead");
		}
	}
	// Update is called once per frame
	void Update () {
		healthBar.value = calculateHealth ();

		//Death ();
	}
}
