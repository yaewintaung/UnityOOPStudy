using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPointList;
    [SerializeField] private List<Transform> topSpawnPointList;
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private float spawnRate;

    private float nextSpawnTime;

    private void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    private void SpawnEnemy()
    {
        int enemyCount = GameManager.Instance.GetEnemyCouont();
        if (enemyCount >= 5) return;
        var enemy = enemyList[UnityEngine.Random.Range(0, enemyList.Count)];
        Transform point;
        if (enemy.TryGetComponent(out FlyEnemy flyEnemy))
        {
            point = topSpawnPointList[UnityEngine.Random.Range(0, topSpawnPointList.Count)];
        }
        else
        {
            point = spawnPointList[UnityEngine.Random.Range(0, spawnPointList.Count)];
        }
        Instantiate(enemy, point.position, Quaternion.identity);
        GameManager.Instance.SetEnemyCount(enemyCount + 1);
    }
}
