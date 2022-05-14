using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text timerText;

    float timeCount = 60.0f;

    bool rankingViewFlag = false;

    public float TimeCount
    {
        get => timeCount;
        set => timeCount = value;
    }

    private void Start()
    {
        timerText.text = timeCount.ToString();
    }

    private void Update()
    {
        timeCount -= Time.deltaTime;

        if (timeCount <= 0)
        {
            timeCount = 0;

            // ƒ‰ƒ“ƒLƒ“ƒO‚Ì•\Ž¦
            if (!rankingViewFlag)
            {
                rankingViewFlag = true;
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking(GameManager.instance.scoreManager.ScorePoint);
            }
        }

        timerText.text = timeCount.ToString("F0");
    }

}
