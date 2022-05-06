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
}
