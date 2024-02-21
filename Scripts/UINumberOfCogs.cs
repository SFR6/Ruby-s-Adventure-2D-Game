using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UINumberOfCogs : MonoBehaviour
{
    public static UINumberOfCogs instance { get; private set; }
    TextMeshProUGUI txt;

    void Awake()
    {
        instance = this;
        txt = GetComponent<TextMeshProUGUI>();
    }

    public void SetValue(int value)
    {
        txt.text = "x " + value;
    }
}
