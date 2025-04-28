using UnityEngine;

public class Human : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float moveDistance = 10f;
    public bool canMove = true;
    public bool isInfected = false;

    public float originalSpeed;    // �����ӵ�


    private Vector2 moveDirection;
    private Vector2 startPos;
    private Rigidbody2D rb;
    private SpriteRenderer sr;  // ��������Ʈ �����Ҷ� 

    private bool directionChangedByCollision = false;

    public bool isPaused = true;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();    // ������ �� �ǵ�� �¿��Ī �Ϸ���...
        rb = GetComponent<Rigidbody2D>();

        originalSpeed = moveSpeed;
        PickRandomDirection();
        startPos = rb.position;
    }


    void FixedUpdate()
    {

        if (isPaused || !canMove) return;

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        // float �ڿ� �Ҽ��� ��¦ ���Ƽ� �̵��ӵ��� 0���� �ص� ��¦ ������.. �ٵ� ���� �ִϸ��̼ǰ��� ����

        if (!directionChangedByCollision && Vector2.Distance(startPos, rb.position) >= moveDistance)
        {
            PickRandomDirection();
            startPos = rb.position; // �� ������ ����
        }
        directionChangedByCollision = false;
    }


    public void PickRandomDirection()
    {
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        // ���� �̵� ���� ����
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
            //Debug.Log(" ������ " );
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
