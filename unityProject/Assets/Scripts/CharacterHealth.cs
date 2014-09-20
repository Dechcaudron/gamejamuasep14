using UnityEngine;
using System.Collections;

public class CharacterHealth : BasicHealth
{
		protected override void die ()
		{
				GameController.LoseGame ();
		}
}
