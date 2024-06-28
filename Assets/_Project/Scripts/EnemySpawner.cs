using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyToSpawn;
    [SerializeField] float _timeToSpawn;
    [SerializeField] Transform[] _spawnPoints;
    
    float _spawnCounter;

    void Awake()
    {
        _spawnCounter = _timeToSpawn;
    }

    void Update()
    {
        _spawnCounter -= Time.deltaTime;
        if (_spawnCounter <= 0)
        {
            _spawnCounter = _timeToSpawn;
            var randomSpawnPoint = GetRandomSpawnPoint();
            Instantiate(_enemyToSpawn, randomSpawnPoint.position, randomSpawnPoint.rotation);
        }
            
    }

    Transform GetRandomSpawnPoint()
    {
        int index = Random.Range (0, _spawnPoints.Length);
        return _spawnPoints[index];
    }
}
