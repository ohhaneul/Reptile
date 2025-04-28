using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject gameOverUI;



    [SerializeField]
    private float moveSpeed = 7f;
    private Rigidbody2D rb;
    private Vector2 movement;
    //순보 //다른 스크립트에서 쓸 수도 있ㅇ츠니까 serialize...private로 안했음...
    public float runDistance = 5f; // 이동 거리
    public float runTime = 0.1f;   // 이동 시간

    public float DefaultRunCooldown = 3; // 임시로 3으로 해놨어요

    private bool canRun = true;
    private SpriteRenderer sr;

    public bool isPaused = true;    // 321카운트

    // 체력, 마나 능력치
    public Slider HP;
    public Slider SP;

    public float hp = 1f;     // 체력 (1 = 100%)
    public float sp = 1f;    // 마나 (1 = 100%)

    private float moveTimer = 0f;
    private float spTimer = 0f;
    private bool isMoving = false;

    private bool isDead = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isPaused || isDead) return; // 멈춘 상태면 Update 아예 건너뜀

        movement.x = Input.GetAxisRaw("Horizontal"); // A(-1) D(+1)
        movement.y = Input.GetAxisRaw("Vertical");   // W(+1) S(-1)

        isMoving = movement.sqrMagnitude > 0;

        if (movement.x > 0)
        {
            sr.flipX = false;   // 오른쪽 바라봄
        }
        else if (movement.x < 0)
        {
            sr.flipX = true;    // 왼쪽 바라봄
        }

        if (Input.GetMouseButtonDown(0) && canRun)
        {
            // 클릭한 방향으로
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 이렇게 움직인다 (방향)
            Vector2 direction = (clickPosition - (Vector2)transform.position).normalized;
            // 스프라이트 방향은
            if (direction.x > 0)
            {
                sr.flipX = false;  
            }
            else if (direction.x < 0)
            {
                sr.flipX = true;  
            }
            StartCoroutine(Run(direction));

            // 순보 쓰면 마나 까임
            sp -= 0.3f;
            sp = Mathf.Clamp(sp, 0f, 1f);
        }
        moveTimer += Time.deltaTime;
        spTimer += Time.deltaTime;

        if (moveTimer >= 1f)
        {
            if (isMoving)
            {
                hp -= 0.05f; // 이동하면 체력 감소
                hp = Mathf.Clamp(hp, 0f, 1f);

                sp += 0.1f; // 이동하면 마나 회복
                sp = Mathf.Clamp(sp, 0f, 1f);
            }

            moveTimer = 0f; // 리셋
        }


        if (spTimer >= 1f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                sp -= 0.1f; // 스페이스바 누르면 마나 감소
                sp = Mathf.Clamp(sp, 0f, 1f);
                hp += 0.02f; // 감염+흡혈이라 치자
                hp = Mathf.Clamp(hp, 0f, 1f);
            }


            spTimer = 0f; // 리셋
        }

        if (hp <= 0f && !isDead)
        {
            Die();
        }
        UpdateUI();

    }
    void FixedUpdate()
    {
        if (isPaused || isDead) return; // 멈춘 상태면 FixedUpdate도 무시

        // 방향만 남기고, 벡터의 크기를 1로 만들고 싶을 때 사용
        // 라고 하는데.. 조금 더 알아봐야 할 것 같음! 
        rb.linearVelocity = movement.normalized * moveSpeed;
    }

    private System.Collections.IEnumerator Run(Vector2 direction)
    {
        if (sp <= 0f)
        {
            Debug.Log("마나 없어서 순보 불가!!");
            yield break; // 마나 없으면 달리기 ㄴㄴ
        }

        canRun = false;

        Vector2 startPosition = transform.position;
        Vector2 targetPosition = startPosition + direction * runDistance;

        float elapsedTime = 0f;

        while (elapsedTime < runTime)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime / runTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        yield return new WaitForSeconds(DefaultRunCooldown); // 쿨타임 기다리기
        canRun = true;
    }
    private void Die()
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        movement = Vector2.zero;
        Debug.Log("깨꼬닥");
        gameOverUI.SetActive(true);
    }
    private void UpdateUI()
    {
        if (HP != null)
            HP.value = hp;

        if (SP != null)
            SP.value = sp;
    }

}