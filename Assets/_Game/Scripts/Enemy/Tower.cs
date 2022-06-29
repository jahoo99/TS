using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _radius = 10f;
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private float _timeBetweenAttacks = 1;
    private bool _alreadyAttacked;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _gunPoint;
    private void Update()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _targetLayerMask);

        if (hitColliders.Length > 0)
        {
            transform.LookAt(hitColliders[0].gameObject.transform);
            if (!_alreadyAttacked)
            {
              //  Instantiate(_bullet, _gunPoint.transform);
                _alreadyAttacked = true;
                Invoke(nameof(Reset), _timeBetweenAttacks);
            }

        }

    }
    private void Reset()
    {
        _alreadyAttacked = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
