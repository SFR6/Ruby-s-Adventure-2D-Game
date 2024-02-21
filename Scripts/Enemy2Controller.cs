using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class Enemy2Controller : MonoBehaviour
{
    public float speed;
    public bool liniar;
    public bool vertical;
    float changeTime;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    Animator animator;

    public bool broken = true;

    public ParticleSystem smokeEffect;

    public GameObject destroyEffectPrefab;
    public GameObject hitEffectPrefab;

    public AudioClip audioClip;
    public AudioClip audioClip2;
    AudioSource audioSource;

    public string enemyNo;
    public string enemyNoPos;

    // Start is called before the first frame update
    void Start()
    {
        enemyNo = transform.name;
        enemyNoPos = transform.name + " pos";

        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (liniar == false)
        {
            changeTime = Random.Range(0.3f, 0.7f);
        }
        else
        {
            changeTime = Random.Range(2.3f, 2.7f);
        }
        timer = changeTime;
        audioSource.Play();

        if (SaveGame.Exists(enemyNo) && SaveGame.Load<bool>(enemyNo) == false)
        {
            isFixed();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (broken == false)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            if (liniar == false)
            {
                if (vertical) // when he changes axis twice changes his direction
                {
                    direction = -direction;
                }
                timer = changeTime;
                vertical = !vertical; // after the timer he changes axis
            }
            else
            {
                timer = changeTime;
                direction = -direction;
            }
        }
    }
    void FixedUpdate()
    {
        if (broken == false)
        {
            return;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
            position.y += (Time.deltaTime * speed * direction);
        }
        else
        {
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
            position.x += (Time.deltaTime * speed * direction);
        }

        rigidbody2D.MovePosition(position);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            GameObject hitEffectObject = Instantiate(hitEffectPrefab, player.rigidbody2d.position, Quaternion.identity);
            player.ChangeHealth(-1);
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void Fix()
    {
        GameObject destroyEffectObject = Instantiate(destroyEffectPrefab, rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);

        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");

        smokeEffect.Stop();
        audioSource.Stop();

        audioSource.PlayOneShot(audioClip2);
    }

    void isFixed()
    {
        transform.position = SaveGame.Load<Vector2>(enemyNoPos);

        broken = false;

        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");

        smokeEffect.Stop();
        audioSource.Stop();
    }
}
