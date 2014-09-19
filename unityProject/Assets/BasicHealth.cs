using UnityEngine;
using System.Collections;

public class BasicHealth : MonoBehaviour
{	
		public float Health {
				get {
						return health;
				}
		}

		[SerializeField]
		protected int
				maxHealth;
		protected float health;

		virtual protected void Start ()
		{
				health = maxHealth;
		}

		virtual public void TakeDamage (float a_damage)
		{
				print ("Ouch");
				health -= a_damage;
				if (health <= 0) {
						health = 0;
				}
		}

		virtual protected void die ()
		{
			
		}
}
