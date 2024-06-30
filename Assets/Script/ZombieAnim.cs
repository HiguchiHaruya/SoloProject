using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class ZombieAnim : MonoBehaviour
{
    [SerializeField]
    private float force = 10f; //吹っ飛ばしのちから
    [SerializeField]
    private float duration = 1.5f; //アニメーションの長さ
    [SerializeField]
    private float rotationAmount = 360f; //回転の角度

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
        Vector3 dir = (-transform.forward + transform.up).normalized; //吹っ飛びの方向
        Vector3 endPos = transform.position + dir * force; //吹っ飛びの最終地点
        _anim.SetTrigger("Down");
        transform.DOMove(endPos, duration) //吹っ飛びを設定
            .SetEase(Ease.OutQuad);

        transform.DORotate( //回転を設定
            new Vector3(0, 0, rotationAmount), duration, RotateMode.FastBeyond360)
            .SetEase(Ease.OutQuad);

        yield return new WaitForSeconds(1.5f);
        ZombiController.Instance.ReturnZombie(gameObject);
    }
}
