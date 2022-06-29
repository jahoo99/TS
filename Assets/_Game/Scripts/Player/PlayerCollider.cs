using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour, ITakeDamage
{
    public void GetDMG(int damage)
    {
        transform.parent.GetComponent<ITakeDamage>().GetDMG(damage);
    }
}
