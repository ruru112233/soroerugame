using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject setumeiPanel;

    private void Start()
    {
        setumeiPanel.SetActive(false);
    }

    public void GameStart()
    {
        AudioManager.instance.PlaySE(0);
        SceneManager.LoadScene("SampleScene");
    }

    public void ViewSetumei()
    {
        AudioManager.instance.PlaySE(0);
        setumeiPanel.SetActive(true);
    }

    public void CloseSetumei()
    {
        AudioManager.instance.PlaySE(0);
        setumeiPanel.SetActive(false);

    }
}
