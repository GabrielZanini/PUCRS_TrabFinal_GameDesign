using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class Nitro : MonoBehaviour
    {
        public List<GameObject> flames;
        public float speedMultiplier = 3f;
        public float duration = 3f;

        TankMovement _movement;
        float _originalSpeed;

        private void Start()
        {
            _movement = GetComponent<TankMovement>();
            _originalSpeed = _movement.m_Speed;
            DisableFlames();
        }

        public void AddNitro()
        {
            AddNitro(duration);
        }

        public void AddNitro(float seconds)
        {
            StartCoroutine(GoFaster(seconds));
        }

        IEnumerator GoFaster(float seconds)
        {
            EnableFlames();
            _movement.m_Speed *= speedMultiplier;

            yield return new WaitForSeconds(seconds);

            _movement.m_Speed = _originalSpeed;
            DisableFlames();
        }

        private void EnableFlames()
        {
            foreach (var flame in flames)
            {
                flame.SetActive(true);
            }
        }

        private void DisableFlames()
        {
            foreach (var flame in flames)
            {
                flame.SetActive(false);
            }
        }

    }
}