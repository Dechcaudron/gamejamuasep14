using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{	
		public GameObject Player;
		public float MarginH;
		public float MarginVUp;
		public float MarginVDown;
		public float MoveSpeed;

		// Update is called once per frame
		void Update ()
		{
				Vector3 screenPosition = camera.WorldToScreenPoint (Player.transform.position);

				if (screenPosition.x / Screen.width > 1f - MarginH) {
						//print (1f - screenPosition.x / Screen.width);
						transform.Translate (MoveSpeed * Time.deltaTime * (screenPosition.x / Screen.width - (1f - MarginH)), 0, 0);
				}

				if (screenPosition.x / Screen.width < MarginH) {
						transform.Translate (MoveSpeed * Time.deltaTime * (screenPosition.x / Screen.width - MarginH), 0, 0);
				}

				if (screenPosition.y / Screen.height > 1f - MarginVUp) {
						transform.Translate (0, MoveSpeed * Time.deltaTime * (screenPosition.y / Screen.height - (1f - MarginVUp)), 0);
				}
		
				if (screenPosition.y / Screen.height < MarginVDown) {
						transform.Translate (0, MoveSpeed * Time.deltaTime * (screenPosition.y / Screen.height - MarginVDown), 0);
				}
	 		
		}
}
