using UnityEngine;

namespace Assets.Scripts
{
    public class BallMovement : MonoBehaviour
    {
        public float Speed = 2f;
        private Vector3 _velocity;


        // Use this for initialization
        void Start()
        {
            _velocity = Vector3.down;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(_velocity * Time.deltaTime * Speed);
        }

        void OnCollisionEnter(Collision info)
        {
            foreach (var contactPoint in info.contacts)
            {
                //Following formula  v' = 2 * (v . n) * n - v
                _velocity = 2 * (Vector3.Dot(_velocity, Vector3.Normalize(contactPoint.normal))) *
                            Vector3.Normalize(contactPoint.normal) - _velocity;
                _velocity *= -1;
            }
        }
    }
}
