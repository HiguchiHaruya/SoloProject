using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum PlayerState
{
    Normal,
    Big
}

public class Playercontroller : MonoBehaviour
{
    public PlayerState _currentState;
    Vector3 _normalSeze;
    private bool _isPlayed0 = false;
    private bool _isPlayed1 = false;
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
        _normalSeze = this.transform.localScale;
        _currentState = PlayerState.Normal;
    }
    private void Update()
    {
        if (currentscore >= 15)
        {
            _currentState = PlayerState.Big;
        }
        switch (_currentState)
        {
            case PlayerState.Big:
                ChangeBigSize();
                break;
            case PlayerState.Normal:
                ChangeNormalSize();
                break;
        }

    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            if (_currentState == PlayerState.Normal) { AudioManager.Instance.PlaySe(2); }
            if (_currentState == PlayerState.Big && !_isPlayed0)
            {
                AudioManager.Instance.StopBgm();
                AudioManager.Instance.PlayBgm(1);
                _isPlayed0 = true;
            }
            currentscore++;
        }
    }
    private void ChangeBigSize()
    {

        this.transform.localScale = new Vector3(1, 1, 1);
        Limit -= Time.deltaTime;
        if (Limit <= 0) { _currentState = PlayerState.Normal; }
    }
    private void ChangeNormalSize()
    {
        this.transform.localScale = _normalSeze;
        if (!_isPlayed1 && Limit <= 10)
        {
            AudioManager.Instance.StopBgm();
            AudioManager.Instance.PlayBgm(0);
            _isPlayed1 = true;
        }
    }

}
