using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Panel;

namespace Controller
{
    public class ColorController : MonoBehaviour
    {

        public PanelManager panelManager;

        //private int[,] initColorNum = new int[,] { { 0, 0, 0, 0, 0 }, 
        //                                           { 0, 0, 0, 0, 0 },
        //                                           { 0, 0, 0, 0, 0 },
        //                                           { 0, 0, 0, 0, 0 },
        //                                           { 0, 0, 0, 0, 0 }};

        private int[,] initColorNum = new int[,] { { 1, 2, 3, 4, 5 },
                                                   { 3, 2, 3, 3, 5 },
                                                   { 1, 5, 2, 4, 4 },
                                                   { 1, 5, 1, 1, 1 },
                                                   { 5, 4, 5, 2, 4 }};

        private int elementCount = 0;
        Color color;

        void Start()
        {
            ChengePanelColor();
        }

        void Update()
        {

        }

        void ChengePanelColor()
        {
            for (int y = 0; y < initColorNum.GetLength(0); y++)
            {
                for (int x = 0; x < initColorNum.GetLength(1); x++)
                {
                    
                    Image image = panelManager.panelImageList[elementCount].GetComponent<Image>();

                    int colorNum = initColorNum[y, x];

                    image.color = selectColor(colorNum);

                    elementCount++;
                }
            }
        }

        Color selectColor(int colorNum)
        {
            
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

}
