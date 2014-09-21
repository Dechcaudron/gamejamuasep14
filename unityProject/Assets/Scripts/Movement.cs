using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

		public float jumpSpeed = 5.0f;
		public float runSpeed = 10.0f;
		public GameObject prota;
		private Animator myAnimator;
		float xSpeed = 0.0f;
		float ySpeed = 0.0f;
		bool canJump = true;
		bool doubleJumpUnlocked = true;
		bool canDoubleJump = true;
		bool isFacingRight;
		CharacterController controller;
		public StepBehaviour MyStepBehaviour;
	
		// Use this for initialization
		void Start ()
		{
				controller = GetComponent<CharacterController> ();
				myAnimator = prota.GetComponent<Animator> ();
				myAnimator.SetBool ("isFacingRight", true);
		}
	
		// Update is called once per frame
		void Update ()
		{
		
				if (controller.isGrounded) {
						canJump = true;
						canDoubleJump = true;
						ySpeed = 0;
				} else {
						//canJump = false;
				}
		
				if (canJump && Input.GetButtonDown ("Jump")) {
						ySpeed = controller.velocity.y + jumpSpeed;
						canJump = false;
						myAnimator.SetTrigger ("startJump");
				} else if (doubleJumpUnlocked) {
						if (canDoubleJump && Input.GetButtonDown ("Jump")) {
								ySpeed = jumpSpeed;
								canDoubleJump = false;
								myAnimator.SetTrigger ("startJump");
						}
				}

				ySpeed += Physics.gravity.y * Time.deltaTime;
				xSpeed = runSpeed * Input.GetAxis ("Horizontal");
				myAnimator.SetFloat ("protaSpeed", xSpeed);
		
				controller.Move (new Vector3 (xSpeed, ySpeed) * Time.deltaTime);
				if (controller.isGrounded) {
						myAnimator.SetBool ("isFalling", false);
						if (xSpeed < -0.5) {
								//myAnimator.SetBool ("isFacingRight", false);

						} else if (xSpeed > 0.5) {
								//myAnimator.SetBool ("isFacingRight", true);

						} else if (xSpeed == 0) {

						}

						

				} else {
						if (controller.velocity.y < -0.05) {
								myAnimator.SetBool ("isFalling", true);

						}
				}
		}

		void FixedUpdate ()
		{
				transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		}

		void OnTriggerEnter (Collider a_collider)
		{
				if (a_collider.tag == "WaterMass") {
						MyStepBehaviour.WalkingOnWater = true;
				}
		}
	
		void OnTriggerExit (Collider a_collider)
		{
				if (a_collider.tag == "WaterMass") {
						MyStepBehaviour.WalkingOnWater = false;
				}
		}
}
