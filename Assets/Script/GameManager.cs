using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float _gameTime = 45;
    private float _currentTime = 0;
    private bool _isEnd = false;
    private float _offsetY = 0;
    [SerializeField] Text _timerTxt;
    [SerializeField] float _scrollspeed = 5f;
    [SerializeField] Renderer _rend;
    [SerializeField] Image _fadeimage;

    public float GameTime => _gameTime;
    public float CurrentTime => _currentTime;
    public bool IsEnd => _isEnd;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }

    void Update()
    {
        if (_currentTime <= _gameTime) { _currentTime += Time.deltaTime; }
        UIManager.Instance.GetTimeText();
        UIManager.Instance.GetComboText();
        _offsetY = Time.time * _scrollspeed;
        if (_rend != null) { _rend.material.SetTextureOffset("_MainTex", new Vector2(0, _offsetY)); }
        if (_currentTime >= _gameTime) { _isEnd = true; }
    }
}
