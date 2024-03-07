using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private bool _canSpawn = true;

    private int _minRandomSpawnPoints = 0;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private void Spawn()
    {
        GameObject enemyObject = Instantiate(_enemyPrefab);
        enemyObject.transform.position = _spawnPoints[Random.Range(_minRandomSpawnPoints, _spawnPoints.Length)].position;
        Enemy enemyComponent = enemyObject.GetComponent<Enemy>();

        if(enemyComponent != null)
        {
            if(_target != null)
            {
                enemyComponent.SetTarget(_target);
            }
        }
    }

    private IEnumerator Spawner()
    {
        while (_canSpawn)
        {
            yield return new WaitForSeconds(_timeToSpawn);
            Spawn();
        }
    }
}
