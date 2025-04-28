using UnityEngine;

public class RightLeft : MonoBehaviour
{
    public float moveSpeed = 0.5f; // �̵� �ֱ� (�� �ʸ��� �� �� �� ��������)
    public float rightX = 0f; // ������ ��ǥ X ��ǥ
    public float leftX = -30f; // ���� ��ǥ X ��ǥ

    private float timer = 0f;
    private int direction = 1; // 1�̸� ������, -1�̸� ����
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
        // canvas�� transform.position�� �ƴ϶� transform.localPosition!!!!!!!
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= moveSpeed)
        {
            if (direction == 1)
            {
                transform.localPosition = new Vector3(startPosition.x + rightX, startPosition.y, startPosition.z);
            }
            else
            {
                transform.localPosition = new Vector3(startPosition.x + leftX, startPosition.y, startPosition.z);
            }

            direction *= -1;
            timer = 0f;
        }
    }

}
