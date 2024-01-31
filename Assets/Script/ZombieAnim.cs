using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.PlayerSettings;
using static UnityEngine.ParticleSystem;

public class ZombieAnim : MonoBehaviour
{
    private float _speed = 350;
    public float _destroytime;
    [SerializeField] ParticleSystem m_ParticleSystem;
    Animator _anim;
    ParticleSystem particleClone = default;
    bool isDestroyed = false;
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
    private void Update()
    {
        _rb.AddForce(Vector3.fwd * _speed);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
            Destroy(gameObject);

        if (other.gameObject.CompareTag("Player"))
        {
            //particleClone = Instantiate(m_ParticleSystem,
            //    other.ClosestPointOnBounds(transform.position), Quaternion.identity);
            //particleClone.Play();
            //float particleDuration = particleClone.main.duration; //パーティクルの再生時間を取得
            //Destroy(particleClone, particleDuration);
            StartCoroutine(ZombieDestroy());
        }
    }
    IEnumerator ZombieDestroy()
    {
        _anim.SetTrigger("Down");
        yield return new WaitForSeconds(1.5f);
        Destroy(this);
    }
}
