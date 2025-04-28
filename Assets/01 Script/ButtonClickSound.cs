using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource clickAudioSource;
    private Button btn;

    // ���� start() �����µ�, false�� �ε��Ǵ� UI�� ������ ����.
    // �׷��� ���� �Ұ������� ������ �߰��߰� �������ָ鼭 �ε��ϵ��� ��!



    private void Awake()
    {
        btn = GetComponent<Button>();
        if (btn == null)
        {
            Debug.Log("Button ������Ʈ �� ã��...");
        }
    }

    private void OnEnable()
    {
            Debug.Log("OnEnable ȣ���!");

        if (btn != null && clickAudioSource != null)
        {
            btn.onClick.AddListener(PlayClickSound);
        }
    }

    private void OnDisable()
    {
        if (btn != null)
        {
            btn.onClick.RemoveListener(PlayClickSound);
        }
    }

    private void PlayClickSound()
    {
        clickAudioSource.Play();
        Debug.Log("��ư Ŭ��");
    }
}
