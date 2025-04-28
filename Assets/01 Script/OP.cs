using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class OP : MonoBehaviour
{
    // 영상 잘릴까봐 미리 로딩해두는 코드ㅎㅎ

    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnVideoPrepared; // 함수등록
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        vp.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("ChooseStage");
        Debug.Log("넘어간다");
    }
}
