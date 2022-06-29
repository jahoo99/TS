using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class EnemySpawn : MonoBehaviour
{
    PhotonView PV;
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    private void Start()
    {
        CreateEnemy();
    }
    private void CreateEnemy()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefab", "Turret"),Vector3.zero, Quaternion.identity);
    }
}

