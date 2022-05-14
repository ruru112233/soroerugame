using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ScoreManager scoreManager;
    public TimerManager timerManager;

    // Šes‚Ì‰ŠúˆÊ’u‚ðŽæ“¾
    int oneRow = 0;
    int twoRow = 0;
    int threeRow = 0;
    int fourRow = 0;
    int fiveRow = 0;

    public int OneRow { get => oneRow; set => oneRow = value; }

    public int TwoRow { get => twoRow; set => twoRow = value; }

    public int ThreeRow { get => threeRow; set => threeRow = value; }

    public int FourRow { get => fourRow; set => fourRow = value; }

    public int FiveRow { get => fiveRow; set => fiveRow = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        AudioManager.instance.PlayBGM(0);
    }

    public bool AllColorLineCheck(List<List<int>> colorNum)
    {
        bool line1 = Util.CheckAlign(colorNum, 1, oneRow, twoRow, threeRow, fourRow, fiveRow);
        bool line2 = Util.CheckAlign(colorNum, 2, oneRow, twoRow, threeRow, fourRow, fiveRow);
        bool line3 = Util.CheckAlign(colorNum, 3, oneRow, twoRow, threeRow, fourRow, fiveRow);
        bool line4 = Util.CheckAlign(colorNum, 4, oneRow, twoRow, threeRow, fourRow, fiveRow);
        bool line5 = Util.CheckAlign(colorNum, 5, oneRow, twoRow, threeRow, fourRow, fiveRow);

        if (!line1 && !line2 && !line3 && !line4 && !line5)
        {
            return false;
        }

        return true;

    }


    public int RandNum()
    {
        int randNum = Random.Range(1, 4);

        return randNum;
    }


}
