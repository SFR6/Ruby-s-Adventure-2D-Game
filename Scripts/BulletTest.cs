using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletTest : MonoBehaviour
{

    float timer;
    public int damage;

    public GameObject damageEffectPrefab;

    void Awake()
    {
        timer = 0.2f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            GameObject damageEffectObject = Instantiate(damageEffectPrefab, player.rigidbody2d.position, Quaternion.identity);
            player.ChangeHealth(damage);
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
