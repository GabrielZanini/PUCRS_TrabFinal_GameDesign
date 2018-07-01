using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Complete
{
    public class BulletExplosion : MonoBehaviour
    {
        public GameObject player;

        public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
        public ParticleSystem m_ExplosionParticles;         // Reference to the particles that will play on explosion.
        public AudioSource m_ExplosionAudio;                // Reference to the audio that will play on explosion.
        public float m_MaxDamage = 100f;                    // The amount of damage done if the explosion is centred on a tank.
        public float m_ExplosionForce = 1000f;              // The amount of force added to a tank at the centre of the explosion.
        public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is removed.
        public float m_ExplosionRadius = 5f;                // The maximum distance away from the explosion tanks can be and are still affected.

        public bool _destroyIfInvisible;

        private void Awake()
        {
            DebugController.Instance.bulletsCount++;
        }

        private void OnDestroy()
        {
            DebugController.Instance.bulletsCount--;
        }

        private void Start()
        {
            // If it isn't destroyed by then, destroy the shell after it's lifetime.
            Destroy(gameObject, m_MaxLifeTime);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Shield"))
            {
                if (other.transform.parent.gameObject == player)
                {
                    return;
                }
            }
            else if (other.gameObject == player)
            {
                Debug.Log(other.gameObject.name + " - " + player.gameObject.name);
                return;
            }
            else
            {
                BulletExplosion bullet = other.GetComponent<BulletExplosion>();

                if (bullet != null && bullet.player == player)
                {
                    return;
                }
            }

            Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();

            if (targetRigidbody)
            {
                TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

                if (targetHealth)
                {
                    targetHealth.TakeDamage(m_MaxDamage);
                }
            }

            // Unparent the particles from the shell.
            m_ExplosionParticles.transform.parent = null;

            // Play the particle system.
            m_ExplosionParticles.Play();

            // Play the explosion sound effect.
            m_ExplosionAudio.Play();

            // Once the particles have finished, destroy the gameobject they are on.
            ParticleSystem.MainModule mainModule = m_ExplosionParticles.main;
            Destroy(m_ExplosionParticles.gameObject, mainModule.duration);

            // Destroy the shell.
            Destroy(gameObject);
        }

        private void OnBecameInvisible()
        {
            if (_destroyIfInvisible)
            {
                Destroy(gameObject);
            }
        }
    }
}
