using UnityEngine;
using System.Collections;

public class CharacterHealth : BasicHealth
{
		public Transform BleedingPoint;
		public GameObject BloodSplash;
		public Animator MyAnimator;

		public override void TakeDamage (float a_damage)
		{
				base.TakeDamage (a_damage);
				MyAnimator.SetTrigger (health > 0 ? "takeDamage" : "die");
				Instantiate (BloodSplash, BleedingPoint.position, Quaternion.identity);
		}

		protected override void die ()
		{
				GameController.LoseGame ();
		}
}
