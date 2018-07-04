using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class TankImpact : MonoBehaviour
    {

        public float impactForce = 5f;
        public float damage = 5f;

        private Rigidbody _rigidbody;
        private Nitro _nitro;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _nitro = GetComponent<Nitro>();
        }


        private void OnCollisionStay(Collision collision)
        {
            //Debug.Log(collision.gameObject.name);

            int player = LayerMask.NameToLayer("Players");
            int shield = LayerMask.NameToLayer("Shield");

            if (collision.gameObject.layer == player || collision.gameObject.layer == shield)
            {
                Vector3 impactDirection = transform.position - collision.transform.position;
                impactDirection.Normalize();

                _rigidbody.AddForce(impactDirection * impactForce, ForceMode.Impulse);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            TankShield shield = collision.gameObject.GetComponent<TankShield>();

            if (shield != null && shield.isActivated)
            {
                return;
            }

            int player = LayerMask.NameToLayer("Players");

            if (collision.gameObject.layer == player)
            {
                TankHealth health = collision.gameObject.GetComponent<TankHealth>();

                if (health != null)
                {
                    health.TakeDamage(_nitro.isActive? damage * 3 : damage);
                }
            }
        }
    }
}
