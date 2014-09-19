using UnityEngine;
using System.Collections;

public class LateralMovement : MonoBehaviour {

	public float speed=10.0f;
	float xSpeed=0.0f;
	CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		xSpeed = speed * Input.GetAxis ("Horizontal");
		controller.Move(new Vector3(xSpeed, 0.0f) * Time.deltaTime);
	}
}
