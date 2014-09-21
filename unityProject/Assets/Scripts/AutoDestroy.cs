using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour
{

		public float SecondsToDestroy;

		// Use this for initialization
		void Start ()
		{
				Invoke ("destroyThis", SecondsToDestroy);
		}

		void destroyThis ()
		{
				Destroy (gameObject);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
