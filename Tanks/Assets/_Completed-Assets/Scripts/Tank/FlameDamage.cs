using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class FlameDamage : MonoBehaviour
    {
        public float damage = 0.5f;
        
        private void OnTriggerStay(Collider other)
        {
            //Debug.Log(other.gameObject.name);

            Rigidbody targetRigidbody = other.GetComponent<Rigidbody>();

            if (targetRigidbody)
            {
                TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();

                if (targetHealth)
                {
                    targetHealth.TakeDamage(damage);
                }
            }
        }

        private void OnParticleCollision(GameObject other)
        {
            if (other.layer == LayerMask.NameToLayer("Players"))
            {
                TankHealth targetHealth = other.GetComponent<TankHealth>();

                if (targetHealth)
                {
                    targetHealth.TakeDamage(damage);
                }
            }
        }
    }
}

