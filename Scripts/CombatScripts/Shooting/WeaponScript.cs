using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
	//--------------------------------
	// 1 - Designer variables
	//--------------------------------

	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform shotPrefab;

	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public float shootingRate = 0.25f;

	//--------------------------------
	// 2 - Cooldown
	//--------------------------------

	private float shootCooldown;

	void Start()
	{
		shootCooldown = 0f;
	}
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}

	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------

	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;

			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;
			Physics2D.IgnoreCollision(shotTransform.GetComponent<Collider2D>(), GetComponent<Collider2D>());

			// Assign position
			Vector3 substitute = transform.position;
			double y = 0.4;

			substitute.y += -(float)y;

			shotTransform.position = substitute;

			// The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();

			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}

		}
	}

	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}
