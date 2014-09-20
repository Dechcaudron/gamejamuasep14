using UnityEngine;
using System.Collections;

public class DirectionBehaviour : MonoBehaviour
{
		public sbyte Direction;
		public const sbyte RIGHT = 1;
		public const sbyte LEFT = -1;

		void Start ()
		{
				Direction = RIGHT;
		}

		public void ChangeDirection ()
		{
				print ("I changed direction");
				Direction *= -1;
				transform.parent.localScale = new Vector3 (Direction, 1, 1);

		}

		public void StartEvent ()
		{
				print ("Start");
		}

		public void EndEvent ()
		{
				print ("End");
		}
}
