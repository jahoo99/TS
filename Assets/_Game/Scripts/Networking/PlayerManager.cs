using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    private GameObject _controller;
    private float _randomSpawnPoint = 5f;
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    private void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }    
    }
    void CreateController()
    {

        _controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefab", "PlayerController"), new Vector3(Random.Range(-_randomSpawnPoint, _randomSpawnPoint),0, Random.Range(-_randomSpawnPoint, _randomSpawnPoint)), Quaternion.identity, 0, new object[] {PV.ViewID });

    }
    public void Die()
    {
        PhotonNetwork.Destroy(_controller);
        CreateController();
    }
}
