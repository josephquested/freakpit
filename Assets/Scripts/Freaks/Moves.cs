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
				Move(horizontal, vertical);
			}
		}
		else
		{
			animator.SetBool("moving", false);
		}
	}

	void Move (float horizontal, float vertical)
	{
		if (facing.strafing)
		{
			rb.AddForce(GetVectorFromFloats(horizontal, vertical) * speed);
		}
		else
		{
			rb.AddForce(facing.GetFacingVector() * speed);
		}
	}

	Vector2 GetVectorFromFloats (float horizontal, float vertical)
	{
		if (vertical == 1) return new Vector2(0, 1);
		if (horizontal == 1) return new Vector2(1, 0);
		if (vertical == -1) return new Vector2(0, -1);
		if (horizontal == -1) return new Vector2(-1, 0);
		return Vector2.zero;
	}
}
