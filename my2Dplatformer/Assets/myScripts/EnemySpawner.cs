using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnerCooldown;

    private void Start()
    {
       var spawn =  StartCoroutine(Spawn(-1));
    }
    private IEnumerator Spawn(int spawnDistance, int mowingDuration = 0)
    {
        for (int enemyCount = 0; enemyCount < 1 ; enemyCount++)
        {
             GameObject spawnedEnemy = Instantiate(_enemy, new Vector3(0, 0, 0), Quaternion.identity, _spawnPoint);
             spawnedEnemy.transform.DOLocalMoveX(spawnDistance, mowingDuration, false);

         yield return new WaitForSeconds(_spawnerCooldown);
        }
    }
   
    private void Update()
    {
       
    }
}
