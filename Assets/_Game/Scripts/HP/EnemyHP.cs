using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : LivingEntity
{

    public override void Die()
    {
        Destroy(this.gameObject);
    }
}
