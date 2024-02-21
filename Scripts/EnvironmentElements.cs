using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentElements : MonoBehaviour
{
    public float min;
    public float max;

    void Start()
    {
        float value = Random.Range(min, max);

        transform.localScale = new Vector3(value, value, value);
    }
}
