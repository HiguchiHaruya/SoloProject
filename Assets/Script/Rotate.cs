using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Rotate : MonoBehaviour
{
    Playercontroller controller = new Playercontroller();
    float _moveSpeed = 2;
    void Start()
    {

    }

    public void Update()
    {
        this.gameObject.transform.Rotate(Vector3.down * controller.ChangeSpeed());
        float horizon = -Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizon, 0, 0);
        GetComponent<Rigidbody>().velocity = movement * _moveSpeed;
    }
}
