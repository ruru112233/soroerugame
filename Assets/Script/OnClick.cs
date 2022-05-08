using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;
using UnityEngine.UI;
using Panel;

public class OnClick : MonoBehaviour
{
    public ColorController colorController;

    // �e�s�̏����ʒu���擾
    int oneRow = 0;
    int twoRow = 0;
    int threeRow = 0;
    int fourRow = 0;
    int fiveRow = 0;

    // �e��̏����ʒu���擾
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

    // 1�s�ڂ̉E���̃{�^���i�s�����ɓ������j
    public void oneRowRightButton()
    {

        colorNum[0].Add(RandNum());

        oneRow++;

        ChengePanelColor(colorNum);

    }

    // 2�s�ڂ̉E���̃{�^���i�s�����ɓ������j
    public void twoRowRightButton()
    {

        colorNum[1].Add(RandNum());

        twoRow++;

        ChengePanelColor(colorNum);

    }

    // 3�s�ڂ̉E���̃{�^���i�s�����ɓ������j
    public void threeRowRightButton()
    {

        colorNum[2].Add(RandNum());

        threeRow++;

        ChengePanelColor(colorNum);

    }

    // 4�s�ڂ̉E���̃{�^���i�s�����ɓ������j
    public void fourRowRightButton()
    {

        colorNum[3].Add(RandNum());

        fourRow++;

        ChengePanelColor(colorNum);

    }

    // 5�s�ڂ̉E���̃{�^���i�s�����ɓ������j
    public void fiveRowRightButton()
    {

        colorNum[4].Add(RandNum());

        fiveRow++;

        ChengePanelColor(colorNum);

    }

    // 1�s�ڂ̍����̃{�^���i�s���E�ɓ������j
    public void oneRowLeftButton()
    {

        colorNum[0].Insert(0, RandNum());

        ChengePanelColor(colorNum);

    }

    // 2�s�ڂ̍����̃{�^���i�s���E�ɓ������j
    public void twoRowLeftButton()
    {

        colorNum[1].Insert(0, RandNum());

        ChengePanelColor(colorNum);

    }

    // 3�s�ڂ̍����̃{�^���i�s���E�ɓ������j
    public void threeRowLeftButton()
    {

        colorNum[2].Insert(0, RandNum());

        ChengePanelColor(colorNum);

    }

    // 4�s�ڂ̍����̃{�^���i�s���E�ɓ������j
    public void fourRowLeftButton()
    {

        colorNum[3].Insert(0, RandNum());

        ChengePanelColor(colorNum);

    }

    // 5�s�ڂ̍����̃{�^���i�s���E�ɓ������j
    public void fiveRowLeftButton()
    {

        colorNum[4].Insert(0, RandNum());

        ChengePanelColor(colorNum);

    }

    // 1�s�ڂ̗�̏�̃{�^���i������ɓ������j
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

    // 1�s�ڂ̗�̉��̃{�^���i�����ɓ������j
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
