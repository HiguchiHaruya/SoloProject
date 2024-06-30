using UnityEngine;

public class Fence : MonoBehaviour
{
    public float speed = 45f; // ˆÚ“®‘¬“x
    public float distance = 2.5f; // ¶‰E‚ÌˆÚ“®‹——£

    void Update()
    {
        if (UIManager.Instance.IsStart)
        {
            // ©“®‚Å¶‰E‚ÉˆÚ“®‚Å‚«‚é‚â‚Â
            float horizontalMovement = Mathf.Sin(Time.time * 45) * distance;
            transform.position = new Vector3(transform.position.x, transform.position.y, horizontalMovement);
        }
    }
}
