using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class AutoDestroyParticleEffect : MonoBehaviour
    {
        void Start()
        {
            var particleEffect = GetComponent<ParticleSystem>();
            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            particleEffect.Play();
            Destroy(gameObject,Math.Max(particleEffect.main.duration,audioSource.clip.length));
        }
    }
}
