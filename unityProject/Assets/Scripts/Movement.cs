using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float jumpSpeed = 5.0f;
	public float runSpeed = 10.0f;
	public GameObject prota;
	
	float xSpeed = 0.0f;
	float ySpeed = 0.0f;
	bool canJump = true;
	bool doubleJumpUnlocked = true;
	bool canDoubleJump = true;
	bool lookingRight = true;
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
			ySpeed=0;
		} else {
			//canJump = false;
		}
		
		if (canJump && Input.GetButtonDown ("Jump")) {
			ySpeed = controller.velocity.y + jumpSpeed;
			canJump = false;
		} 
		else if (doubleJumpUnlocked) {
			if (canDoubleJump && Input.GetButtonDown ("Jump")) {
				ySpeed = jumpSpeed;
				canDoubleJump = false;
			}
		}

		ySpeed += Physics.gravity.y * Time.deltaTime;
		xSpeed = runSpeed * Input.GetAxis ("Horizontal");
		
		controller.Move (new Vector3 (xSpeed, ySpeed) * Time.deltaTime);
		if (controller.isGrounded){
			if (xSpeed < -1){
				lookingRight = false;
				prota.animation.CrossFade("RunLeft",0.25f);
			}
			else if (xSpeed > 1){
				lookingRight = false;
				prota.animation.CrossFade("RunRight",0.25f);
			}
			else if (xSpeed == 0)
			prota.animation.CrossFade("StandBy",0.25f);
		}
		else
			JumpAnimation();

		//Debug.Log(xSpeed);
	}

	void JumpAnimation(){
		if (lookingRight)
			prota.animation.CrossFade("JumpRight",0.25f);
		else
			prota.animation.CrossFade("JumpRight",0.25f);
	}
}
