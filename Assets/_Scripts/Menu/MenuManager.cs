using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Menu[] menus;
    [SerializeField] private SceneSwitcher sceneSwitcher;
    [SerializeField] private string nextScene = "WaterSimTest";

    public void MenuOpen(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].MenuName == menuName) { menus[i].ChangeState(true); }
            else if (menus[i].Open) { menus[i].ChangeState(false); }
        }
    }

    public void StartGame()
    {
        sceneSwitcher.ChangeScene(nextScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
