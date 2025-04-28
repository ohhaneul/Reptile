using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)]
    private float followDistance = 7f;

    public Transform player;    // ���� ��ü
    public Vector2 offset;
    /*public Vector3 offset; // �̸��� �ص� �Ǳ� �ѵ� 
     * 3d ������ �ƴ϶� ����? �Դٰ� ���� ī�޶� �� ������ ���� �ؼ� ����...*/

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // update �� ���� ���� : �̵��̶� ���ļ� ������ ���� ���� ����
    // lateupdate : �÷��̾� �̵��� ���� �� ��ġ�� �ݿ��ؼ� ������ (������)
    void LateUpdate()
    {
        if (player != null)
        {
            // ī�޶� ��ġ�� �÷��̾� ��ġ + ���������� ���� (Z ���� ����)
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

            // ī�޶� ��(Ȯ��/���) ����
            if (cam.orthographic) // 2D ī�޶��� ���
            {
                cam.orthographicSize = followDistance; // ī�޶��� �� (Z �� ��� orthographicSize�� ����)
            }
        }
    }
}
