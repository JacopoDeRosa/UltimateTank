using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _timeBetweenSpawns;

    private bool _spawn;
    private WaitForSeconds _wait;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (var item in _spawnPoints)
        {
            Gizmos.DrawSphere(item.position, 1);
        }
    }

    public void SetSpawn(bool spawn)
    {
        _spawn = spawn;
    }

    private void Start()
    {
        _spawn = true;
        _wait = new WaitForSeconds(_timeBetweenSpawns);
        StartCoroutine(SpawnEnemies());
    }
  
    private IEnumerator SpawnEnemies()
    {
        while(_spawn)
        {
            Instantiate(_enemy, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
            yield return _wait;
        }
    }
}
