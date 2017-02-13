using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	Moves moves;
	Facing facing;

	void Start ()
	{
		moves = GetComponent<Moves>();
		facing = GetComponent<Facing>();
	}

	void FixedUpdate ()
	{
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
