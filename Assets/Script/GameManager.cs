using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private float _currentTime = 60;
    private bool _isEnd = false;
    private float _offsetY = 0;
    [SerializeField] float _scrollspeed = 5f;
    [SerializeField] Renderer _rend;

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
        AudioManager.Instance.PlayBgm(0); //ノーマルBGMを再生
    }
    void Update()
    {
        if (_currentTime >= 0) { _currentTime -= Time.deltaTime; }
        if (_currentTime <= 0) //ゲーム終了時の処理
        {
            _isEnd = true;
            AudioManager.Instance.StopBgm();
            SceneLoader.Instance.GetLoadScene("Result"); 
            Destroy(this);
        }
        UIManager.Instance.GetTimeText(); //時間とスコアのテキストを表示
        UIManager.Instance.GetComboText();
        _offsetY = Time.time * _scrollspeed;
        if (_rend != null) { _rend.material.SetTextureOffset("_MainTex", new Vector2(0, _offsetY)); } //床のマテリアルを動かす
    }
}
