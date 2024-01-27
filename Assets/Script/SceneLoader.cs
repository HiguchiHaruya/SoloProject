using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SceneName;
    [SerializeField] Image _fadeimage;
    Button _bt;
    private void Start()
    {
        _bt = GetComponent<Button>();
        _bt.onClick.AddListener(Call);
    }
    void Call()
    {
        StartCoroutine(SceneLoad(SceneName));
    }
    IEnumerator SceneLoad(string name)
    {
        float fadeDuration = 3.0f;
        float timer = 0;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            _fadeimage.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(name);
    }
}
