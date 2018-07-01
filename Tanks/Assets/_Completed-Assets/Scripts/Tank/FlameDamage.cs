using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class FlameDamage : MonoBehaviour
    {
        public float damage = 0.5f;
        
        private void OnParticleCollision(GameObject other)
        {
            Debug.Log(other.name);

            TankShield shield = other.GetComponent<TankShield>();

            if (shield != null && shield.isActivated)
            {
                return;
            }

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

