using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    int scorePoint = 0;

    public int ScorePoint => scorePoint;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scorePoint.ToString();
    }

    public void ScoreCount(int comboCount, int lineCount)
    {
        scorePoint += (2 + lineCount) * comboCount;

        scoreText.text = scorePoint.ToString();
    }

}
