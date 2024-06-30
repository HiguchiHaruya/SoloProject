using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using DG.Tweening;

public enum PlayerState
{
    Normal,
    Big
}

public class Playercontroller : MonoBehaviour
{
    public PlayerState _currentState;
    Vector3 _playerSize = new Vector3(0.1f, 0.1f, 0.1f);
    private bool _isPlayed0 = false;
    private bool _isPlayed1 = false;
    private bool _isBig = false;
    private bool _isNormal = false;
    int currentscore = 0;
    float Limit = 10; //‹‘å‰»‚µ‚Ä‚ç‚ê‚éŽžŠÔ
    public int Score => currentscore;
    public static Playercontroller Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        _currentState = PlayerState.Normal;
    }
    private void Update()
    {
        Debug.Log(Limit);
        if (currentscore >= 100 && !_isBig)
        {
            this.transform.DOScale(new Vector3(1f, 1f, 1f), 3f);
            _currentState = PlayerState.Big;
            _isBig = true;
        }
        switch (_currentState)
        {
            case PlayerState.Big:
                _playerSize = new Vector3(1, 1, 1);
                ChangeBigSize();
                break;
            case PlayerState.Normal:
                _playerSize = new Vector3(0.1f, 0.1f, 0.1f);
                ChangeNormalSize();
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            if (_currentState == PlayerState.Normal) { AudioManager.Instance.PlaySe(2); }
            currentscore++;
        }
    }
    private void ChangeBigSize()
    {
        if (!_isPlayed0)
        {
            AudioManager.Instance.StopBgm();
            AudioManager.Instance.PlayBgm(1);
            _isPlayed0 = true;
        }
        Limit -= Time.deltaTime;
        if (Limit <= 0 && !_isNormal)
        {
            this.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 3f);
            _currentState = PlayerState.Normal;
            _isNormal = true;
        }
    }
    private void ChangeNormalSize()
    {
        if (!_isPlayed1 && Limit <= 0)
        {
            AudioManager.Instance.StopBgm();
            AudioManager.Instance.PlayBgm(0);
            _isPlayed1 = true;
        }
    }

}
