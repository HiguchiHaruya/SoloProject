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
        _finalScoreText.text = $"最終スコア : {finalScore}";
    }

    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタ上で実行停止
        Application.Quit();
#endif
    }
}
