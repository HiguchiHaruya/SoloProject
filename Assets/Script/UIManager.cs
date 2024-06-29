using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _comboTxt; //スコア表示のテキスト
    [SerializeField] Text _timeText; //残り時間表示のテキスト
    [SerializeField] Slider _slider; //Playerが巨大化するまでのスコアを表示するSlider
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
    }
    private void Update()
    {
        _slider.value = Playercontroller.Instance.Score;
    }

    public void GetComboText()
    {
        _comboTxt.text = $"{Playercontroller.Instance.Score}combo...";
    }
    public void GetTimeText()
    {
        _timeText.text = $"残り時間{(int)GameManager.Instance.CurrentTime}秒...";
    }
}
