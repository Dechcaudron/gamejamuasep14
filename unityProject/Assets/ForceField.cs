using UnityEngine;
using System.Collections;

public class ForceField : MonoBehaviour
{

		public Vector3 Force;
		public Vector3 CharacterControllerSpeed;

		void OnTriggerStay (Collider a_collider)
		{
				//print ("Pushing");
				Rigidbody t_attachedRigidbody = a_collider.GetComponent<Rigidbody> ();

				if (t_attachedRigidbody != null) {
						t_attachedRigidbody.AddForce (Force);
				} else {
						//print ("Char");
						//Assume the collider is a CharacterController, apply acceleration
						((CharacterController)a_collider).Move (CharacterControllerSpeed * Time.deltaTime);
				}
		}
}
