using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombiController : MonoBehaviour
{
    [SerializeField] GameObject _zombiPrefab;
    [SerializeField] Vector3 _spownpos;
    [SerializeField] Vector3 _spownpos2;
    [SerializeField] Vector3 _spownpos3;
    [SerializeField] float _speed = 200f;
    Rigidbody _rb = default;
    bool _spown = false;
    GameObject _zombiclone = default;
    //Animator _anim;
    public float _deletetime = 5;
    void Start()
    {
        // _anim = GetComponent<Animator>();
        InvokeRepeating("Call", 0.5f, 0.5f);
        if (_rb == null) _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.AddForce(Vector3.fwd * _speed);
    }
    void Call()
    {
        float ramdom = UnityEngine.Random.value;
        if (ramdom < 0.3) SpownZombi(_spownpos);
        else if (ramdom < 0.6) SpownZombi(_spownpos2);
        else SpownZombi(_spownpos3);
    }
    void SpownZombi(Vector3 _pos)
    {
        if (!_spown)
        {
            _zombiclone = Instantiate(_zombiPrefab, _pos, Quaternion.identity);//引数で貰ったVector3座標にスポーン。回転は無し。
            _spown = true;
            Destroy(_zombiclone, _deletetime);
        }
    }

}
