using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using TMPro;

public class TextChangingColour : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Color Color1;
    public Color Color2;

    void Update()
    {
        text = GetComponent<TextMeshProUGUI>();
        if (SaveGame.Exists("level"))
        {
            int levelNo = SaveGame.Load<int>("level");
            if (levelNo < 6)
            {
                text.color = Color1;
            }
            else if (levelNo >= 6)
            {
                text.color = Color2;
            }
        }

        if (SaveGame.Exists("secret") || SaveGame.Exists("end"))
        {
            text.color = Color1;
        }
    }
}
