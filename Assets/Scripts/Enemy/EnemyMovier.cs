using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovier : MonoBehaviour
{
    [SerializeField] private Transform _way;
    [SerializeField] private float _speed;

    private Transform[] _spawnPoints;
    private int _minIndex = 0;
    private int _currentSpawnPoint;

    private void Start()
    {
        _spawnPoints = new Transform[_way.childCount];

        for (int i = 0; i < _way.childCount; i++)
        {
            _spawnPoints[i] = _way.GetChild(i);
        }

        _currentSpawnPoint = _minIndex;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _spawnPoints[_currentSpawnPoint].position, _speed * Time.deltaTime);

        if (transform.position == _spawnPoints[_currentSpawnPoint].position)
        {
            _currentSpawnPoint++;

            if (_currentSpawnPoint >= _spawnPoints.Length)
                _currentSpawnPoint = _minIndex;
        }
    }
}
