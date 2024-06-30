using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _comboTxt; //スコア表示のテキスト
    [SerializeField] Text _timeText; //残り時間表示のテキスト
    [SerializeField] Slider _slider; //Playerが巨大化するまでのスコアを表示するSlider
    [SerializeField] Text _countDownText;
    [SerializeField] Canvas _canvas;
    private bool _isCall = false;
    private bool _isStart = false;
    public bool IsStart => _isStart;
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
        _canvas.enabled = false;
    }
    private void Update()
    {
        _slider.value = Playercontroller.Instance.Score;
        if (!_isCall && !GameManager.Instance.IsEnd)
        {
            StartCoroutine(CountDown());
        }
    }

    private IEnumerator CountDown()
    {
        for (int i = 5; i > 0; i--)
        {
            _canvas.enabled = true;
            _countDownText.transform.localScale = new Vector3(3, 3, 3); //テキストの初期サイズをデカくする
            _countDownText.text = i.ToString();

            var countDownSeq = DOTween.Sequence();
            countDownSeq //回転と大きさのアニメーションをシーケンスにまとめる
                .Append(_countDownText.transform.DOScale(Vector3.one, 2f) //2秒でスケールを1にする
                .SetEase(Ease.InOutQuad)) //イージングをスムーズに開始、終了させるヤツに設定
                .Join(_countDownText.transform //シーケンスに追加
                .DORotate(new Vector3(0, 0, 360), 0.5f, RotateMode.FastBeyond360) //一秒で360度回転させる
                .SetEase(Ease.Linear)); //一定の速度で回転させる
            yield return new WaitForSeconds(1);
        }
        _canvas.enabled = false;
        _countDownText.enabled = false;
        _isStart = true;
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
