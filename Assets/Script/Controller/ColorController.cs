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

        public GameManager gameManager;

        private List<List<int>> initColorNum = new List<List<int>>();

        List<int> list1 = new List<int>() { 0, 0, 0, 0, 0 };
        List<int> list2 = new List<int>() { 0, 0, 0, 0, 0 };
        List<int> list3 = new List<int>() { 0, 0, 0, 0, 0 };
        List<int> list4 = new List<int>() { 0, 0, 0, 0, 0 };
        List<int> list5 = new List<int>() { 0, 0, 0, 0, 0 };



        public List<List<int>> InitColorNum
        {
            get => initColorNum;
            set => initColorNum = value;
        }

        private int elementCount = 0;
        Color color;

        bool colorCheck = true;

        void Start()
        {

            gameManager = GameManager.instance;

            // ê∂ê¨éûÇ…óÒÇ™àÍívÇµÇƒÇ¢ÇΩèÍçáÇÕçƒíäëIÇ∑ÇÈ
            while (colorCheck)
            {
                SetListColor(list1);
                SetListColor(list2);
                SetListColor(list3);
                SetListColor(list4);
                SetListColor(list5);

                initColorNum.Add(list1);
                initColorNum.Add(list2);
                initColorNum.Add(list3);
                initColorNum.Add(list4);
                initColorNum.Add(list5);

                colorCheck = gameManager.AllColorLineCheck(initColorNum);

                if (colorCheck)
                {
                    initColorNum.Clear();
                }

            }


            ChengePanelColor();
        }

        void SetListColor(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = Util.RandNum();
            }

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
