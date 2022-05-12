using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;
using UnityEngine.UI;
using Panel;
using System.Threading;

public class OnClick : MonoBehaviour
{
    public ColorController colorController;
    public ScoreManager scoreManager;
    public ComboManager comboManager;

    // 削除したLINEの数を表示
    public Text deleteLineText;

    // 各行の初期位置を取得
    int oneRow = 0;
    int twoRow = 0;
    int threeRow = 0;
    int fourRow = 0;
    int fiveRow = 0;

    public PanelManager panelManager;

    List<List<int>> colorNum;

    bool onClickFlag = true;

    private void Start()
    {
        colorNum = colorController.InitColorNum;
    }

    // 1行目の右側のボタン（行を左に動かす）
    public void oneRowRightButton()
    {

        if (!onClickFlag) return;

        colorNum[0].Add(RandNum());

        oneRow++;

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 2行目の右側のボタン（行を左に動かす）
    public void twoRowRightButton()
    {
        if (!onClickFlag) return;

        colorNum[1].Add(RandNum());

        twoRow++;

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 3行目の右側のボタン（行を左に動かす）
    public void threeRowRightButton()
    {
        if (!onClickFlag) return;

        colorNum[2].Add(RandNum());

        threeRow++;

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 4行目の右側のボタン（行を左に動かす）
    public void fourRowRightButton()
    {
        if (!onClickFlag) return;

        colorNum[3].Add(RandNum());

        fourRow++;

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 5行目の右側のボタン（行を左に動かす）
    public void fiveRowRightButton()
    {
        if (!onClickFlag) return;

        colorNum[4].Add(RandNum());

        fiveRow++;

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 1行目の左側のボタン（行を右に動かす）
    public void oneRowLeftButton()
    {
        if (!onClickFlag) return;

        colorNum[0].Insert(0, RandNum());

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 2行目の左側のボタン（行を右に動かす）
    public void twoRowLeftButton()
    {
        if (!onClickFlag) return;

        colorNum[1].Insert(0, RandNum());

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 3行目の左側のボタン（行を右に動かす）
    public void threeRowLeftButton()
    {
        if (!onClickFlag) return;

        colorNum[2].Insert(0, RandNum());

        ChengePanelColor(colorNum);
        
        lineCheck();
    }

    // 4行目の左側のボタン（行を右に動かす）
    public void fourRowLeftButton()
    {
        if (!onClickFlag) return;

        colorNum[3].Insert(0, RandNum());

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 5行目の左側のボタン（行を右に動かす）
    public void fiveRowLeftButton()
    {
        if (!onClickFlag) return;

        colorNum[4].Insert(0, RandNum());

        ChengePanelColor(colorNum);

        lineCheck();
    }

    void ChengePanelColor(List<List<int>> colorNum)
    {

        int rowNum = 0;
        int elementCount = 0;

        for (int y = 0; y < 5; y++)
        {
            switch (y)
            {
                case 0:
                    rowNum = this.oneRow;
                    break;
                case 1:
                    rowNum = this.twoRow;
                    break;
                case 2:
                    rowNum = this.threeRow;
                    break;
                case 3:
                    rowNum = this.fourRow;
                    break;
                case 4:
                    rowNum = this.fiveRow;
                    break;
            }

            for (int x = rowNum; x < rowNum + 5; x++)
            {

                Image image = panelManager.panelImageList[elementCount].GetComponent<Image>();

                int colorNum1 = colorNum[y][x];

                image.color = Util.selectColor(colorNum1);

                elementCount++;
            }
        }

    }

    int RandNum()
    {
        int randNum = Random.Range(1, 6);

        return randNum;
    }

    void lineCheck()
    {
        bool line1 = Util.CheckAlign(colorNum, 1, oneRow, twoRow, threeRow, fourRow, fiveRow);
        bool line2 = Util.CheckAlign(colorNum, 2, oneRow, twoRow, threeRow, fourRow, fiveRow);
        bool line3 = Util.CheckAlign(colorNum, 3, oneRow, twoRow, threeRow, fourRow, fiveRow);
        bool line4 = Util.CheckAlign(colorNum, 4, oneRow, twoRow, threeRow, fourRow, fiveRow);
        bool line5 = Util.CheckAlign(colorNum, 5, oneRow, twoRow, threeRow, fourRow, fiveRow);

        if (line1)
        {
            StartCoroutine(LineClear(colorNum, 1));
        }

        if (line2)
        {
            StartCoroutine(LineClear(colorNum, 2));
        }

        if (line3)
        {
            StartCoroutine(LineClear(colorNum, 3));
        }

        if (line4)
        {
            StartCoroutine(LineClear(colorNum, 4));
        }

        if (line5)
        {
            StartCoroutine(LineClear(colorNum, 5));
        }

        int matchCounter = LineMatchCount(line1, line2, line3, line4, line5);

        if(matchCounter != 0)
        {
            // 消したLINE数を表示
            int delLineCount = LineMatchCount(line1, line2, line3, line4, line5);

            StartCoroutine(DelLineTextUpdate(delLineCount));

            // スコアのカウント
            scoreManager.ScoreCount(comboManager.ComboCount(matchCounter), matchCounter);

        }
    }

    IEnumerator DelLineTextUpdate(int delLineCount)
    {
        deleteLineText.text = delLineCount.ToString() + "つ消し";

        yield return new WaitForSeconds(1.5f);

        deleteLineText.text = "";
    }

    IEnumerator LineClear(List<List<int>> colorNum, 
                   int lineNum)
    {

        onClickFlag = false;

        int xNum = 0;
        int n = 0;

        for (int y = 0; y < 5; y++)
        {

            switch (y)
            {
                case 0:
                    n = this.oneRow;
                    break;
                case 1:
                    n = this.twoRow;
                    break;
                case 2:
                    n = this.threeRow;
                    break;
                case 3:
                    n = this.fourRow;
                    break;
                case 4:
                    n = this.fiveRow;
                    break;
            }

            xNum = lineNum - 1 + n;

            colorNum[y][xNum] = 0;

        }

        ChengePanelColor(colorNum);

        yield return new WaitForSeconds(0.5f);

        for (int y = 0; y < 5; y++)
        {

            switch (y)
            {
                case 0:
                    n = this.oneRow;
                    break;
                case 1:
                    n = this.twoRow;
                    break;
                case 2:
                    n = this.threeRow;
                    break;
                case 3:
                    n = this.fourRow;
                    break;
                case 4:
                    n = this.fiveRow;
                    break;
            }

            xNum = lineNum - 1 + n;

            colorNum[y][xNum] = RandNum();

        }

        ChengePanelColor(colorNum);

        onClickFlag = true;
    }


    int LineMatchCount(bool line1,
                       bool line2,
                       bool line3,
                       bool line4,
                       bool line5)
    {
        int counter = 0;

        if (line1) counter++;

        if (line2) counter++;

        if (line3) counter++;

        if (line4) counter++;

        if (line5) counter++;

        return counter;
    }


}
