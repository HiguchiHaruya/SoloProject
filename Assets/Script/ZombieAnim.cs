using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.PlayerSettings;
using static UnityEngine.ParticleSystem;

public class ZombieAnim : MonoBehaviour
{
    public float _destroytime;
    [SerializeField] ParticleSystem m_ParticleSystem;
    Animator _anim;
    ParticleSystem particleClone = default;
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
            particleClone = Instantiate(m_ParticleSystem,
                other.ClosestPointOnBounds(transform.position), Quaternion.identity);
            particleClone.Play();
            float particleDuration = particleClone.main.duration; //パーティクルの再生時間を取得
            Destroy(particleClone,particleDuration);
            _anim.SetTrigger("Down");
        }
    }
}
