using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Rotate : MonoBehaviour
{
    float _scroll = 15f;
    float _moveSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(Vector3.down * _scroll);
        float horizon = -Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizon, 0, 0);
        GetComponent<Rigidbody>().velocity = movement * _moveSpeed;
    }
}
