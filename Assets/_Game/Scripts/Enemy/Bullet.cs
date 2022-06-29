using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 200f;
    private Rigidbody _rb;
    private PhotonView _pv;
    private float _time = 10f;
    private int _playerLayer = 6;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _pv = GetComponent<PhotonView>();
    }
    private void Update()
    {
        _rb.AddForce(transform.forward * speed);
    }
    private void Start()
    {
       // StartCoroutine(Shatter());
    }
    private int _dmg = 5;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == _playerLayer)
        { 
            
            ITakeDamage mb = other.transform.GetComponent<ITakeDamage>();
            if (mb != null)
            {
                mb.GetDMG(_dmg);
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
       
    }
    IEnumerator Shatter()
    {
        yield return new WaitForSeconds( _time);
        if (this.gameObject.activeSelf)
        {
            PhotonNetwork.Destroy(this.gameObject);
        }
        
    }
}
