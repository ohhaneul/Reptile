using UnityEngine;

public class UIStartManager : MonoBehaviour
{
    public GameObject ExplainUI;
    public GameObject HelpUI;

    public void OnEx()
    {
        ExplainUI.SetActive(true);
    }

    public void OffEx()
    {
        ExplainUI.SetActive(false);
    }

    public void OnHelp()
    {
        HelpUI.SetActive(true);
    }

    public void OffHelp()
    {
        HelpUI.SetActive(false);
    }

}
