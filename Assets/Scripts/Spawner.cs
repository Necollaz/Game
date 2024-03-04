using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawn
{
    public Transform spawnPoint;
    public GameObject enemyPrefab;
}

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemySpawn[] _enemySpawns;
    [SerializeField] private float _timeToSpawn;
    [SerializeField] private bool _canSpawn = true;

    private int _minRandomSpawnPoint = 0;


    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (_canSpawn)
        {
            yield return new WaitForSeconds(_timeToSpawn);
            EnemySpawn randomSpawn = _enemySpawns[Random.Range(0, _enemySpawns.Length)];
            GameObject enemy = Instantiate(randomSpawn.enemyPrefab);
            enemy.transform.position = randomSpawn.spawnPoint.position;
        }
    }
}
