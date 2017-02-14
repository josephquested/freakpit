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
		FacingInput();
		MovementInput();
	}

	void Update ()
	{
		if (!isLocalPlayer) return;
		RangedInput();
	}

	void FacingInput ()
	{
		facing.ReceiveInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void MovementInput ()
	{
		moves.ReceiveInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void RangedInput ()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			print("bang!");
			ranged.ReceiveInput();
		}
	}
}
