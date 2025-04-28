using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)]
    private float followDistance = 7f;

    public Transform player;    // 따라갈 물체
    public Vector2 offset;
    /*public Vector3 offset; // 이르케 해도 되긴 한데 
     * 3d 게임이 아니라 굳이? 게다가 위에 카메라 줌 정도를 따로 해서 ㅇㅇ...*/

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // update 안 쓰는 이유 : 이동이랑 겹쳐서 딜레이 생길 수도 있음
    // lateupdate : 플레이어 이동이 끝난 뒤 위치를 반영해서 움직임 (순차적)
    void LateUpdate()
    {
        if (player != null)
        {
            // 카메라 위치를 플레이어 위치 + 오프셋으로 설정 (Z 값은 고정)
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

            // 카메라 줌(확대/축소) 설정
            if (cam.orthographic) // 2D 카메라인 경우
            {
                cam.orthographicSize = followDistance; // 카메라의 줌 (Z 값 대신 orthographicSize로 조정)
            }
        }
    }
}
