using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class AnimalSpawner : MonoBehaviour
{
    private enum SpawnerPositions
    {
        Forward,
        Right,
        Left
    }
    
    [Header("PREFABS")]
    [SerializeField] private GameObject[] animalPrefabs;
    
    [Header("SETTINGS")]
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float spawnInterval = 1.5f;
    
    [Header("SPAWN POSITIONS")]
    [SerializeField] private float spawnPositionZ = 20f;
    [SerializeField] private float spawnPositionX = 15f;

    private PlayerMovement _player;
    
    private float _spawnRangeX;
    private float _spawnRangeZ;
    
    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        
        _spawnRangeX = _player.GetClampX();
        _spawnRangeZ = _player.GetClampZ();
        
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        Vector3 spawnPosition;
        Quaternion spawnRotation;
        
        var animalIndex = Random.Range(0, animalPrefabs.Length);
        var currentAnimal = animalPrefabs[animalIndex];
        var animalRotation = currentAnimal.transform.rotation;
        var spawnOption = (SpawnerPositions)Random.Range(0, 3);

        switch (spawnOption)
        {
            case SpawnerPositions.Forward:
                spawnPosition = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0, spawnPositionZ);
                spawnRotation = animalRotation;
                break;
            case SpawnerPositions.Right:
                spawnPosition = new Vector3(spawnPositionX, 0, Random.Range(-_spawnRangeZ, _spawnRangeZ));
                spawnRotation = Quaternion.Euler(animalRotation.x, animalRotation.y - 90, animalRotation.z);
                break;
            case SpawnerPositions.Left:
                spawnPosition = new Vector3(-spawnPositionX, 0, Random.Range(-_spawnRangeZ, _spawnRangeZ));
                spawnRotation = Quaternion.Euler(animalRotation.x, animalRotation.y + 90, animalRotation.z);
                break;
            default:
                return;
        }
        
        Instantiate(currentAnimal, spawnPosition, spawnRotation);
    }
}
