using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class OP : MonoBehaviour
{
    // ���� �߸���� �̸� �ε��صδ� �ڵ夾��

    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnVideoPrepared; // �Լ����
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoPrepared(VideoPlayer vp)
    {
        vp.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("ChooseStage");
        Debug.Log("�Ѿ��");
    }
}
