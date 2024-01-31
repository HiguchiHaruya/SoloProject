using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Playercontroller : MonoBehaviour
{
    int currentscore = 0;
    bool _activebutton = false;
    [SerializeField] GameObject _scaleButton;
    [SerializeField] Button _scaleBT;
    [SerializeField] GameObject _bt2;
    // [SerializeField] Button _scaleBT;
    GameManager gm;
    public static event System.Action<int> ScoreChanged;
    /// <summary>ゾンビを殺した時のイベント</summary>
    [SerializeField] UnityEvent ZombieEveSound;
    [SerializeField] UnityEvent ZombieEveParticle;
    [SerializeField] Material _newMaterial;
    [SerializeField] Text _comboTxt;
    /// <summary>横移動のスピード</summary>
    [SerializeField] float _moveSpeed = 3f;
    /// <summary>コンボスコア</summary>
    [HideInInspector] public int _combo = 0;
    /// <summary>コンボを反映するテキスト</summary>
    public int _border = 50;
    void Start()
    {
        _scaleButton.SetActive(false);
        _bt2.SetActive(false);
        gm = FindAnyObjectByType<GameManager>();
        _scaleBT.onClick.AddListener(Call);
    }
    void Call()
    {
        Debug.Log(currentscore);
        this.gameObject.transform.localScale =
            new Vector3(ChangeScale(currentscore), ChangeScale(currentscore), ChangeScale(currentscore));
    }
    float ChangeScale(int newScore)
    {
        if (currentscore > 60)
        {
            _combo = 0;
            return 0.5f;
        }
        if (currentscore > 90)
        {
            _combo = 0;
            return 1f;
        }
        if (currentscore > 120)
        {
            _combo = 0;
            return 2;
        }

        return 0.1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _activebutton = !_activebutton;
            _scaleButton.SetActive(_activebutton);
            _bt2.SetActive(_activebutton);
        }
        //float horizon = -Input.GetAxis("Horizontal");
        //Vector3 movement = new Vector3(horizon, 0, 0);
        //GetComponent<Rigidbody>().velocity = movement * _moveSpeed;
    }

    private void LateUpdate()
    {
        // _im.DestroyImage(_combo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            _combo++;
            ZombieEveSound.Invoke();
            _comboTxt.text = string.Format("{0:0000}", _combo + "Combo!!!");
            currentscore = _combo;
        }
    }
}
