using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void ChooseStage()
    {
        SceneManager.LoadScene("ChooseStage");
        Debug.Log("�������� �������� �Ѿ��");

        Time.timeScale = 1f;
    }

    public void GoToOP()
    {
        SceneManager.LoadScene("OP");
        Debug.Log("OP�� �Ѿ��");

        Time.timeScale = 1f;
    }

    public void GoToSample()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("����ȭ������ �Ѿ��");

        Time.timeScale = 1f;
    }

    public void GoToStage1()
    {
        SceneManager.LoadScene("Stage1");
        Debug.Log("Stage1���� �Ѿ��");

        Time.timeScale = 1f;
    }

    public void GoToStage2()
    {
        SceneManager.LoadScene("Stage2");
        Debug.Log("Stage2�� �Ѿ��");

        Time.timeScale = 1f;
    }

    public void GoToStart()
    {
        SceneManager.LoadScene("Start");
        Debug.Log("����ȭ������ �Ѿ��");

        Time.timeScale = 1f;
    }


}



