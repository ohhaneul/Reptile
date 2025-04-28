using UnityEngine;

public class Human : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float moveDistance = 10f;
    public bool canMove = true;
    public bool isInfected = false;

    public float originalSpeed;    // 원래속도


    private Vector2 moveDirection;
    private Vector2 startPos;
    private Rigidbody2D rb;
    private SpriteRenderer sr;  // 스프라이트 조정할때 

    private bool directionChangedByCollision = false;

    public bool isPaused = true;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();    // 사이즈 안 건들고 좌우대칭 하려고...
        rb = GetComponent<Rigidbody2D>();

        originalSpeed = moveSpeed;
        PickRandomDirection();
        startPos = rb.position;
    }


    void FixedUpdate()
    {

        if (isPaused || !canMove) return;

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        // float 뒤에 소수점 살짝 남아서 이동속도를 0으로 해도 살짝 움직임.. 근데 나름 애니메이션같고 ㄱㅊ

        if (!directionChangedByCollision && Vector2.Distance(startPos, rb.position) >= moveDistance)
        {
            PickRandomDirection();
            startPos = rb.position; // 새 시작점 갱신
        }
        directionChangedByCollision = false;
    }


    public void PickRandomDirection()
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        // 현재 이동 방향 제외
        Vector2[] validDirections = System.Array.FindAll(directions, d => d != moveDirection);

        moveDirection = validDirections[Random.Range(0, validDirections.Length)];

        if (moveDirection == Vector2.right)
        {
            sr.flipX = true;
        }
        else if (moveDirection == Vector2.left)
        {
            sr.flipX = false;
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            //Debug.Log(" 교통사고 " );
            PickRandomDirection();
            startPos = rb.position;
            directionChangedByCollision = true;
        }

    }


    public void ResetStartPos()
    {
        startPos = rb.position;
    }


}
