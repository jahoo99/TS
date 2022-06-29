using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerController : MonoBehaviour
{

    private Rigidbody _rb;
    private PhotonView _pv;
    [SerializeField] private float _walkSpeed = 4f;
    [SerializeField] private float _speedLimiter = 0.7f;
    private float _inputHorizontal;
    private float _inputVertical;
    private void Awake()
    {
        _pv = gameObject.GetComponent<PhotonView>();
        _rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Start()
    {
        if (!_pv.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(_rb);
        }
    }
    private void Update()
    {
        if (!_pv.IsMine)
        {
            return;
        }
        _inputHorizontal = Input.GetAxisRaw("Horizontal");
        _inputVertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        if (!_pv.IsMine)
        {
            return;
        }
        if (_inputHorizontal != 0 || _inputVertical !=0)
        {
            if (_inputHorizontal != 0 && _inputVertical != 0)
            {
                _inputHorizontal *= _speedLimiter;
                _inputVertical *= _speedLimiter;
            }
            _rb.velocity = new Vector3(_inputHorizontal *_walkSpeed,0 ,_inputVertical * _walkSpeed);
        }
        else
        {
            _rb.velocity = new Vector3(0,0,0);
        }
    }
}
