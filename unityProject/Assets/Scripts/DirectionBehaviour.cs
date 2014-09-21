using UnityEngine;
using System.Collections;

public class DirectionBehaviour : MonoBehaviour
{
		public sbyte Direction;
		public Animator MyAnimator;
		public const sbyte RIGHT = 1;
		public const sbyte LEFT = -1;

		void Start ()
		{
				Direction = RIGHT;
		}

		public void ChangeDirection ()
		{
				//print ("I changed direction");
				Direction *= -1;
				MyAnimator.SetBool ("isFacingRight", Direction > 0);
				transform.parent.localScale = new Vector3 (Direction, 1, 1);

		}
}
