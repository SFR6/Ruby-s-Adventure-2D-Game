using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class HealthCollectible : MonoBehaviour
{
    public GameObject collectibleEffectPrefab;

    AudioSource audioSource;
    public AudioClip audioClip;

    Renderer renderer;
    BoxCollider2D boxCollider2D;

    public bool active = true;

    public string collectibleNo;

    void Awake()
    {
        collectibleNo = transform.name;

        if (SaveGame.Exists(collectibleNo) && SaveGame.Load<bool>(collectibleNo) == false)
        {
            Inactive();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null && controller.health < controller.maxHealth)
        {
            active = false;

            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClip);

            GameObject collectibleEffectObject = Instantiate(collectibleEffectPrefab, controller.rigidbody2d.position, Quaternion.identity);

            renderer = GetComponent<SpriteRenderer>();
            renderer.enabled = false;

            boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;

            controller.ChangeHealth(2);
            Destroy(audioSource, 2f);
        }
    }

    void Inactive()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;

        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;

        Destroy(audioSource, 2f);
    }
}
