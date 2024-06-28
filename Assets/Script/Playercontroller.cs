using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Playercontroller : MonoBehaviour
{
    int currentscore = 0;
    public int Score => currentscore;
    /// <summary>ƒ]ƒ“ƒr‚ðŽE‚µ‚½Žž‚ÌƒCƒxƒ“ƒg</summary>
    [SerializeField] UnityEvent ZombieEveSound;
    float _moveSpeed = 10f;
    public static Playercontroller Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            ZombieEveSound.Invoke();
            currentscore++;
        }
    }
}
