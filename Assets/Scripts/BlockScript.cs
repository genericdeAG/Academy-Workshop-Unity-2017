using UnityEngine;

namespace Assets.Scripts
{
    public class BlockScript : MonoBehaviour
    {
        private MeshRenderer _renderer;
        
        // Use this for initialization
        void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
            var randomMaterial = new Material(_renderer.material);
            randomMaterial.color = Random.ColorHSV();
            _renderer.material = randomMaterial;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Hit()
        {
            Object.Destroy(gameObject);
        }
    }
}
