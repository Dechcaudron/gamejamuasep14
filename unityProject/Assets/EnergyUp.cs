using UnityEngine;
using System.Collections;

public class EnergyUp : MonoBehaviour
{
		public float Amount;

		void OnTriggerEnter (Collider a_collider)
		{
				if (a_collider.tag == "Player") {
						a_collider.GetComponent<WeaponControl> ().Ammo += Amount;
						Destroy (gameObject);
				}
		}
}
