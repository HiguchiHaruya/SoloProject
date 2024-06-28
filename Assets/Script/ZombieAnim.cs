using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieAnim : MonoBehaviour
{
    private float _speed = 30;
    public float _destroytime;
    [SerializeField] ParticleSystem m_ParticleSystem;
    Animator _anim;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }
    public void SetTrigger()
    {
        _anim.SetTrigger("Idle");
    }
    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(0, 0, 1 * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
            ZombiController.Instance.ReturnZombie(gameObject);

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ZombieDestroy());
        }
    }
    IEnumerator ZombieDestroy()
    {
        _anim.SetTrigger("Down");
        yield return new WaitForSeconds(1.5f);
        ZombiController.Instance.ReturnZombie(gameObject);
    }
}
