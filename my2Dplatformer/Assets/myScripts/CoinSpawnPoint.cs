using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        GameObject coin = Instantiate(_coin, _spawnPoint.position, Quaternion.identity, _spawnPoint);
    }
}
