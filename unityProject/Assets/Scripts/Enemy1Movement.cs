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

		if ((animator.transform.rotation.eulerAngles.y < 90 || animator.transform.rotation.eulerAngles.y > 270)&&animator.transform.localScale.x==1) {
			animator.transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
			animator.transform.rotation = Quaternion.Euler (0, 90, 0);
			Debug.Log ("Flip1");
		} else if ((animator.transform.rotation.eulerAngles.y < 90 || animator.transform.rotation.eulerAngles.y > 270)&&animator.transform.localScale.x==-1) {
			animator.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			animator.transform.rotation = Quaternion.Euler (0, -90, 0);
			Debug.Log ("Flip2");
		}
		
		
		
		counter += 2 * Time.deltaTime * Speed;
				transform.position = new Vector3 (transform.position.x + Speed * Mathf.Sign (wayPoints [i].transform.position.x - transform.position.x) * Time.deltaTime * Mathf.Abs (Mathf.Sin (counter)), transform.position.y);
				if (transform.position.x < wayPoints [i].transform.position.x) {
					if(animator.transform.localScale.x==1)
				animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (0, 180, 0), Time.deltaTime * 1.0f * Speed * 2);
					else
				animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * 1.0f * Speed * 2);
		} else { 
			if(animator.transform.localScale.x==1)
				animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * 1.0f * Speed * 2);
			else
				animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (0, 180, 0), Time.deltaTime * 1.0f * Speed * 2);

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
