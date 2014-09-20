using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{	
		public GameObject Player;
		public int PixelMarginsH;
		public int PixelMarginsVUp;
		public int PixelMarginsVDown;
		public float MoveSpeed;

		// Update is called once per frame
		void Update ()
		{
				Vector3 screenPosition = camera.WorldToScreenPoint (Player.transform.position);

				if (screenPosition.x > Screen.width - PixelMarginsH) {
						transform.Translate (MoveSpeed * Time.deltaTime * (screenPosition.x - Screen.width + PixelMarginsH), 0, 0);
				}

				if (screenPosition.x < PixelMarginsH) {
						transform.Translate (MoveSpeed * Time.deltaTime * (screenPosition.x - PixelMarginsH), 0, 0);
				}

				if (screenPosition.y > Screen.width - PixelMarginsVUp) {
						transform.Translate (0, MoveSpeed * Time.deltaTime * (screenPosition.y - Screen.width + PixelMarginsVUp), 0);
				}
		
				if (screenPosition.y < PixelMarginsVDown) {
						transform.Translate (0, MoveSpeed * Time.deltaTime * (screenPosition.y - PixelMarginsVDown), 0);
				}
	 		
		}
}
