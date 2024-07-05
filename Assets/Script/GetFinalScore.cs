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
        SceneLoader.Instance.GetLoadScene("StartScene");
    }
}
