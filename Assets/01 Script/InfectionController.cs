using UnityEngine;

// 순수 감염기능 스크립트

public class InfectionController : MonoBehaviour
{
    private Human targetHuman;  // 움직임만 담당하면 휴먼 스크립트 가져와서 타겟으로 삼기
    private float infectionProgress = 0f;
    public float infectionTime = 3f;    // 나중에 강화기능 추가됐을때 시간 줄일 수 있도록

    private AudioSource infectionSound;


    private void Start()
    {
        infectionSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (targetHuman != null && !targetHuman.isInfected)
        {
            // 소리
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (infectionSound != null)
                    infectionSound.Play();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (!targetHuman.isInfected)
                {
                    float rounded = Mathf.Floor(infectionProgress * 2f) / 2f;
                    Debug.Log($"[스페이스바 누름] 감염 진행 시간: {rounded}초");
                    infectionProgress += Time.deltaTime;

                    targetHuman.moveSpeed = 0f;

                    if (infectionProgress >= infectionTime)
                    {
                        Infect(targetHuman);
                    }
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {   
                // 소리
                if (infectionSound != null)
                    infectionSound.Stop();

                Debug.Log("[스페이스바 뗌] 감염 시도 중단됨");
                infectionProgress = 0f; // 다시 0으로
                if (!targetHuman.isInfected)
                {
                    targetHuman.moveSpeed = targetHuman.originalSpeed; //  다시 원래 속도로 복구
                    targetHuman.ResetStartPos();
                    targetHuman.PickRandomDirection();
                    Debug.Log("감염 실패 → 다시 움직이게 함");
                }
            }

        }
    }

    private void Infect(Human human)
    {
        infectionProgress = 0f; // 한명 완료하고 겹친 캐릭터 바로 0퍼부터 시작하기 위해 초기화
        human.isInfected = true;
        human.moveSpeed = human.originalSpeed;
        human.GetComponent<SpriteRenderer>().color = Color.green;
        Debug.Log("감염 완료!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Human"))
        {
            targetHuman = other.GetComponent<Human>();
            Debug.Log("닿음");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Human"))
        {
            Debug.Log("안닿음");
            // 도중에 콜라이더 벗어나면 도망
            if (!targetHuman.isInfected)
            {
                targetHuman.moveSpeed = targetHuman.originalSpeed;
                targetHuman.ResetStartPos();
                targetHuman.PickRandomDirection();
                Debug.Log("감염 시도 도중 대상 놓침 → 이동 재개");
            }
            targetHuman = null;
            infectionProgress = 0f;
        }
    }
}