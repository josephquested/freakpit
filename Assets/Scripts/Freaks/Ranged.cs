using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Ranged : NetworkBehaviour {
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
		canShoot = false;
		moves.canMove = false;
		facing.canTurn = false;
		animator.SetBool("attacking", true);

		CmdShoot(facing.GetFacingVector());
		yield return new WaitForSeconds(attackDuration);

		canShoot = true;
		moves.canMove = true;
		facing.canTurn = true;
		animator.SetBool("attacking", false);
	}

	[Command]
	void CmdShoot (Vector2 direction)
	{
		var projectile = (GameObject)Instantiate(projectilePrefab, transform.position, transform.rotation);
		projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
		NetworkServer.Spawn(projectile);
		Destroy(projectile, 2.0f);
	}
}
