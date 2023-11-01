using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;

    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];

    private bool _turningRight;

    private void Start()
    {
        _turningRight = false;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_turningRight == true)
        {
            var collisionCount = _rb.Cast(transform.right, _results, 1);

            if(collisionCount > 0 )
                _turningRight = false;
            
            else
                transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (_turningRight == false)
        {
            var collisionCount = _rb.Cast(transform.right * -1, _results, 1);

            if(collisionCount > 0 )
                _turningRight = true;
            
            else
                transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
    }
}
