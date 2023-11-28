using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Rotate : MonoBehaviour
{
    Playercontroller controller = new Playercontroller();
    [HideInInspector] public int _rotateSpeed = 3;
    void Start()
    {

    }
   public int ChangeSpeed(int combo)
    {
        if (combo > 10)
        {
            return 5;
        }
        if (combo > 20)
        {
            return 8;
        }
        if (combo > 25)
        {
            return 15;
        }
        return 3;
    }
    public void Update()
    {
        Debug.Log(controller._combo);
        this.gameObject.transform.Rotate(Vector3.down * ChangeSpeed(controller._combo));
        float horizon = -Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizon, 0, 0);
        GetComponent<Rigidbody>().velocity = movement * 2;
    }
}
