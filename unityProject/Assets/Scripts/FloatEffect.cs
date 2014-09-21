using UnityEngine;
using System.Collections;

public class FloatEffect : MonoBehaviour
{
		public float Amplitude;
		public float Frequency;
		private float initialY;
		private float time;

		void Start ()
		{
				initialY = transform.position.y;
				time = 0;
		}

		void Update ()
		{
				time += Time.deltaTime;
				transform.Translate (0, Amplitude * Mathf.Sin (Frequency * time), 0);
		}
}
