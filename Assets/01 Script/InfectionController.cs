using UnityEngine;

// ���� ������� ��ũ��Ʈ

public class InfectionController : MonoBehaviour
{
    private Human targetHuman;  // �����Ӹ� ����ϸ� �޸� ��ũ��Ʈ �����ͼ� Ÿ������ ���
    private float infectionProgress = 0f;
    public float infectionTime = 3f;    // ���߿� ��ȭ��� �߰������� �ð� ���� �� �ֵ���

    private AudioSource infectionSound;


    private void Start()
    {
        infectionSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (targetHuman != null && !targetHuman.isInfected)
        {
            // �Ҹ�
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
                    Debug.Log($"[�����̽��� ����] ���� ���� �ð�: {rounded}��");
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
                // �Ҹ�
                if (infectionSound != null)
                    infectionSound.Stop();

                Debug.Log("[�����̽��� ��] ���� �õ� �ߴܵ�");
                infectionProgress = 0f; // �ٽ� 0����
                if (!targetHuman.isInfected)
                {
                    targetHuman.moveSpeed = targetHuman.originalSpeed; //  �ٽ� ���� �ӵ��� ����
                    targetHuman.ResetStartPos();
                    targetHuman.PickRandomDirection();
                    Debug.Log("���� ���� �� �ٽ� �����̰� ��");
                }
            }

        }
    }

    private void Infect(Human human)
    {
        infectionProgress = 0f; // �Ѹ� �Ϸ��ϰ� ��ģ ĳ���� �ٷ� 0�ۺ��� �����ϱ� ���� �ʱ�ȭ
        human.isInfected = true;
        human.moveSpeed = human.originalSpeed;
        human.GetComponent<SpriteRenderer>().color = Color.green;
        Debug.Log("���� �Ϸ�!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Human"))
        {
            targetHuman = other.GetComponent<Human>();
            Debug.Log("����");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Human"))
        {
            Debug.Log("�ȴ���");
            // ���߿� �ݶ��̴� ����� ����
            if (!targetHuman.isInfected)
            {
                targetHuman.moveSpeed = targetHuman.originalSpeed;
                targetHuman.ResetStartPos();
                targetHuman.PickRandomDirection();
                Debug.Log("���� �õ� ���� ��� ��ħ �� �̵� �簳");
            }
            targetHuman = null;
            infectionProgress = 0f;
        }
    }
}