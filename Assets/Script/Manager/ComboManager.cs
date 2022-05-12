using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    int comboCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public int ComboCount(int lineCount)
    {
        if (lineCount == 1)
        {
            comboCount = 1;
        }
        else
        {
            comboCount++;
        }


        return comboCount;
    }
}
