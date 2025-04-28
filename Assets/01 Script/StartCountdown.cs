using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class StartCountdown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public Player player;
    public Human[] humans; 

    private void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(0.7f);

        countdownText.text = "2";
        yield return new WaitForSeconds(0.7f);

        countdownText.text = "1";
        yield return new WaitForSeconds(0.7f);

        countdownText.text = "START";
        yield return new WaitForSeconds(0.4f);

        countdownText.gameObject.SetActive(false); // 텍스트 숨기기

        player.isPaused = false; // 플레이어 움직임 시작
        foreach (var human in humans)
        {
            human.isPaused = false; // 모든 휴먼도 움직임 시작
        }
    }
}
