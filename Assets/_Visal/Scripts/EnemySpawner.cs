using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab = null;
    [SerializeField] private int _minSpawn = 1;
    [SerializeField] private int _maxSpawn = 5;
    [SerializeField] private float _spawnRadius = 5;
    [SerializeField] private int _maxActiveEnemies = 10;
    [SerializeField] private float _interval = 5;


    public readonly List<GameObject> _activeEnemies = new();


    private void Start()
    {
        InvokeRepeating(nameof(SpawnTick), _interval, _interval);
    }

    private void SpawnTick()
    {
        // Clear destroyed enemies from list
        _activeEnemies.RemoveAll(enemy => !enemy);

        int canSpawn = _maxActiveEnemies - _activeEnemies.Count;
        int spawnCount = Mathf.Min(canSpawn, Random.Range(_minSpawn, _maxSpawn));

        Vector2 centerPos = transform.position;

        for (int i = 0; i < spawnCount; i++)
        {
            float randomX = Random.Range(-_spawnRadius, _spawnRadius);
            float randomY = Random.Range(-_spawnRadius, _spawnRadius);

            var enemy = Instantiate(_enemyPrefab);
            Vector3 pos = centerPos + new Vector2(randomX, randomY);
            enemy.transform.position = pos;
            _activeEnemies.Add(enemy);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
    }
}
