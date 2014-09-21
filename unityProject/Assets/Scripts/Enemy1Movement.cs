using UnityEngine;
using System.Collections;

public class Enemy1Movement : MonoBehaviour
{

		public float Speed = 1.0f;
		float counter = 0.0f;
		public GameObject[] wayPoints;
		int i = 0;
		public GameObject animator;


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

				RaycastHit hit;
				Ray ray = new Ray (transform.position, Vector3.down);
				if (Physics.Raycast (ray, out hit, 2.0f)) {
						Debug.Log (hit.distance);

						//rigidbody.AddForce(-hit.normal *0.1f* Time.deltaTime);
			//transform.position = new Vector3 (transform.position.x - (hit.distance * Mathf.Abs (hit.normal.x)), transform.position.y - (hit.distance * Mathf.Abs (hit.normal.y)), transform.position.z);
						
						animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (animator.transform.rotation.eulerAngles.x, animator.transform.rotation.eulerAngles.y, 90 * hit.normal.x * hit.normal.y), 2.0f * Time.deltaTime * Speed);
						transform.position = new Vector3 (hit.point.x + 0.1f * -hit.normal.x, hit.point.y + 0.1f * hit.normal.y, transform.position.z);

		}


				if ((animator.transform.rotation.eulerAngles.y < 90 || animator.transform.rotation.eulerAngles.y > 270) && animator.transform.localScale.x == 1) {
						animator.transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
						animator.transform.rotation = Quaternion.Euler (animator.transform.rotation.z, 90, animator.transform.rotation.y);
						//Debug.Log ("Flip1");
				} else if ((animator.transform.rotation.eulerAngles.y < 90 || animator.transform.rotation.eulerAngles.y > 270) && animator.transform.localScale.x == -1) {
						animator.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
						animator.transform.rotation = Quaternion.Euler (animator.transform.rotation.z, -90, animator.transform.rotation.y);
						//Debug.Log ("Flip2");
				}

		
		
				counter += 2 * Time.deltaTime * Speed;
				transform.position = new Vector3 (
			(Mathf.Abs (wayPoints [i].transform.position.x - transform.position.x) > Speed * Time.deltaTime) ?
			transform.position.x+ 0.1f * hit.normal.x + Speed * Mathf.Sign (wayPoints [i].transform.position.x - transform.position.x) * Time.deltaTime * Mathf.Abs (Mathf.Sin (counter)) : transform.position.x,
		    (Mathf.Abs (wayPoints [i].transform.position.y - transform.position.y) > Speed * Time.deltaTime) ?
			transform.position.y+ 0.1f * hit.normal.y + Speed * Mathf.Sign (wayPoints [i].transform.position.y - transform.position.y) * Time.deltaTime * Mathf.Abs (Mathf.Sin (counter)) : transform.position.y);
				if (transform.position.x < wayPoints [i].transform.position.x) {
						if (animator.transform.localScale.x == 1)
								animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (animator.transform.rotation.z, 180, animator.transform.rotation.y), Time.deltaTime * 1.0f * Speed * 2);
						else
								animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (animator.transform.rotation.z, 0, animator.transform.rotation.y), Time.deltaTime * 1.0f * Speed * 2);
				} else { 
						if (animator.transform.localScale.x == 1)
								animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (animator.transform.rotation.z, 0, animator.transform.rotation.y), Time.deltaTime * 1.0f * Speed * 2);
						else
								animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (animator.transform.rotation.z, 180, animator.transform.rotation.y), Time.deltaTime * 1.0f * Speed * 2);
				}

		}
	
		void OnTriggerEnter (Collider waypoint)
		{
				//Debug.Log ("waypoint reached");

				if (waypoint == wayPoints [i].collider) {
						i++;
						if (i == wayPoints.Length) {
								i = 0;
						}

				}
		}
}
