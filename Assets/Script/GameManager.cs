using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static GameManager;

public class GameManager : MonoBehaviour
{
    bool _gamestart = false;
    float _waitTime = 1.0f;
    float _gameTime = 5;
    float _currentTime = 0;
    [SerializeField] Text _timerTxt;
    /// <summary> ���̃X�N���[���X�s�[�h</summary>
    [SerializeField] float _scrollspeed = 5f;
    /// <summary>���̃����_���[</summary>
    [SerializeField] Renderer _rend;
    /// <summary>�t�F�[�h�A�E�g�p�̉摜</summary>
    [SerializeField] Image _fadeimage;
    public static GameManager _instance;
    private void Awake()
    {
        _gamestart = true;
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
        if (_currentTime <= _gameTime) _currentTime += Time.deltaTime;
        _timerTxt.text = string.Format("{0:0}", (int)_currentTime + "�b�o�߁I�I");
        float _offsetY = Time.time * _scrollspeed;
        _rend.material.SetTextureOffset("_MainTex", new Vector2(0, _offsetY));
        if (_currentTime >= _gameTime) StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        Debug.Log("���B");
        float fadeDuration = 3.0f;
        float timer = 0;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            _fadeimage.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        //SceneManager.LoadScene("");
        _fadeimage.enabled = false;
    }
}
