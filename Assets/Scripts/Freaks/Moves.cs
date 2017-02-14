using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Moves : NetworkBehaviour {
	Rigidbody2D rb;
	Animator animator;
	Facing facing;

	public float speed;
	public bool canMove;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
		animator = GetComponent<Animator>();
		facing = GetComponent<Facing>();
	}

	public void ReceiveInput (float horizontal, float vertical)
	{
		if (!isLocalPlayer) return;
		if (horizontal != 0 || vertical != 0)
		{
			if (canMove)
			{
				animator.SetBool("moving", true);
				Move();
			}
		}
		else
		{
			animator.SetBool("moving", false);
		}
	}

	void Move ()
	{
		Vector2 movement = facing.GetFacingVector();
		rb.AddForce(movement * speed);
	}
}
