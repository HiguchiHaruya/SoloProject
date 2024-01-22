using UnityEngine;

public class Fence : MonoBehaviour
{
    public float speed = 45f; // 移動速度
    public float distance = 2.5f; // 左右の移動距離

    void Update()
    {
        // 自動で左右に移動できるやつ
        float horizontalMovement = Mathf.Sin(Time.time * 45) * distance;
        transform.position = new Vector3(transform.position.x, transform.position.y, horizontalMovement);
    }
}
