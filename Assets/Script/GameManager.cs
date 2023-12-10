using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static GameManager;

public class GameManager : MonoBehaviour
{
    bool _gamestart = false;
    float _waitTime = 2.0f;
    [SerializeField] Text _countdownTxt;
    /// <summary> 床のスクロールスピード</summary>
    [SerializeField] float _scrollspeed = 5f;
    /// <summary>床のレンダラー</summary>
    [SerializeField] Renderer _rend;
    /// <summary>ゲーム開始時のカウントダウン時間</summary>
    [SerializeField] float _countdownTime = 10f;
    public UnityEvent Eve;
    public static GameManager _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (_countdownTime > 0)
        {
            _countdownTime -= Time.deltaTime;
            _countdownTxt.text = _countdownTime.ToString("0");
        }
        if (_countdownTxt.text == "0")
        {
            _gamestart = true;
            _countdownTxt.gameObject.SetActive(false);
        }
        if (_gamestart)
        {
            float _offsetY = Time.time * _scrollspeed;
            _rend.material.SetTextureOffset("_MainTex", new Vector2(_offsetY, 0));
        }
    }
    IEnumerator Main()
    {
        yield return new WaitForSeconds(_waitTime);

    }
}
