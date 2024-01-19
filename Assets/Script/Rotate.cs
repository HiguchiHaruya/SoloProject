using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Rotate : MonoBehaviour
{
    [SerializeField] AudioSource _speedup;
    Playercontroller _playerContr;
    [HideInInspector] public int _rotateSpeed = 3;
    void Start()
    {
        //_playerContr = FindObjectOfType<Playercontroller>();
    }
    public int ChangeSpeed(int combo)
    {
        if (combo > 15 && combo < 30)
        {
            _speedup.Play();
            return 15;
        }
        if (combo > 30 && combo < 50)
        {
            _speedup.Play();
            return 17;
        }
        if (combo > 50)
        {
            _speedup.Play();
            return 20;
        }
        return 13;
    }
    public void Update()
    {
        //if (_playerContr != null)
        //{
            //Debug.Log(_playerContr._combo);
            gameObject.transform.Rotate(Vector3.up * 14);
            float horizon = -Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(horizon, 0, 0);
            GetComponent<Rigidbody>().velocity = movement * 2;
        //}
         if (_playerContr == null) Debug.Log("Null‚Å‚·");
    }
}
