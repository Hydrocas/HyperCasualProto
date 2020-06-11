///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 08/06/2020 15:33
///-----------------------------------------------------------------

using UnityEngine;

namespace Com.IsartDigital.Proto {
	
	[CreateAssetMenu(
		menuName = "Proto/Player",
		fileName = "PlayerSettings",
		order = 0
	)]
	
	public class PlayerSettings : ScriptableObject {

		[SerializeField] private float acceleration;
		[SerializeField] private float maxSpeed;
		[SerializeField] private float friction;
		[SerializeField] private float camDistance;

		public float Acceleration => acceleration;
		public float MaxSpeed => maxSpeed;
		public float Friction => friction;
		public float CamDistance => camDistance;
	}
}