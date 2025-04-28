using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource clickAudioSource;
    private Button btn;

    // 원래 start() 쓸랬는데, false로 로딩되는 UI가 잡히지 않음.
    // 그래서 가능 불가능으로 나눠서 중간중간 정리해주면서 로딩하도록 함!



    private void Awake()
    {
        btn = GetComponent<Button>();
        if (btn == null)
        {
            Debug.Log("Button 컴포넌트 못 찾음...");
        }
    }

    private void OnEnable()
    {
            Debug.Log("OnEnable 호출됨!");

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
        Debug.Log("버튼 클릭");
    }
}
