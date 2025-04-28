using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject StageUI;
    public GameObject CharacterUI;
    public GameObject YetUI;

    public void OnstageSelected()   // 스테이지 선택하면 캐릭터 켜지고
    {
        StageUI.SetActive(false);
        CharacterUI.SetActive(true);
    }

    public void OnCharaterSelected()   // 엑스누르면 캐릭터 끄고 스테이지 나오고
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
