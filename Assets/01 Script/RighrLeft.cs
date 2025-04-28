using UnityEngine;

public class RightLeft : MonoBehaviour
{
    public float moveSpeed = 0.5f; // 이동 주기 (몇 초마다 한 번 띡 움직일지)
    public float rightX = 0f; // 오른쪽 목표 X 좌표
    public float leftX = -30f; // 왼쪽 목표 X 좌표

    private float timer = 0f;
    private int direction = 1; // 1이면 오른쪽, -1이면 왼쪽
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
        // canvas라서 transform.position이 아니라 transform.localPosition!!!!!!!
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
