using UnityEngine;

namespace Assets.Scripts
{
    public class BlockMovement : MonoBehaviour
    {
        private Transform _translation;

        public float Speed;
        // Use this for initialization
        void Start()
        {
            _translation = GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            var wPressed = Input.GetKey(KeyCode.W);
            var aPressed = Input.GetKey(KeyCode.A);
            var sPressed = Input.GetKey(KeyCode.S);
            var dPressed = Input.GetKey(KeyCode.D);

            var movementVector = new Vector3(0, 0, 0);
            if (wPressed) movementVector = Vector3.forward;
            if (sPressed) movementVector = Vector3.back;
            if (aPressed) movementVector = Vector3.left;
            if (dPressed) movementVector = Vector3.right;

        
            movementVector.Normalize();
            movementVector *= Time.deltaTime;
            movementVector *= Speed;

            _translation.Translate(movementVector);
        }
    }
}
