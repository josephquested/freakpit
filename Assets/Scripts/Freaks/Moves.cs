using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour {
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
		if (horizontal != 0 || vertical != 0)
		{
			if (canMove)
			{
				animator.speed = 1;
				Move();
			}
		}
		else
		{
			animator.speed = 0;
		}
	}

	void Move ()
	{
		Vector2 movement = GetMovementVector(facing.direction);
		rb.AddForce(movement * speed);
	}

	Vector2 GetMovementVector (int newDirection)
	{
		Vector2 movementVector = new Vector2(0, 0);
		if (newDirection == 0) movementVector = new Vector2(0, 1);
		if (newDirection == 1) movementVector = new Vector2(1, 0);
		if (newDirection == 2) movementVector = new Vector2(0, -1);
		if (newDirection == 3) movementVector = new Vector2(-1, 0);
		return movementVector;
	}
}
