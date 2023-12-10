using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] AudioSource _ClickSound;
    void Start()
    {
        Button _btn = GetComponent<Button>();
        _btn.onClick.AddListener(Call);
    }
    void Call()
    {
        _ClickSound.Play();
        StartCoroutine(SwitchScene());
    }
    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("");
    }
    void Update()
    {

    }
}
