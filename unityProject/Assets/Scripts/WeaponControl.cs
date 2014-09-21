using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class WeaponControl : MonoBehaviour
{
		public Transform RayOrigin;
		public bool WeaponUnlocked;
		public int MaxAmmo;
		public float AmmoUseSpeed;
		public float AmmoAttack;
		public int RayVertices;
		public float RayMovementSpeed;
		public float RayMovementRange;
		public Animator MyAnimator;
		public GameObject Pistol;
		private float ammo;
		private Vector3 AimTarget;
		private RaycastHit fireHit;
		private bool hitObstacle;
		private bool is_firing;
		private LineRenderer lineRenderer;
		private bool aimForTarget;
		private System.Timers.Timer aimTimer;
		private float[] lineVertexPadding;
		private bool[] lineVertexPaddingToPositive;

		private bool isFiring {
				get {
						return is_firing;
				}
				set {
						is_firing = value;
						lineRenderer.enabled = value;
						if (!value) {
								aimTimer.Start ();
						} else {
								aimTimer.Stop ();
								startAiming ();
						}
				}
		}

		void Start ()
		{

				ammo = MaxAmmo;

				lineRenderer = GetComponent<LineRenderer> ();
				lineRenderer.SetVertexCount (RayVertices);

				lineVertexPadding = new float[RayVertices];
				lineVertexPaddingToPositive = new bool[RayVertices];

				//Randomly initialize lineVertexPadding
				for (byte i=1; i<RayVertices-1; i++) {
						lineVertexPadding [i] = Random.Range (-RayMovementRange, RayMovementRange);
						lineVertexPaddingToPositive [i] = lineVertexPadding [i] < 0;
				}

				Pistol.SetActive (WeaponUnlocked);
				stopAiming ();
				aimTimer = new System.Timers.Timer (3000);
				aimTimer.Elapsed += aimTimeRunout;
				aimTimer.AutoReset = false;
		}

		void aimTimeRunout (System.Object sender, System.Timers.ElapsedEventArgs args)
		{
				aimForTarget = false;
		}

		void stopAiming ()
		{
				aimForTarget = false;
				MyAnimator.SetLayerWeight (1, 0);
		}

		void startAiming ()
		{
				aimForTarget = true;
				MyAnimator.SetLayerWeight (1, 1);
		}

		void Update ()
		{
				if (!WeaponUnlocked)
						return;

				if (aimForTarget == false) {
						stopAiming ();
				}

				if (Input.GetMouseButtonDown (0) && ammo > 0) {
						isFiring = true;
				}

				if (Input.GetMouseButtonUp (0)) {
						isFiring = false;
				}

				if (isFiring) {
						//Graphic ray effect
						lineRenderer.SetPosition (0, RayOrigin.position);
						lineRenderer.SetPosition (RayVertices - 1, fireHit.point);

						Vector3 t_fireVector = AimTarget - RayOrigin.position;
						t_fireVector /= (RayVertices - 1);

						for (int i=1; i<RayVertices-1; i++) {
								//Calculate new vertex padding

								if (Mathf.Abs (lineVertexPadding [i]) > RayMovementRange) {
								
										//Change padding direction
										lineVertexPaddingToPositive [i] = !lineVertexPaddingToPositive [i];
								}

								//Apply padding modification
								lineVertexPadding [i] += RayMovementSpeed * (lineVertexPaddingToPositive [i] ? 1 : -1);

								//Update vertex position
								float b_finalPositionx = lineVertexPadding [i] / Mathf.Sqrt (Mathf.Pow (t_fireVector.x / t_fireVector.y, 2) + 1);
								lineRenderer.SetPosition (i, (new Vector3 (b_finalPositionx, -t_fireVector.x * b_finalPositionx / t_fireVector.y) + t_fireVector * i + RayOrigin.position));
								//lineRenderer.SetPosition (i, t_fireVector * i + RayOrigin.position);
								print (-t_fireVector.x * b_finalPositionx / t_fireVector.y);
								//print (AimTarget);
						}
				}
		}

		void FixedUpdate ()
		{
				if (!WeaponUnlocked)
						return;

				if (aimForTarget) {
						//Keep track of the mouse
						AimTarget = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z));
						AimTarget.z = RayOrigin.position.z;

						MyAnimator.SetFloat ("aimAngleSin", Mathf.Cos (Vector3.Angle (transform.up, AimTarget - transform.position) * Mathf.Deg2Rad));
				}
				//Fire if so
				if (isFiring) {
						ammo -= AmmoUseSpeed;

						//Raycast
						Ray t_ray = new Ray (RayOrigin.position, AimTarget - RayOrigin.position);
						if (Physics.Raycast (t_ray, out fireHit, 3f)) {
								hitObstacle = true;

								if (fireHit.collider.tag == "Enemy") {
										try {
												fireHit.collider.GetComponent<EnemyHealth> ().TakeDamage (AmmoAttack);
										} catch (System.NullReferenceException) {
												print ("What the flying fuck just happenned...");
										}
								}

						} else {
								hitObstacle = false;
								fireHit.point = AimTarget;
						}

						//Ammo control
						if (ammo <= 0) {
								ammo = 0;
								isFiring = false;
						}
				}

		}

		void OnControllerColliderHit (ControllerColliderHit a_colliderHit)
		{
				if (a_colliderHit.collider.tag == "AmmoPickUp") {
						//TODO: create recoversAmmo script
						print ("Hi");
				}
		}
}
