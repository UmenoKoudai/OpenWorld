using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorGenerator : MonoBehaviour
{
    public static GameObject PlayerObj => _playerObj;

    public Player PlayerCon { get; private set; }
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField]int _spawnCount;
    [SerializeField] int _interval;
    float _timer;
    private static GameObject _playerObj;

    private void Awake()
    {
        PlayerCon = _playerPrefab.GetComponent<Player>();
        EnemyGeneration();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _interval && FindObjectsByType<CharacterBase>(FindObjectsSortMode.None).Length < _spawnCount + 1)
        {
            EnemyGeneration();
            _timer = 0;
        }
    }

    public void EnemyGeneration()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            int index = Random.Range(0, _spawnPoints.Length);
            var enemyObj = Instantiate(_enemyPrefab, _spawnPoints[index].position, transform.rotation);
            enemyObj.name = _enemyPrefab.name + i;
        }

    }
}