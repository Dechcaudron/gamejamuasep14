using UnityEngine;
using System.Collections;

public class EnemyHealth : BasicHealth
{
		public delegate void DeathDelegate ();
		public event DeathDelegate OnDeath;

		protected override void die ()
		{
				base.die ();

				if (OnDeath != null)
						OnDeath ();
		}
}
