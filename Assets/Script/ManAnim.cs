using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAnim : MonoBehaviour
{
    Animator _anim;
    void Start()
    {
        Debug.Log("marrro");
        _anim = GetComponent<Animator>();
        StartCoroutine(Anim() );    
    }

    IEnumerator Anim()
    {
        yield return new WaitForSeconds(2f);
        _anim.SetTrigger("ƒnƒ“ƒ}[“Š‚°");
    }
    void Update()
    {
        
    }
}
