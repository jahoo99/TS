using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerHP : LivingEntity
{
    private PlayerManager playerManager;
    private PhotonView _pv;
    private float VoidLocationY = -10f; // miejsce œmierci gracza
    private void Awake()
    {
        _pv = GetComponent<PhotonView>();
        playerManager = PhotonView.Find((int)_pv.InstantiationData[0]).GetComponent<PlayerManager>();
    }
    public override void Die()
    {
        playerManager.Die();
    }
    private void Update()
    {
        if (this.transform.position.y <= VoidLocationY)
        {
            Die();
        }
    }
}
