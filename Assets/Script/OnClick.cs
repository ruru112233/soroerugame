using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;
using UnityEngine.UI;
using Panel;
using System.Threading;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    public ColorController colorController;
    public ScoreManager scoreManager;
    public ComboManager comboManager;
    public LineCheckManager lineCheckManager;

    private GameManager gameManager;

    // 削除したLINEの数を表示
    public Text deleteLineText;


    public PanelManager panelManager;

    List<List<int>> colorNum;

    bool onClickFlag = true;

    private void Start()
    {
        if(colorController) colorNum = colorController.InitColorNum;
        gameManager = GameManager.instance;
    }

    // リトライボタン
    public void ReTryButton()
    {
        AudioManager.instance.PlaySE(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // タイトル画面に戻る
    public void TitleButton()
    {
        AudioManager.instance.PlaySE(0);
        SceneManager.LoadScene("TitleScene");
    }

    // 1行目の右側のボタン（行を左に動かす）
    public void oneRowRightButton()
    {

        if (!onClickFlag) return;

        ButtonClick();

        colorNum[0].Add(Util.RandNum());

        gameManager.OneRow++;

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 2行目の右側のボタン（行を左に動かす）
    public void twoRowRightButton()
    {
        if (!onClickFlag) return;

        ButtonClick();

        colorNum[1].Add(Util.RandNum());

        gameManager.TwoRow++;

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 3行目の右側のボタン（行を左に動かす）
    public void threeRowRightButton()
    {
        if (!onClickFlag) return;
        
        ButtonClick();

        colorNum[2].Add(Util.RandNum());

        gameManager.ThreeRow++;

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 4行目の右側のボタン（行を左に動かす）
    public void fourRowRightButton()
    {
        if (!onClickFlag) return;

        ButtonClick();

        colorNum[3].Add(Util.RandNum());

        gameManager.FourRow++;

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 5行目の右側のボタン（行を左に動かす）
    public void fiveRowRightButton()
    {
        if (!onClickFlag) return;

        ButtonClick();

        colorNum[4].Add(Util.RandNum());

        gameManager.FiveRow++;

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 1行目の左側のボタン（行を右に動かす）
    public void oneRowLeftButton()
    {
        if (!onClickFlag) return;

        ButtonClick();

        colorNum[0].Insert(0, Util.RandNum());

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 2行目の左側のボタン（行を右に動かす）
    public void twoRowLeftButton()
    {
        if (!onClickFlag) return;

        ButtonClick();

        colorNum[1].Insert(0, Util.RandNum());

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 3行目の左側のボタン（行を右に動かす）
    public void threeRowLeftButton()
    {
        if (!onClickFlag) return;

        ButtonClick();

        colorNum[2].Insert(0, Util.RandNum());

        ChengePanelColor(colorNum);
        
        lineCheck();
    }

    // 4行目の左側のボタン（行を右に動かす）
    public void fourRowLeftButton()
    {
        if (!onClickFlag) return;

        ButtonClick();

        colorNum[3].Insert(0, Util.RandNum());

        ChengePanelColor(colorNum);

        lineCheck();
    }

    // 5行目の左側のボタン（行を右に動かす）
    public void fiveRowLeftButton()
    {
        if (!onClickFlag) return;

        ButtonClick();

        colorNum[4].Insert(0, Util.RandNum());

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
                    rowNum = gameManager.OneRow;
                    break;
                case 1:
                    rowNum = gameManager.TwoRow;
                    break;
                case 2:
                    rowNum = gameManager.ThreeRow;
                    break;
                case 3:
                    rowNum = gameManager.FourRow;
                    break;
                case 4:
                    rowNum = gameManager.FiveRow;
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

    void ButtonClick()
    {
        AudioManager.instance.PlaySE(0);
    }

    void lineCheck()
    {
        bool line1 = Util.CheckAlign(colorNum, 1, gameManager.OneRow, gameManager.TwoRow, gameManager.ThreeRow, gameManager.FourRow, gameManager.FiveRow);
        bool line2 = Util.CheckAlign(colorNum, 2, gameManager.OneRow, gameManager.TwoRow, gameManager.ThreeRow, gameManager.FourRow, gameManager.FiveRow);
        bool line3 = Util.CheckAlign(colorNum, 3, gameManager.OneRow, gameManager.TwoRow, gameManager.ThreeRow, gameManager.FourRow, gameManager.FiveRow);
        bool line4 = Util.CheckAlign(colorNum, 4, gameManager.OneRow, gameManager.TwoRow, gameManager.ThreeRow, gameManager.FourRow, gameManager.FiveRow);
        bool line5 = Util.CheckAlign(colorNum, 5, gameManager.OneRow, gameManager.TwoRow, gameManager.ThreeRow, gameManager.FourRow, gameManager.FiveRow);

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
        deleteLineText.text = delLineCount.ToString() + "けし";

        yield return new WaitForSeconds(1.0f);

        deleteLineText.text = "";
    }

    IEnumerator LineClear(List<List<int>> colorNum, 
                   int lineNum)
    {
        AudioManager.instance.PlaySE(2);

        lineCheckManager.DelLine++;

        onClickFlag = false;

        int xNum = 0;
        int n = 0;

        bool colorCheck = true;

        for (int y = 0; y < 5; y++)
        {

            switch (y)
            {
                case 0:
                    n = gameManager.OneRow;
                    break;
                case 1:
                    n = gameManager.TwoRow;
                    break;
                case 2:
                    n = gameManager.ThreeRow;
                    break;
                case 3:
                    n = gameManager.FourRow;
                    break;
                case 4:
                    n = gameManager.FiveRow;
                    break;
            }

            xNum = lineNum - 1 + n;

            colorNum[y][xNum] = 0;

        }

        ChengePanelColor(colorNum);

        yield return new WaitForSeconds(0.5f);

        while (colorCheck)
        {
            for (int y = 0; y < 5; y++)
            {

                switch (y)
                {
                    case 0:
                        n = gameManager.OneRow;
                        break;
                    case 1:
                        n = gameManager.TwoRow;
                        break;
                    case 2:
                        n = gameManager.ThreeRow;
                        break;
                    case 3:
                        n = gameManager.FourRow;
                        break;
                    case 4:
                        n = gameManager.FiveRow;
                        break;
                }

                xNum = lineNum - 1 + n;

                colorNum[y][xNum] = Util.RandNum();

            }

            colorCheck = Util.CheckAlign(colorNum,
                               lineNum,
                               gameManager.OneRow,
                               gameManager.TwoRow,
                               gameManager.ThreeRow,
                               gameManager.FourRow,
                               gameManager.FiveRow);

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
