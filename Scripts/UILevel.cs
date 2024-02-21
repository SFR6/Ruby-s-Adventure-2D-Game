using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILevel : MonoBehaviour
{
    public static UILevel instance { get; private set; }
    TextMeshProUGUI txt;

    void Awake()
    {
        instance = this;
        txt = GetComponent<TextMeshProUGUI>();
    }

    public void SetValue(int value)
    {
        txt.text = "LEVEL " + value;
    }
}
