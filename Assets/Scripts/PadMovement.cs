using System;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts
{
    public class PadMovement : MonoBehaviour
    {
        private Transform _transformation;
        private float _currentSpeed;
        private Renderer _childRenderer;

        public float InitialSpeed = 4;
        public float MaxSpeed = 6;
        public float Acceleration = 2;
        public Camera Camera;

        // Use this for initialization
        void Start()
        {
            _transformation = GetComponent<Transform>();
            _childRenderer = GetComponentInChildren<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
            var leftPressed = Input.GetKey(KeyCode.LeftArrow);
            var rightPressed = Input.GetKey(KeyCode.RightArrow);

            var movementX = 0.0f;
            if (!leftPressed && !rightPressed) _currentSpeed = 0;

            if (leftPressed)
            {
                _currentSpeed = Math.Min(_currentSpeed, -InitialSpeed);
                _currentSpeed -= Acceleration * Time.deltaTime;
            }

            if (rightPressed)
            {
                _currentSpeed = Math.Max(_currentSpeed, InitialSpeed);
                _currentSpeed += Acceleration * Time.deltaTime;
            }

            _currentSpeed = MathHelper.Clamp(_currentSpeed, -MaxSpeed, MaxSpeed);

            movementX += _currentSpeed * Time.deltaTime;

            _transformation.Translate(movementX, 0, 0, Space.World);
            var screenPointRightmost = Camera.WorldToViewportPoint(_childRenderer.bounds.max);
            var screenPointLeftmost = Camera.WorldToViewportPoint(_childRenderer.bounds.min);
            bool onScreen = screenPointRightmost.x < 1 && screenPointLeftmost.x > 0;
            if (!onScreen)
            {
                _transformation.Translate(-movementX, 0, 0, Space.World);
            }
        }
    }
}
