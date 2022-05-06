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

        //private int[,] initColorNum = new int[,] { { 1, 2, 3, 4, 5 },
        //                                           { 3, 2, 3, 3, 5 },
        //                                           { 1, 5, 2, 4, 4 },
        //                                           { 1, 5, 1, 1, 1 },
        //                                           { 5, 4, 5, 2, 4 }};

        private List<List<int>> initColorNum = new List<List<int>>();

        List<int> list1 = new List<int>() { 1, 2, 3, 4, 5 };
        List<int> list2 = new List<int>() { 1, 2, 3, 4, 5 };
        List<int> list3 = new List<int>() { 1, 2, 3, 4, 5 };
        List<int> list4 = new List<int>() { 1, 2, 3, 4, 5 };
        List<int> list5 = new List<int>() { 1, 2, 3, 4, 5 };



        public List<List<int>> InitColorNum
        {
            get => initColorNum;
            set => initColorNum = value;
        }

        public List<int> List1
        {
            set => initColorNum[0] = value;
        }

        private int elementCount = 0;
        Color color;

        void Start()
        {
            
            initColorNum.Add(list1);
            initColorNum.Add(list2);
            initColorNum.Add(list3);
            initColorNum.Add(list4);
            initColorNum.Add(list5);

            ChengePanelColor();
        }

        void Update()
        {

        }

        void ChengePanelColor()
        {   

            for (int y = 0; y < initColorNum.Count; y++)
            {
                for (int x = 0; x < initColorNum[y].Count; x++)
                {

                    Image image = panelManager.panelImageList[elementCount].GetComponent<Image>();

                    int colorNum = initColorNum[y][x];

                    image.color = Util.selectColor(colorNum);

                    elementCount++;
                }
            }

        }

    }

}
