///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 08/06/2020 14:31
///-----------------------------------------------------------------

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.IsartDigital.Proto {
	public class Player : MonoBehaviour {

		[SerializeField] private Transform cameraTransform;
		[SerializeField] private Controller controller;
		[SerializeField] private PlayerSettings settings;

		private new Rigidbody rigidbody;

		private void Awake()
		{
			rigidbody = GetComponent<Rigidbody>();
			
			controller.OnMoveInput += Controller_OnMoveInput;
			UpdateCamPos();
		}

		private void Controller_OnMoveInput(Vector2 direction)
		{
			Vector3 playerDirection = new Vector3(direction.x, 0, direction.y);

			rigidbody.velocity += playerDirection * settings.Acceleration * Time.fixedDeltaTime;
			rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, settings.MaxSpeed);
		}

		private void FixedUpdate()
		{
			rigidbody.velocity *= Mathf.Pow(settings.Friction, Time.fixedDeltaTime);
		}

		private void Update()
		{
			UpdateCamPos();

			if (Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
			}
		}


		private void UpdateCamPos()
		{
			cameraTransform.position = transform.position + Vector3.up * settings.CamDistance;
		}
	}
}