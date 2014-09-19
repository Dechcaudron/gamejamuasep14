using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float jumpSpeed = 5.0f;
	public float runSpeed = 10.0f;
	float xSpeed = 0.0f;
	float ySpeed = 0.0f;
	bool canJump = true;
	bool doubleJumpUnlocked = true;
	bool canDoubleJump = true;
	CharacterController controller;
	
	// Use this for initialization
	void Start ()
	{
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (controller.isGrounded) {
			canJump = true;
			canDoubleJump = true;
		} else {
			//canJump = false;
		}
		
		if (canJump && Input.GetButtonDown ("Jump")) {
			ySpeed = controller.velocity.y + jumpSpeed;
			canJump = false;
		} else if (doubleJumpUnlocked) {
			if (canDoubleJump && Input.GetButtonDown ("Jump")) {
				ySpeed = controller.velocity.y/2 + jumpSpeed;
				canDoubleJump = false;
			}
		}

		ySpeed += Physics.gravity.y * Time.deltaTime;
		xSpeed = runSpeed * Input.GetAxis ("Horizontal");
		
		controller.Move (new Vector3 (xSpeed, ySpeed) * Time.deltaTime);
		
	}
}
