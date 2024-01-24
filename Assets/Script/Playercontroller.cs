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
    [SerializeField] Material _newMaterial;
    [SerializeField] Text _comboTxt;
    /// <summary>横移動のスピード</summary>
    [SerializeField] float _moveSpeed = 3f;
    /// <summary>コンボスコア</summary>
    [HideInInspector] public int _combo = 0;
    /// <summary>コンボを反映するテキスト</summary>
    public int _border = 50;
    void Start()
    {

    }

    void Update()
    {
        //float horizon = -Input.GetAxis("Horizontal");
        //Vector3 movement = new Vector3(horizon, 0, 0);
        //GetComponent<Rigidbody>().velocity = movement * _moveSpeed;
    }

    private void LateUpdate()
    {
       // _im.DestroyImage(_combo);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            _combo++;
            ZombieEveSound.Invoke();
            _comboTxt.text = string.Format("{0:0000}", _combo + "Combo...");
        }
    }
}
