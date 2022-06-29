using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class EnemyHP : LivingEntity
{
    public override void Die()
    {
      
        PhotonNetwork.Destroy(this.gameObject);
    }
}
