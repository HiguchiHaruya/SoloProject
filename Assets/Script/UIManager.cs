using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _comboTxt;
    [SerializeField] Text _timeText;
    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
    }

    public void GetComboText() { _comboTxt.text = $"{Playercontroller.Instance.Score}combo..."; }
 //   public void GetFinalScoreText() { _finalScoreTxt.text = $"�ŏI�X�R�A��{Playercontroller.Instance.Score}��"; }
    public void GetTimeText() { _timeText.text = $"{(int)GameManager.Instance.CurrentTime}�b�o��..."; }
}
