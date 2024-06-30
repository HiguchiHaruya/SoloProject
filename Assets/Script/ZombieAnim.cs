using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class ZombieAnim : MonoBehaviour
{
    [SerializeField]
    private float force = 10f; //������΂��̂�����
    [SerializeField]
    private float duration = 1.5f; //�A�j���[�V�����̒���
    [SerializeField]
    private float rotationAmount = 360f; //��]�̊p�x

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
        if (UIManager.Instance.IsStart) { _rb.velocity = new Vector3(0, 0, 1 * _speed); }
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
        Vector3 dir = (-transform.forward + transform.up).normalized; //������т̕���
        Vector3 endPos = transform.position + dir * force; //������т̍ŏI�n�_
        _anim.SetTrigger("Down");
        transform.DOMove(endPos, duration) //������т�ݒ�
            .SetEase(Ease.OutQuad);

        transform.DORotate( //��]��ݒ�
            new Vector3(0, 0, rotationAmount), duration, RotateMode.FastBeyond360)
            .SetEase(Ease.OutQuad);

        yield return new WaitForSeconds(1.5f);
        ZombiController.Instance.ReturnZombie(gameObject);
    }
}
