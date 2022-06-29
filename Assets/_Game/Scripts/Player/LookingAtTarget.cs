using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtTarget : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _targetLayer;
    private Transform _nearestEnemy;
    private bool _idented = false; //zeruje rotacje XD

    private void Update()
    {

        Collider[] _enemy = Physics.OverlapSphere(transform.position, _radius, _targetLayer);

        for (int i = 0; i <= _enemy.Length; i++)
        {
            if (_enemy.Length > 0)
            {
                transform.LookAt(_enemy[0].transform.position);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
