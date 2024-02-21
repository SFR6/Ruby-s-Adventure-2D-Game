using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    AudioSource audioSource;
    public AudioClip audioClip;

    SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public Sprite sprite2;

    float timer;

    // Start is called before the first frame update
    void Awake()
    {
        timer = 2f;

        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (SaveGame.Exists("level"))
        {
            int levelNo = SaveGame.Load<int>("level");
            if (levelNo < 6)
            {
                spriteRenderer.sprite = sprite;
            }
            else if (levelNo >= 6)
            {
                spriteRenderer.sprite = sprite2;
            }
        }
    }

    public void Launch (Vector2 direction, float force)
    {
        rigidbody2D.AddForce(direction * force);
        audioSource.PlayOneShot(audioClip);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        Enemy2Controller e2 = other.collider.GetComponent<Enemy2Controller>();
        BOSS boss = other.collider.GetComponent<BOSS>();
        BOSS2 boss2 = other.collider.GetComponent<BOSS2>();
        BOSS3 boss3 = other.collider.GetComponent<BOSS3>();

        if (e != null)
        {
            e.Fix();
        }

        if (e2 != null)
        {
            e2.Fix();
        }

        if (boss != null && boss.health == 1)
        {
            boss.Death();
        }

        if (boss2 != null && boss2.health == 1)
        {
            boss2.Death();
        }

        if (boss3 != null && boss3.health == 1)
        {
            boss3.Death();
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Destroy(gameObject);
        }
    }
}
