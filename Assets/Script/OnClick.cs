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

        ChengePanelColor(colorNum, oneRow, twoRow, threeRow, fourRow, fiveRow);

    }

    // 2行目の右側のボタン（行を左に動かす）
    public void twoRowRightButton()
    {

        colorNum[1].Add(RandNum());

        twoRow++;

        ChengePanelColor(colorNum, oneRow, twoRow, threeRow, fourRow, fiveRow);

    }

    // 3行目の右側のボタン（行を左に動かす）
    public void threeRowRightButton()
    {

        colorNum[2].Add(RandNum());

        threeRow++;

        ChengePanelColor(colorNum, oneRow, twoRow, threeRow, fourRow, fiveRow);

    }

    // 4行目の右側のボタン（行を左に動かす）
    public void fourRowRightButton()
    {

        colorNum[3].Add(RandNum());

        fourRow++;

        ChengePanelColor(colorNum, oneRow, twoRow, threeRow, fourRow, fiveRow);

    }

    // 5行目の右側のボタン（行を左に動かす）
    public void fiveRowRightButton()
    {

        colorNum[4].Add(RandNum());

        fiveRow++;

        ChengePanelColor(colorNum, oneRow, twoRow, threeRow, fourRow, fiveRow);

    }

    // 1行目の左側のボタン（行を右に動かす）
    public void oneRowLeftButton()
    {

        colorNum[0].Insert(0, RandNum());

        ChengePanelColor(colorNum, oneRow, twoRow, threeRow, fourRow, fiveRow);

    }

    // 2行目の左側のボタン（行を右に動かす）
    public void twoRowLeftButton()
    {

        colorNum[1].Insert(0, RandNum());

        ChengePanelColor(colorNum, oneRow, twoRow, threeRow, fourRow, fiveRow);

    }

    // 3行目の左側のボタン（行を右に動かす）
    public void threeRowLeftButton()
    {

        colorNum[2].Insert(0, RandNum());

        ChengePanelColor(colorNum, oneRow, twoRow, threeRow, fourRow, fiveRow);

    }

    // 4行目の左側のボタン（行を右に動かす）
    public void fourRowLeftButton()
    {

        colorNum[3].Insert(0, RandNum());

        ChengePanelColor(colorNum, oneRow, twoRow, threeRow, fourRow, fiveRow);

    }

    // 5行目の左側のボタン（行を右に動かす）
    public void fiveRowLeftButton()
    {

        colorNum[4].Insert(0, RandNum());

        ChengePanelColor(colorNum, oneRow, twoRow, threeRow, fourRow, fiveRow);

    }

    void ChengePanelColor(List<List<int>> colorNum, int oneRow, int twoRow, int threeRow, int fourRow, int fiveRow)
    {

        int rowNum = 0;
        int elementCount = 0;

        for (int y = 0; y < colorNum.Count; y++)
        {
            switch (y)
            {
                case 0:
                    rowNum = oneRow;
                    break;
                case 1:
                    rowNum = twoRow;
                    break;
                case 2:
                    rowNum = threeRow;
                    break;
                case 3:
                    rowNum = fourRow;
                    break;
                case 4:
                    rowNum = fiveRow;
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
}
