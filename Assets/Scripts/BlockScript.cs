using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class BlockScript : MonoBehaviour
    {
        private MeshRenderer _renderer;

        public AutoDestroyParticleEffect ExplosionEffect;

        // Use this for initialization
        void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
            var randomMaterial = new Material(_renderer.material);
            randomMaterial.color = Random.ColorHSV();
            _renderer.material = randomMaterial;
            var gameController = GameObject.FindGameObjectWithTag("GameController");
            var gameControllerScript = gameController.GetComponent<GameController>();
            gameControllerScript.RegisterBlock();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Hit()
        {
            var gameController = GameObject.FindGameObjectWithTag("GameController");
            var gameControllerScript = gameController.GetComponent<GameController>();
            gameControllerScript.Points += 20;
            gameControllerScript.UnregisterBlock();
            Instantiate(ExplosionEffect, transform.position,transform.rotation);
            Object.Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
