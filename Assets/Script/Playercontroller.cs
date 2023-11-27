using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Playercontroller : MonoBehaviour
{
    /// <summary>ゾンビを殺した時のイベント</summary>
    [SerializeField] UnityEvent ZombieEveSound;
    [SerializeField] UnityEvent ZombieEveParticle;
    [SerializeField] Image _image, _image1, _image2, _image2a, _image3, _image3a, _image4, _image4a;
    [SerializeField] Material _newMaterial;
    /// <summary>横移動のスピード</summary>
    [SerializeField] float _moveSpeed = 3f;
    /// <summary>コンボスコア</summary>
    int _combo = 0;
    /// <summary>コンボを反映するテキスト</summary>
    [SerializeField] Text _comboTxt;
    public int _border = 50;
    void Start()
    {
        _image.enabled = false;
        _image1.enabled = false;
        _image2.enabled = false;
        _image2a.enabled = false;
        _image3.enabled = false;
        _image3a.enabled = false;
        _image4.enabled = false;
        _image4a.enabled = false;
        InvokeRepeating("ChangeSpeed", 0, 1);
    }

    void Update()
    {
        float horizon = -Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizon, 0, 0);
        GetComponent<Rigidbody>().velocity = movement * _moveSpeed;

    }
    public float ChangeSpeed()
    {
        if (_combo > 40 && _combo < 60)
        {
            Debug.Log("スピード40");
            return 40;
        }
        if (_combo > 60 && _combo < 100)
        {
            Debug.Log("スピード80");
            return 80;
        }
        if (_combo > 100)
        {
            Debug.Log("スピード160");
            return 160;
        }
        return 10;
    }
    private void LateUpdate()
    {
        if (_combo > 40)
        {

            _image2.enabled = true;
            _image2a.enabled = true;
        }
        if (_combo > 60)
        {
            _image3.enabled = true;
            _image3a.enabled = true;
        }
        if (_combo > 100)
        {
            _image4.enabled = true;
            _image4a.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {

            _image.enabled = true; _image1.enabled = true;
            _combo++;
            ZombieEveSound.Invoke();
            _comboTxt.text = string.Format("{0:0000}", _combo + "Combo!!!");
            if (_combo > _border)
            {
                _border += 50;
            }
        }
    }
}
