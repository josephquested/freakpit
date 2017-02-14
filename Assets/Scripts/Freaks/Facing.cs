using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class Facing : NetworkBehaviour {
	Animator animator;

	public int direction;
	public bool canTurn;
	public bool strafing;

	void Start ()
	{
		animator = GetComponent<Animator>();
	}

	void Update ()
	{
		if (!isLocalPlayer || !canTurn || strafing) return;
		UpdateAnimator();
	}

	public void ReceiveTurnInput (float horizontal, float vertical)
	{
		if (!canTurn || strafing) return;
		if (vertical == 1) direction = 0;
		if (horizontal == 1) direction = 1;
		if (vertical == -1) direction = 2;
		if (horizontal == -1) direction = 3;
	}

	public void ReceiveStrafeInput (bool strafe)
	{
		strafing = strafe;
	}

	void UpdateAnimator ()
	{
		animator.SetInteger("direction", direction);
	}

	public Vector2 GetFacingVector ()
	{
		if (direction == 0) return new Vector2(0, 1);
		if (direction == 1) return new Vector2(1, 0);
		if (direction == 2) return new Vector2(0, -1);
		if (direction == 3) return new Vector2(-1, 0);
		else return Vector2.zero;
	}
}
