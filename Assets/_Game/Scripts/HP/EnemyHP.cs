using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class EnemyHP : LivingEntity
{
    private PhotonView _pv;
    private void Awake()
    {
        _pv = GetComponent<PhotonView>();   
    }
    public override void Die()
    {
        if (_pv.IsMine)
        {
        PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
