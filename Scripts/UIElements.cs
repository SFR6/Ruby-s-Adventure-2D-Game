using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    public Image image;
    public Sprite sprite;
    public Sprite sprite2;

    void Awake()
    {
        image = GetComponent<Image>();
        if (SaveGame.Exists("level"))
        {
            int levelNo = SaveGame.Load<int>("level");
            if (levelNo < 6)
            {
                image.sprite = sprite;
            }
            else if (levelNo >= 6)
            {
                image.sprite = sprite2;
            }
        }

        if (SaveGame.Exists("secret") || SaveGame.Exists("end"))
        {
            image.sprite = sprite;
        }
    }
}
