using UnityEngine;
using System.Collections;

public class LifeUp : MonoBehaviour
{

		public float Amount;

		void OnTriggerEnter (Collider a_collider)
		{
				if (a_collider.tag == "Player") {
						a_collider.GetComponent<CharacterHealth> ().Health += Amount;
						Destroy (gameObject);
				}
		}
}
