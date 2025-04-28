using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject StageUI;
    public GameObject CharacterUI;
    public GameObject YetUI;

    public void OnstageSelected()   // �������� �����ϸ� ĳ���� ������
    {
        StageUI.SetActive(false);
        CharacterUI.SetActive(true);
    }

    public void OnCharaterSelected()   // ���������� ĳ���� ���� �������� ������
    {
        StageUI.SetActive(true);
        CharacterUI.SetActive(false);
    }

    public void OnYet()  
    {
    StartCoroutine(ShowYet());
    }
    private System.Collections.IEnumerator ShowYet()
    {
        YetUI.SetActive(true); 
        yield return new WaitForSeconds(0.7f);  
        YetUI.SetActive(false); 
    }

}
