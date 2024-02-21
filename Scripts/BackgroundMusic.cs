using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class BackgroundMusic : MonoBehaviour
{
    public GameObject backgroundMusic;
    public GameObject backgroundMusic2;

    // Update is called once per frame
    void Start()
    {
        if (SaveGame.Exists("level"))
        {
            if (SaveGame.Load<int>("level") >= 6)
            {
                backgroundMusic.SetActive(false);
                backgroundMusic2.SetActive(true);
            }
        }
    }
}
