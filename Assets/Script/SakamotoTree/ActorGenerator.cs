using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorGenerator : MonoBehaviour
{
    public static GameObject PlayerObj => _playerObj;

    public Player PlayerCon { get; private set; }
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    private static GameObject _playerObj;

    private void Awake()
    {
        PlayerCon = _playerPrefab.GetComponent<Player>();
        EnemyGeneration();
    }

    public void EnemyGeneration()
    {
        for (int i = 0; i < 10; i++)
        {
            var enemyObj = Instantiate(_enemyPrefab, transform.position, transform.rotation);
            enemyObj.name = _enemyPrefab.name + i;
        }

    }
}