using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{	
		public Transform transformToCenter;
		public float MarginH;
		public float MarginVUp;
		public float MarginVDown;
		public float MoveSpeed;

		public Transform Parallax;
		public float ParallaxMultiplierX;
		public float ParallaxMultiplierY;

		// Update is called once per frame
		void Update ()
		{
				Vector3 screenPosition = camera.WorldToScreenPoint (transformToCenter.position);
				Vector3 t_camTranslation;

				if (screenPosition.x / Screen.width > 1f - MarginH) {
						t_camTranslation = new Vector3 (MoveSpeed * Time.deltaTime * (screenPosition.x / Screen.width - (1f - MarginH)), 0, 0);
						transform.Translate (t_camTranslation, Space.World);
						Parallax.Translate (new Vector3 (t_camTranslation.x * ParallaxMultiplierX, t_camTranslation.y * ParallaxMultiplierY) * -1);
				}

				if (screenPosition.x / Screen.width < MarginH) {
						t_camTranslation = new Vector3 (MoveSpeed * Time.deltaTime * (screenPosition.x / Screen.width - MarginH), 0, 0);
						transform.Translate (t_camTranslation, Space.World);
						Parallax.Translate (new Vector3 (t_camTranslation.x * ParallaxMultiplierX, t_camTranslation.y * ParallaxMultiplierY) * -1);
				}

				if (screenPosition.y / Screen.height > 1f - MarginVUp) {
						t_camTranslation = new Vector3 (0, MoveSpeed * Time.deltaTime * (screenPosition.y / Screen.height - (1f - MarginVUp)), 0);
						transform.Translate (t_camTranslation, Space.World);
						Parallax.Translate (new Vector3 (t_camTranslation.x * ParallaxMultiplierX, t_camTranslation.y * ParallaxMultiplierY) * -1);
				}
		
				if (screenPosition.y / Screen.height < MarginVDown) {
						t_camTranslation = new Vector3 (0, MoveSpeed * Time.deltaTime * (screenPosition.y / Screen.height - MarginVDown), 0);
						transform.Translate (t_camTranslation, Space.World);
						Parallax.Translate (new Vector3 (t_camTranslation.x * ParallaxMultiplierX, t_camTranslation.y * ParallaxMultiplierY) * -1);
				}
	 		
		}
}
