using UnityEngine;

namespace Complete
{
    public abstract class PowerUp : MonoBehaviour
    {
        public GameObject picupEffect;
        public float effectDuration = 5f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Players"))
            {
                PickUp(other.gameObject);
            }
        }

        void PickUp(GameObject player)
        {
            // Spawn effect
            if (picupEffect != null)
            {
                Instantiate(picupEffect, transform.position, transform.rotation);
            }

            ApplyEffect(player);

            PowerUpsSpawner.Instance.SpawnPowerUp();

            TankHealth health = player.GetComponent<TankHealth>();
            if (health != null)
            {
                health.Heal(25);
            }

            Destroy(gameObject);
        }

        protected virtual void ApplyEffect(GameObject player)
        {

        }
    }
}