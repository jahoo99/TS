using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, ITakeDamage
{
    [SerializeField] private int _maxHP;
    private int _currentHP;
    private void Start()
    {
        _currentHP = _maxHP;
    }
    public void GetDMG(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {

    }


}