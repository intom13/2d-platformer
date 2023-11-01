using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawner;
    [SerializeField] private float _spawnerCooldown;

    private void Start()
    {
       var spawn =  StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        for (int enemyCount = 0; enemyCount < 1 ; enemyCount++)
        {
             GameObject spawnedEnemy = Instantiate(_enemy, new Vector3(0, 0, 0), Quaternion.identity, _spawner);
             spawnedEnemy.transform.DOLocalMoveX(-1, 0, false);

         yield return new WaitForSeconds(_spawnerCooldown);
        }
    }
   
    private void Update()
    {
       
    }
}
