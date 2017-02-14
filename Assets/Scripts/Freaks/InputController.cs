using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class InputController : NetworkBehaviour {
	Moves moves;
	Ranged ranged;
	Facing facing;

	void Start ()
	{
		moves = GetComponent<Moves>();
		ranged = GetComponent<Ranged>();
		facing = GetComponent<Facing>();
	}

	void FixedUpdate ()
	{
		if (!isLocalPlayer) return;
		StrafeInput();
		FacingInput();
		MovementInput();
	}

	void Update ()
	{
		if (!isLocalPlayer) return;
		RangedInput();
	}

	void MovementInput ()
	{
		moves.ReceiveInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void FacingInput ()
	{
		facing.ReceiveTurnInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void StrafeInput ()
	{
		facing.ReceiveStrafeInput(Input.GetButton("Strafe"));
	}

	void RangedInput ()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			ranged.ReceiveInput();
		}
	}
}
