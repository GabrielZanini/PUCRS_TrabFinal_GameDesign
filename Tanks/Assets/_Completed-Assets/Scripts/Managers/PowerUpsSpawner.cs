using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class PowerUpsSpawner : MonoBehaviour
    {
        public static PowerUpsSpawner Instance { get; private set; }

        public List<GameObject> powerUps;
        public List<Transform> spawnPoints;
        
        int lastPowerUp = -1;
        int lastSpawnPoint = -1;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        void Start()
        {
            for (int i=0; i< transform.childCount; i++)
            {
                spawnPoints.Add(transform.GetChild(i));
            }

            SpawnPowerUp();
        }

        public void SpawnPowerUp()
        {
            int indexPowerUp;
            int indexSpawnPoint;

            do
            {
                indexPowerUp = Random.Range(0, powerUps.Count);
            } while (indexPowerUp == lastPowerUp);

            lastPowerUp = indexPowerUp;

            do
            {
                indexSpawnPoint = Random.Range(0, spawnPoints.Count);
            } while (indexSpawnPoint == lastSpawnPoint);

            lastSpawnPoint = indexSpawnPoint;

            GameObject puInstance =
                Instantiate(powerUps[indexPowerUp], spawnPoints[indexSpawnPoint].position, spawnPoints[indexSpawnPoint].rotation) as GameObject;
        }
    }
}
