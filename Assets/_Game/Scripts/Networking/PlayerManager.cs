using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    private GameObject _controller;
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
        _controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefab", "PlayerController"), Vector3.zero, Quaternion.identity, 0, new object[] {PV.ViewID });

    }
    public void Die()
    {
        PhotonNetwork.Destroy(_controller);
        CreateController();
    }
}
