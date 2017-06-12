using UnityEngine;

namespace Assets.Scripts
{
    public class AutoDestroyParticleEffect : MonoBehaviour
    {
        void Start()
        {
            var particleEffect = GetComponent<ParticleSystem>();
            particleEffect.Play();
            Destroy(gameObject,particleEffect.main.duration);
        }
    }
}
