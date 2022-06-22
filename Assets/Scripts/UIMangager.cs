using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMangager : MonoBehaviour
{
    public Text LeftPlayerScoreText;
    public Text RightPlayerScoreText;

    public Text CountDownText;

    public void SetLeftPlayerScore(string score)
    {
        LeftPlayerScoreText.text = score;
    }

    public void SetRightPlayerScore(string score)
    {
        RightPlayerScoreText.text = score;
    }

    public void StartCountDown(float CountDownDuration)
    {
        StartCoroutine(ShowCountDownCorrutine(CountDownDuration));
    }

    public IEnumerator ShowCountDownCorrutine(float CountDownDuration)
    {
        while (CountDownDuration >= 0)
        {
            CountDownText.text = ((int)CountDownDuration).ToString();
            yield return new WaitForSeconds(1);
            CountDownDuration--;
        }
        CountDownText.text = string.Empty;
    }
}