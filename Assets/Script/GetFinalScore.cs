using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFinalScore : MonoBehaviour
{
    [SerializeField] Text _finalScoreText;
    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        _finalScoreText.text = $"�ŏI�X�R�A : {finalScore}";
    }

    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �G�f�B�^��Ŏ��s��~
        Application.Quit();
#endif
    }
}
