using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMoveController : MonoBehaviour
{
    [HideInInspector] public float _rotateSpeed = 0.1f;
    Rigidbody _rb;
    void Start() { _rb = GetComponent<Rigidbody>(); }
    private void FixedUpdate()
    {
        gameObject.transform.Rotate(Vector3.left, _rotateSpeed);
        float horizon = -Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizon, 0, 0);
        _rb.velocity = movement * 2.5f;
    }
}
