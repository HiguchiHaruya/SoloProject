using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.PlayerSettings;
using static UnityEngine.ParticleSystem;

public class ZombieAnim : MonoBehaviour
{
    [SerializeField] ParticleSystem m_ParticleSystem;
    ZombiController controller = new ZombiController();
    Animator _anim;
    ParticleSystem particle;
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
            particle = Instantiate(m_ParticleSystem,
                other.ClosestPointOnBounds(transform.position), Quaternion.identity);
            particle.Play();
            Destroy(particle,1);
            _anim.SetTrigger("Down");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
}
