using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _comboTxt; //�X�R�A�\���̃e�L�X�g
    [SerializeField] Text _timeText; //�c�莞�ԕ\���̃e�L�X�g
    [SerializeField] Slider _slider; //Player�����剻����܂ł̃X�R�A��\������Slider
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
        _timeText.text = $"�c�莞��{(int)GameManager.Instance.CurrentTime}�b...";
    }
}
