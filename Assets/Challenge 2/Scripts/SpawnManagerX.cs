using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Challenge_2.Scripts
{
    public class SpawnManagerX : MonoBehaviour
    {
        [Serializable]
        private struct SpawnIntervalRange
        {
            [Range(3f, 5f)] public float min;
            [Range(3f, 5f)] public float max;
        }

        private const float SpawnLimitXLeft = -22;
        private const float SpawnLimitXRight = 7;
        private const float SpawnPosY = 30;

        [SerializeField] private GameObject[] ballPrefabs;
        [SerializeField] private SpawnIntervalRange spawnRange;

        private PlayerControllerX _player;

        private void Start()
        {
            _player = FindObjectOfType<PlayerControllerX>();
            StartCoroutine(SpawnRandomBall());
        }

        private IEnumerator SpawnRandomBall()
        {
            while (true)
            {
                _player.SetSpawnStatus(true);

                var spawnPos = new Vector3(Random.Range(SpawnLimitXLeft, SpawnLimitXRight), SpawnPosY, 0);
                var i = Random.Range(0, ballPrefabs.Length);
                var spawnInterval = Random.Range(spawnRange.min, spawnRange.max);

                Instantiate(ballPrefabs[i], spawnPos, ballPrefabs[i].transform.rotation);

                yield return new WaitForSeconds(spawnInterval);
            }

        }
    }
}