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
    bool _spown = false;
    void Start()
    {
        InvokeRepeating("Call", 0.5f, 1f);
    }

    [Obsolete]
    void Call()
    {
        float ramdom = UnityEngine.Random.Range(0, 8);
        if (ramdom < 3) SpownZombi(_spownpos);
        else if (ramdom < 9) SpownZombi(_spownpos2);
        //else SpownZombi(_spownpos3);
    }
    void SpownZombi(Vector3 _pos)
    {
        if (!_spown)
        {
            GameObject _zombiclone =
                Instantiate(_zombiPrefab, _pos, Quaternion.identity);//引数で貰ったVector3座標にスポーン。回転は無し。
            _spown = true;
        }
    }
}
