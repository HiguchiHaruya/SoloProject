using UnityEngine;

public class Fence : MonoBehaviour
{
    public float speed = 45f; // �ړ����x
    public float distance = 2.5f; // ���E�̈ړ�����

    void Update()
    {
        if (UIManager.Instance.IsStart)
        {
            // �����ō��E�Ɉړ��ł�����
            float horizontalMovement = Mathf.Sin(Time.time * 45) * distance;
            transform.position = new Vector3(transform.position.x, transform.position.y, horizontalMovement);
        }
    }
}
