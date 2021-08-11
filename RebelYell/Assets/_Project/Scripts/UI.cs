using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject[] menu;

    public void SetMenu(int index)
    {
        for (int i = 0; i < menu.Length; i++)
        {
            if (i == index)
                menu[i].SetActive(true);
            else
                menu[i].SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Load(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}