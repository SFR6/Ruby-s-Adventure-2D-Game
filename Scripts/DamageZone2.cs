using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone2 : MonoBehaviour
{
    public GameObject damageEffectPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            GameObject hitEffectObject = Instantiate(damageEffectPrefab, controller.rigidbody2d.position, Quaternion.identity);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.ChangeHealth(-2);
        }
    }
}
