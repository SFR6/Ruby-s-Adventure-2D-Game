using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class BOSSDecoy : MonoBehaviour
{
    public Transform BOSSDecoy2_1;
    public GameObject BOSSDecoy2_2;
    public GameObject BOSSTrigger;

    public string BOSSName;

    // Start is called before the first frame update
    void Start()
    {
        if (SaveGame.Exists(BOSSName))
        {
            BOSSDecoy2_2.SetActive(true);
            BOSSDecoy2_1.position = SaveGame.Load<Vector2>(BOSSName);
            Destroy(BOSSTrigger);
            Destroy(gameObject);
        }
    }
}
