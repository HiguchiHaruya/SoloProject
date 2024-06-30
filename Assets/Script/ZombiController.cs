using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombiController : MonoBehaviour
{
    [SerializeField] GameObject _zombiPrefab;
    List<GameObject> _zombiePool;
    private int _poolsize = 10; //ゾンビプールの初期のデカさ
    private float interval = 1f; //ゾンビの出現間隔
    public static ZombiController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        _zombiePool = new List<GameObject>();
        for (int i = 0; i < _poolsize; i++)
        {
            GameObject zombie = Instantiate(_zombiPrefab);
            zombie.SetActive(false);
            _zombiePool.Add(zombie);
            StartCoroutine(GenerateZombie());
        }
    }

    IEnumerator GenerateZombie()
    {
        while (!GameManager.Instance.IsEnd)
        {
            Vector3 pos = new Vector3
                ((UnityEngine.Random.Range(8, -8)), 0.5f,UnityEngine.Random.Range(-30f,-45) );
            GameObject zombie = GetZombie();
            zombie.transform.position = pos;
            yield return new WaitForSeconds(interval);
        }
    }
    private GameObject GetZombie()
    {
        foreach (GameObject zombie in _zombiePool)
        {
            if (!zombie.activeInHierarchy)
            {
                zombie.SetActive(true);
                return zombie;
            }
        }
        GameObject newZombie = Instantiate(_zombiPrefab); //プール拡張
        _zombiePool.Add(newZombie);
        newZombie.SetActive(true);
        return newZombie;
    }
    public void ReturnZombie(GameObject zombie)
    {
        zombie.SetActive(false);
    }
}
