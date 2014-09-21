using UnityEngine;
using System.Collections;

public class BatMovement : MonoBehaviour
{


		public float Speed = 2.0f;
		public float followDistance = 6.0f;
		float directionx;
		float directiony;
		GameObject player;
		Vector3 objective;


		// Use this for initialization
		void Start ()
		{
				player = GameObject.FindGameObjectWithTag ("Player");
				InvokeRepeating ("RecalculateMovement", 0.0f, 0.1f);
		}
	
		// Update is called once per frame
		void Update ()
		{
	



				directionx = Mathf.Sign (player.transform.position.x - transform.position.x);
				directiony = Mathf.Sign (player.transform.position.y - transform.position.y);

				if (Mathf.Abs (player.transform.position.x - transform.position.x) + Mathf.Abs (player.transform.position.y - transform.position.y) < followDistance) {

						transform.position = Vector3.Lerp (transform.position, objective, Time.deltaTime);
				}



		}

		void RecalculateMovement ()
		{
				objective = new Vector3 (transform.position.x + Speed * directionx + (Random.value - 0.5f) * Speed * 2.5f, transform.position.y + Speed * directiony + (Random.value - 0.5f) * Speed * 2.5f);

		}

		void OnCollisionEnter (Collision player)
		{
				if (player.gameObject.tag == "Player") {
						//Golpear al jugador

				}
		}
}
