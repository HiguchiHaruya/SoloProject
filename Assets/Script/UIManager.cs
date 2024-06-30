using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _comboTxt; //�X�R�A�\���̃e�L�X�g
    [SerializeField] Text _timeText; //�c�莞�ԕ\���̃e�L�X�g
    [SerializeField] Slider _slider; //Player�����剻����܂ł̃X�R�A��\������Slider
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
            _countDownText.transform.localScale = new Vector3(3, 3, 3); //�e�L�X�g�̏����T�C�Y���f�J������
            _countDownText.text = i.ToString();

            var countDownSeq = DOTween.Sequence();
            countDownSeq //��]�Ƒ傫���̃A�j���[�V�������V�[�P���X�ɂ܂Ƃ߂�
                .Append(_countDownText.transform.DOScale(Vector3.one, 2f) //2�b�ŃX�P�[����1�ɂ���
                .SetEase(Ease.InOutQuad)) //�C�[�W���O���X���[�Y�ɊJ�n�A�I�������郄�c�ɐݒ�
                .Join(_countDownText.transform //�V�[�P���X�ɒǉ�
                .DORotate(new Vector3(0, 0, 360), 0.5f, RotateMode.FastBeyond360) //��b��360�x��]������
                .SetEase(Ease.Linear)); //���̑��x�ŉ�]������
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
        _timeText.text = $"�c�莞��{(int)GameManager.Instance.CurrentTime}�b...";
    }
}
