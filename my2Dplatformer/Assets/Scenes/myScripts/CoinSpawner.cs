using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawner;

    private void Start()
    {
        GameObject coin = Instantiate(_prefab, _spawner.position, Quaternion.identity, _spawner);
    }
}
