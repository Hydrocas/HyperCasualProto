///-----------------------------------------------------------------
/// Author : Hugo TEYSSIER
/// Date : 08/06/2020 14:57
///-----------------------------------------------------------------

using Com.IsartDigital.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Com.IsartDigital.Proto {

    public delegate void ControllerEventHandler(Controller sender);
    public delegate void ControllerEventVector2(Vector2 direction);
    public delegate void ControllerEventGameObject(GameObject gameObject);
    public delegate void ControllerEventInt(int value);
    public delegate void ControllerEvent();

    public class Controller : StateObject
    {
        private static Controller instance;
        public static Controller Instance { get { return instance; } }

        [SerializeField] private string keyHorizontalAxis = "Horizontal";
        [SerializeField] private string keyVerticalAxis = "Vertical";

        public event ControllerEventVector2 OnMoveInput;
        private Vector2 movingVector;

        private void Update()
        {
            movingVector = new Vector2(Input.GetAxis(keyHorizontalAxis), Input.GetAxis(keyVerticalAxis));

            if (movingVector.magnitude > 0)
            {
                OnMoveInput?.Invoke(movingVector);
                return;
            }
            /*
            movingVector = new Vector2(Input.GetAxis(mouseHorizontalAxis), Input.GetAxis(mouseVerticalAxis));

            if (movingVector.magnitude > 0) OnMoveInput?.Invoke(movingVector * dragRatio);*/
        }
    }
}
