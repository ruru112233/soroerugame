using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;
using UnityEngine.UI;
using Panel;

public class OnClick : MonoBehaviour
{
    public ColorController colorController;

    // 各行の初期位置を取得
    int oneRow = 0;
    int twoRow = 0;
    int threeRow = 0;
    int fourRow = 0;
    int fiveRow = 0;

    // 各列の初期位置を取得
    int oneColume = 0;
    int twoColume = 0;
    int threeColume = 0;
    int fourColume = 0;
    int fiveColume = 0;

    public PanelManager panelManager;

    List<List<int>> colorNum;

    private void Start()
    {
        colorNum = colorController.InitColorNum;
    }

    // 1行目の右側のボタン（行を左に動かす）
    public void oneRowRightButton()
    {

        colorNum[0].Add(RandNum());

        oneRow++;

        ChengePanelColor(colorNum);

    }

    // 2行目の右側のボタン（行を左に動かす）
    public void twoRowRightButton()
    {

        colorNum[1].Add(RandNum());

        twoRow++;

        ChengePanelColor(colorNum);

    }

    // 3行目の右側のボタン（行を左に動かす）
    public void threeRowRightButton()
    {

        colorNum[2].Add(RandNum());

        threeRow++;

        ChengePanelColor(colorNum);

    }

    // 4行目の右側のボタン（行を左に動かす）
    public void fourRowRightButton()
    {

        colorNum[3].Add(RandNum());

        fourRow++;

        ChengePanelColor(colorNum);

    }

    // 5行目の右側のボタン（行を左に動かす）
    public void fiveRowRightButton()
    {

        colorNum[4].Add(RandNum());

        fiveRow++;

        ChengePanelColor(colorNum);

    }

    // 1行目の左側のボタン（行を右に動かす）
    public void oneRowLeftButton()
    {

        colorNum[0].Insert(0, RandNum());

        ChengePanelColor(colorNum);

    }

    // 2行目の左側のボタン（行を右に動かす）
    public void twoRowLeftButton()
    {

        colorNum[1].Insert(0, RandNum());

        ChengePanelColor(colorNum);

    }

    // 3行目の左側のボタン（行を右に動かす）
    public void threeRowLeftButton()
    {

        colorNum[2].Insert(0, RandNum());

        ChengePanelColor(colorNum);

    }

    // 4行目の左側のボタン（行を右に動かす）
    public void fourRowLeftButton()
    {

        colorNum[3].Insert(0, RandNum());

        ChengePanelColor(colorNum);

    }

    // 5行目の左側のボタン（行を右に動かす）
    public void fiveRowLeftButton()
    {

        colorNum[4].Insert(0, RandNum());

        ChengePanelColor(colorNum);

    }

    // 1行目の列の上のボタン（列を下に動かす）
    public void OneColumnUpButton()
    {
        List<int> list = new List<int>() { RandNum(), RandNum(), RandNum(), RandNum(), RandNum() };

        colorNum.Add(list);
        oneColume++;

        for (int i = colorNum.Count - 1; i > 0; i--) 
        {
            colorNum[i][0] = colorNum[i-1][0];
        }

        colorNum[0][0] = RandNum();

        ChengePanelColumeColor(colorNum);

    }

    // 1行目の列の下のボタン（列を上に動かす）
    public void OneColumnDownButton()
    {
        List<int> list = new List<int>() { RandNum(), 0, 0, 0, 0 };

        colorNum.Insert(0,list);
        oneColume++;

        for (int i = 0; i < colorNum.Count - 1; i++)
        {
            colorNum[i][0] = colorNum[i + 1][0];
        }

        ChengePanelColumeColor(colorNum);

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

    void ChengePanelColumeColor(List<List<int>> colorNum)
    {

        int columeNum = 0;
        int elementCount = 0;

        int loopCount = 0;

        for (int y = columeNum; y < columeNum + 5; y++)
        {
            switch (loopCount)
            {
                case 0:
                    columeNum = this.oneColume;
                    break;
                case 1:
                    columeNum = this.twoColume;
                    break;
                case 2:
                    columeNum = this.threeColume;
                    break;
                case 3:
                    columeNum = this.fourColume;
                    break;
                case 4:
                    columeNum = this.fiveColume;
                    break;
            }

            for (int x = 0; x < 5; x++)
            {
                Image image = panelManager.panelImageList[elementCount].GetComponent<Image>();

                int colorNum1 = colorNum[y][x];

                image.color = Util.selectColor(colorNum1);

                elementCount++;
            }

            loopCount++;
        }

    }

    int RandNum()
    {
        int randNum = Random.Range(1, 6);

        return randNum;
    }
}
