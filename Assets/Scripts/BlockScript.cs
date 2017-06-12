using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class BlockScript : MonoBehaviour
    {
        public AutoDestroyParticleEffect ExplosionEffect;
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
            Instantiate(ExplosionEffect, transform.position,transform.rotation);
            Object.Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
