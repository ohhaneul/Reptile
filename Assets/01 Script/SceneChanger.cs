using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void ChooseStage()
    {
        SceneManager.LoadScene("ChooseStage");
        Debug.Log("스테이지 선택으로 넘어가기");

        Time.timeScale = 1f;
    }

    public void GoToOP()
    {
        SceneManager.LoadScene("OP");
        Debug.Log("OP로 넘어가기");

        Time.timeScale = 1f;
    }

    public void GoToSample()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("샘플화면으로 넘어가기");

        Time.timeScale = 1f;
    }

    public void GoToStage1()
    {
        SceneManager.LoadScene("Stage1");
        Debug.Log("Stage1으로 넘어가기");

        Time.timeScale = 1f;
    }

    public void GoToStage2()
    {
        SceneManager.LoadScene("Stage2");
        Debug.Log("Stage2로 넘어가기");

        Time.timeScale = 1f;
    }

    public void GoToStart()
    {
        SceneManager.LoadScene("Start");
        Debug.Log("시작화면으로 넘어가기");

        Time.timeScale = 1f;
    }


}



