using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Playercontroller : MonoBehaviour
{
    ImageManager _im;
    /// <summary>ゾンビを殺した時のイベント</summary>
    [SerializeField] UnityEvent ZombieEveSound;
    [SerializeField] UnityEvent ZombieEveParticle;
    [SerializeField] Image _image, _image1, _image2, _image2a, _image3, _image3a, _image4, _image4a;
    [SerializeField] Material _newMaterial;
    [SerializeField] Text _comboTxt;
    /// <summary>横移動のスピード</summary>
    [SerializeField] float _moveSpeed = 3f;
    /// <summary>コンボスコア</summary>
    [HideInInspector] public int _combo = 0;
    /// <summary>コンボを反映するテキスト</summary>
    public int _border = 50;
    private void Awake()
    {
        _image.enabled = false;
        _image1.enabled = false;
        _image2.enabled = false;
        _image2a.enabled = false;
        _image3.enabled = false;
        _image3a.enabled = false;
        _image4.enabled = false;
        _image4a.enabled = false;

    }
    void Start()
    {
        _im = FindObjectOfType<ImageManager>();
    }

    void Update()
    {
        float horizon = -Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizon, 0, 0);
        GetComponent<Rigidbody>().velocity = movement * _moveSpeed;
    }

    private void LateUpdate()
    {
        _im.DestroyImage(_combo);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie") || other.CompareTag("Child"))
        {
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
