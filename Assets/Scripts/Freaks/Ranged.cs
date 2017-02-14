using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour {
	Moves moves;
	Animator animator;
	Facing facing;

	bool canShoot = true;

	public GameObject projectilePrefab;
	public float damage;
	public float knockback;
	public float cooldown;
	public float attackDuration;
	public float projectileSpeed;

	void Start ()
	{
		moves = gameObject.GetComponent<Moves>();
		animator = GetComponent<Animator>();
		facing = GetComponent<Facing>();
	}

	public void ReceiveInput ()
	{
		if (canShoot)
		{
			StartCoroutine(ShootRoutine());
		}
	}

	IEnumerator ShootRoutine ()
	{
		moves.canMove = false;
		facing.canTurn = false;
		animator.SetBool("attacking", true);

		Shoot();
		yield return new WaitForSeconds(attackDuration);

		moves.canMove = true;
		facing.canTurn = true;
		animator.SetBool("attacking", false);
	}

	void Shoot ()
	{
		var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
		// projectile.GetComponent<Bullet>().ReceiveData(damage, transform, knockback);
		projectile.GetComponent<Rigidbody2D>().AddForce(facing.GetFacingVector() * projectileSpeed);
	}
}
