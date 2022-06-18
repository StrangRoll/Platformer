using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _spawnSpeed;
    [SerializeField] private Coin _coinPrefab;

    private Transform[] _spawnPoints;
    private float _spawnTimer;

    private void Start()
    {
        _spawnPoints = new Transform[_spawn.childCount];

        for (int i = 0; i < _spawn.childCount; i++)
        {
            _spawnPoints[i] = _spawn.GetChild(i);
        }

        StartCoroutine(SpawnCoin());
    }

    private IEnumerator SpawnCoin()
    {
        var spawnDelay = new WaitForSeconds(_spawnSpeed);

        while (true)
        {
            int spawnPoinIndex = Random.Range(0, _spawnPoints.Length);
            Vector3 newCoinPosition = _spawnPoints[spawnPoinIndex].position;
            Instantiate(_coinPrefab, newCoinPosition, Quaternion.identity);
            yield return spawnDelay;
        }
    }
}
