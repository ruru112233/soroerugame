using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Util : MonoBehaviour
{
    public static Color selectColor(int colorNum)
    {

        Color color;
        
        if (colorNum == 1)
        {
            color = Color.red;
        }
        else if (colorNum == 2)
        {
            color = Color.yellow;
        }
        else if (colorNum == 3)
        {
            color = Color.green;
        }
        else if (colorNum == 4)
        {
            color = Color.blue;
        }
        else if (colorNum == 5)
        {
            color = Color.cyan;
        }
        else
        {
            color = Color.white;
        }

        return color;
    }

    public static bool CheckAlign(List<List<int>> colorNum, 
                                  int rowLine,
                                  int oneRow,
                                  int twoRow, 
                                  int threeRow, 
                                  int fourRow, 
                                  int fiveRow)
    {

        int check1 = colorNum[0][rowLine - 1 + oneRow];

        int xNum = 0;

        int n = 0;

        for (int y = 0; y < 5; y++)
        {

            switch (y)
            {
                case 0:
                    n = oneRow;
                    break;
                case 1:
                    n = twoRow;
                    break;
                case 2:
                    n = threeRow;
                    break;
                case 3:
                    n = fourRow;
                    break;
                case 4:
                    n = fiveRow;
                    break;
            }

            xNum = rowLine - 1 + n;

            int check2 = colorNum[y][xNum];

            // 一回目と二回目をチェックし、一致しない場合はfalseを返す
            if (check1 != check2) return false;

            check1 = check2;
            
        }

        return true;
    }
}
