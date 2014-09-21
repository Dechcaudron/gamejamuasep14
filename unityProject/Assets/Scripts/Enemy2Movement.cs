using UnityEngine;
using System.Collections;

public class Enemy2Movement : MonoBehaviour
{
	
		public float Speed = 8.0f;
		public float ChargeDistance = 3.0f;
		public float StunTime = 1.0f;
		public GameObject animator;
		bool charging = false;
		bool stunned = false;
		GameObject player;
		float direction;
	
	
		// Use this for initialization
		void Start ()
		{
				player = GameObject.FindGameObjectWithTag ("Player");
		}
	
		// Update is called once per frame
		void Update ()
		{

				if ((animator.transform.rotation.eulerAngles.y < 90 || animator.transform.rotation.eulerAngles.y > 270) && animator.transform.localScale.x == 1) {
						animator.transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
						animator.transform.rotation = Quaternion.Euler (0, 90, 0);
						//Debug.Log ("Flip1");
				} else if ((animator.transform.rotation.eulerAngles.y < 90 || animator.transform.rotation.eulerAngles.y > 270) && animator.transform.localScale.x == -1) {
						animator.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
						animator.transform.rotation = Quaternion.Euler (0, -90, 0);
						//Debug.Log ("Flip2");
				}

				Ray ray1 = new Ray (new Vector3 (transform.position.x, transform.position.y + 1.0f), new Vector3 (animator.transform.rotation.eulerAngles.y, animator.transform.rotation.eulerAngles.x));
				Ray ray2 = new Ray (new Vector3 (transform.position.x, transform.position.y + 1.0f), new Vector3 (-animator.transform.rotation.eulerAngles.y, animator.transform.rotation.eulerAngles.x));

				Debug.DrawRay (ray1.origin, ray1.direction * ChargeDistance, Color.red, 0.0f, false);
				Debug.DrawRay (ray2.origin, ray2.direction * ChargeDistance, Color.blue, 0.0f, false);
		        
				//Cargar si el jugador se acerca a cierta distancia

				RaycastHit hit;
				if (!charging && !stunned) {
						if (Physics.Raycast (ray1, out hit, 5.0f) || Physics.Raycast (ray2, out hit, ChargeDistance)) {

								if (hit.collider.tag == "Player") {
										charging = true;
										direction = Mathf.Sign (player.transform.position.x - transform.position.x);
								}
						}

						if (transform.position.x < player.transform.position.x) {
								if (animator.transform.localScale.x == 1)
										animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (0, 180, 0), Time.deltaTime * 1.0f * Speed * 2);
								else
										animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * 1.0f * Speed * 2);
						} else { 
								if (animator.transform.localScale.x == 1)
										animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (0, 0, 0), Time.deltaTime * 1.0f * Speed * 2);
								else
										animator.transform.rotation = Quaternion.Lerp (animator.transform.rotation, Quaternion.Euler (0, 180, 0), Time.deltaTime * 1.0f * Speed * 2);
				
						}



				} else if (charging) {
						transform.position = new Vector3 (transform.position.x + Speed * direction * Time.deltaTime, transform.position.y);

						//transform.position = new Vector3 (transform.position.x + Speed * Mathf.Sign (player.transform.position.x - transform.position.x) * Time.deltaTime, transform.position.y);
						
				}
		
		
		}

		void OnCollisionEnter (Collision player)
		{
				Debug.Log ("Impacto");
				charging = false;
				stunned = true;
				StartCoroutine (StunWait ());
				
		}

		IEnumerator StunWait ()
		{
				yield return new WaitForSeconds (StunTime);
				stunned = false;
	}
	
}

