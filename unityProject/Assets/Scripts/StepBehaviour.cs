using UnityEngine;
using System.Collections;

public class StepBehaviour : MonoBehaviour
{
		public GameObject Splash;
		public Transform SplashOrigin;
		public bool WalkingOnWater;
		

		public void StepEvent ()
		{
				if (WalkingOnWater) {
						Instantiate (Splash, SplashOrigin.position, Quaternion.identity);
				}
		}
}
