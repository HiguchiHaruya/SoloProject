using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SceneLoader : MonoBehaviour
{
    public string SceneName; //移行先のシーン名
    [SerializeField] Image _fadeimage; //フェードアウト用のImage
    public static SceneLoader Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
    }
    public void GetLoadScene(string SceneName) //他のクラスが参照するメソッド
    {
        StartCoroutine(SceneLoad(SceneName));
    }
    public IEnumerator SceneLoad(string SceneName)
    {
        float fadeDuration = 1.5f;
        float timer = 0;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            _fadeimage.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(SceneName);
    }
}
