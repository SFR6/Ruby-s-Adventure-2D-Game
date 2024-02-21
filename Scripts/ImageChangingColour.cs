using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.UI;

public class ImageChangingColour : MonoBehaviour
{
    public Image image;
    public Color Color1;
    public Color Color2;

    void Update()
    {
        image = GetComponent<Image>();
        if (SaveGame.Exists("level"))
        {
            int levelNo = SaveGame.Load<int>("level");
            if (levelNo < 6)
            {
                image.color = Color1;
            }
            else if (levelNo >= 6)
            {
                image.color = Color2;
            }
        }

        if (SaveGame.Exists("secret"))
        {
            image.color = Color1;
        }
    }
}
