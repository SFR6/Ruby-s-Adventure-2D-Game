using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenHead : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController player = other.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-player.currentHealth);
        }
    }
}
