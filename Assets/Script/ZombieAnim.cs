using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnim : MonoBehaviour
{
    Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {

    }
    public void SetTrigger()
    {
        _anim.SetTrigger("Idle");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _anim.SetTrigger("Down");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
