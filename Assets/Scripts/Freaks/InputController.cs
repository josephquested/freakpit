using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class InputController : NetworkBehaviour {
	Moves moves;
	Facing facing;

	void Start ()
	{
		moves = GetComponent<Moves>();
		facing = GetComponent<Facing>();
	}

	void FixedUpdate ()
	{
		if (!isLocalPlayer) return;
		FacingInput();
		MovementInput();
	}

	void FacingInput ()
	{
		facing.ReceiveInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void MovementInput ()
	{
		moves.ReceiveInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}
}
