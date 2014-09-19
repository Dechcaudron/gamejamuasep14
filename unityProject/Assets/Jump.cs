using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float speed=5.0f;
	float ySpeed=0.0f;
	bool canJump=true;
	bool doubleJumpUnlocked=true;
	bool canDoubleJump=true;
	CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

		if (controller.isGrounded) {
						canJump = true;
						canDoubleJump = true;
				} else {
						//canJump = false;
				}
	
		if (canJump && Input.GetButtonDown ("Jump")) {
						ySpeed = controller.velocity.y+speed;
						canJump = false;
		} else if (doubleJumpUnlocked) {
			if (canDoubleJump && Input.GetButtonDown ("Jump")) {
				ySpeed = controller.velocity.y+speed;
				canDoubleJump = false;
			}
		}
		ySpeed += Physics.gravity.y * Time.deltaTime;

		controller.Move(new Vector3(0.0f , ySpeed) * Time.deltaTime);

	}

}
