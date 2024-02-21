using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBOSS : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        Destroy(animator, 2.7f);
    }
}
