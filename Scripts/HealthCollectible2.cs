using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class HealthCollectible2 : MonoBehaviour
{
    public GameObject collectibleEffect2Prefab;

    public bool active = true;

    public string collectibleNo;

    public BoxCollider2D boxCollider2D;
    public SpriteRenderer spriteRenderer;

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

            controller.audioSource2.PlayOneShot(controller.audioClip3);

            GameObject collectibleEffect2Object = Instantiate(collectibleEffect2Prefab, controller.rigidbody2d.position, Quaternion.identity);

            controller.ChangeHealth(1);

            boxCollider2D = GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = false;

            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
        }
    }

    void Inactive()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.enabled = false;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
}
