using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class Death : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SaveGame.Delete("secret");
        SaveGame.Delete("BOSS3");
        SaveGame.Delete("Jambi10");
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        SaveGame.Delete("secret");
        SaveGame.Delete("BOSS3");
        SaveGame.Delete("Jambi10");
        Application.Quit();
    }
}
