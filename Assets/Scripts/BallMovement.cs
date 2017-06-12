using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class BallMovement : MonoBehaviour
    {
        public float Speed = 2f;
        public Camera Camera;
        private Vector3 _velocity;
        private Renderer _renderer;
        private Vector3 _startPosition;
        // Use this for initialization
        void Start()
        {
            _velocity = Vector3.down;
            _renderer = GetComponent<Renderer>();
            _startPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            var screenPointCenter = Camera.WorldToViewportPoint(_renderer.bounds.center);
            var screenPointRadius = 0.01f;
            if (IsOnRightSide(screenPointCenter, screenPointRadius))
            {
                var normal = new Vector3(-1, 0, 0);
                _velocity = Reflect(_velocity, normal);
            }
            else if (IsOnTopSide(screenPointCenter, screenPointRadius))
            {
                var normal = new Vector3(0, -1, 0);
                _velocity = Reflect(_velocity, normal);
            }
            else if (IsOnLeftSide(screenPointCenter, screenPointRadius))
            {
                var normal = new Vector3(1, 0, 0);
                _velocity = Reflect(_velocity, normal);
            }else if (IsOnBottomSide(screenPointCenter, screenPointRadius))
            {
                var gameController = GameObject.FindGameObjectWithTag("GameController");
                var gameControllerScript = gameController.GetComponent<GameController>();
                gameControllerScript.RemoveLife();
                transform.position = _startPosition;
            }


            transform.Translate(_velocity * Time.deltaTime * Speed);
           
        }

        private bool IsOnBottomSide(Vector3 screenPointCenter, float screenPointRadius)
        {
            return screenPointCenter.y - screenPointRadius <= 0;
        }

        private bool IsOnLeftSide(Vector3 screenPointCenter, float screenPointRadius)
        {
            return screenPointCenter.x - screenPointRadius <= 0;
        }

        private bool IsOnTopSide(Vector3 screenPointCenter, float screenPointRadius)
        {
            return screenPointCenter.y + screenPointRadius >= 1;
        }

        private bool IsOnRightSide(Vector3 screenPointCenter, float screenPointRadius)
        {
            return screenPointCenter.x + screenPointRadius >= 1;
        }

        void OnCollisionEnter(Collision info)
        {
            foreach (var contact in info.contacts)
            {
                if(!info.gameObject.activeSelf) continue;
                _velocity = Reflect(_velocity, contact.normal);
                if (info.gameObject.CompareTag("Block"))
                {
                    var blockMovement = info.gameObject.GetComponent<BlockScript>();
                    blockMovement.Hit();
                }else if (info.gameObject.CompareTag("Pad"))
                {
                    var centerPointX = info.collider.bounds.center.x;
                    var size = info.collider.bounds.size.x;
                    var contactPointX = contact.point.x;
                    var distanceToCenter = contactPointX - centerPointX;
                    var distanceRelative = (distanceToCenter / (size / 2));
                    var degree = distanceRelative * 45;
                    var rotationQuaternion = Quaternion.Euler(0,0, -degree);

                    _velocity = rotationQuaternion * _velocity;
                }
            }
        }

        Vector3 Reflect(Vector3 velocity, Vector3 normal)
        {
            //Following formula  v' = 2 * (v . n) * n - v
            var newVelocity = 2 * (Vector3.Dot(velocity, Vector3.Normalize(normal))) *
                              Vector3.Normalize(normal) - velocity;
            return -1 * newVelocity;
        }
    }
}
