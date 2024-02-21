using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS2 : MonoBehaviour
{
    ///float speed;
    public bool vertical;
    public float changeTime = 1.5f;
    public int health = 15;

    Rigidbody2D rigidbody2D;
    public float timer;
    float sitTimer;
    int isMoving = -1;

    Animator animator;

    public bool broken = true;

    public GameObject destroyEffectPrefab;
    public GameObject hitEffectPrefab;
    public GameObject deathEffectPrefab;
    public GameObject dustEffectPrefab;

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip4;
    public AudioClip audioClip5;
    public AudioClip audioClip6;
    AudioSource audioSource;

    public float timeInvincible = 4f;
    bool isInvincible;
    float invincibleTimer;

    public GameObject Shield;

    public GameObject BOSS2HealthBar;
    public GameObject BOSSMusic;
    public GameObject backgroundMusic2;
    public GameObject Arena2;

    public GameObject firePoint;
    bool isFirePointActive;

    public GameObject Ammo;
    public GameObject Health;

    int time;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        timer = 1f;
        sitTimer = 0f;
        ///speed = 0f;
        audioSource.PlayOneShot(audioClip5);
        isFirePointActive = false;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (broken == false)
        {
            return;
        }

        sitTimer = Mathf.Clamp(sitTimer += Time.deltaTime, 0f, 1.5f);
        animator.SetFloat("BOSS2_Sit", sitTimer);

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = changeTime;
            ++isMoving;
            if (isMoving == 10)
            {
                isMoving = 0;
                ++time;
                if (time == 2)
                {
                    GameObject AMMO = Instantiate(Ammo, rigidbody2D.position + Vector2.left * 10.0f + Vector2.up * 3.0f, Quaternion.identity);
                    GameObject HEALTH = Instantiate(Health, rigidbody2D.position + Vector2.left * 10.0f + Vector2.up * 7.0f, Quaternion.identity);
                    Destroy(AMMO, 4f);
                    Destroy(HEALTH, 4f);
                    time = 0;
                }
            }
        }

        if (isInvincible == true)
        {
            Shield.SetActive(true);
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
                Shield.SetActive(false);
            }
        }
    }

    void FixedUpdate()
    {
        if (broken == false)
        {
            return;
        }

        if (sitTimer == 1.5f)
        {
            Vector2 position = rigidbody2D.position;

            animator.SetInteger("BOSS2_IsMoving", isMoving);
            if ((isMoving == 0 || isMoving == 5) && timer < 1.0f && isFirePointActive == false)
            {
                audioSource.Pause();
                audioSource.PlayOneShot(audioClip6);
                firePoint.SetActive(true);
                isFirePointActive = true;
            }
            else if (isMoving == 2 || isMoving == 7)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                position.x -= (Time.deltaTime * 8f);
                isFirePointActive = false;
            }
            else if (isMoving == 3 || isMoving == 8)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                position.x += (Time.deltaTime * 8f);
                isFirePointActive = false;
            }
            else if (isMoving == 1 || isMoving == 4)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                position.y += (Time.deltaTime * 4f);
                isFirePointActive = false;
            }
            else if (isMoving == 6 || isMoving == 9)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                position.y -= (Time.deltaTime * 4f);
                isFirePointActive = false;
            }

            rigidbody2D.MovePosition(position);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();
        Projectile cog = other.gameObject.GetComponent<Projectile>();

        if (player != null)
        {
            GameObject hitEffectObject = Instantiate(hitEffectPrefab, player.rigidbody2d.position, Quaternion.identity);
            player.ChangeHealth(-1);
            audioSource.PlayOneShot(audioClip1);
        }

        if (cog != null)
        {
            changeHealth();
            if (health > 0)
            {
                GameObject destroyEffectObject = Instantiate(destroyEffectPrefab, rigidbody2D.position, Quaternion.identity);
                audioSource.PlayOneShot(audioClip4);
            }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void changeHealth()
    {
        if (isInvincible == true)
        {
            return;
        }
        isInvincible = true;
        invincibleTimer = timeInvincible;

        --health;
        health = Mathf.Clamp(health, 0, 15);
        UIBOSSHealthBar.instance.SetValue(health / 15f);
    }

    public void Death()
    {
        GameObject deathEffectObject = Instantiate(deathEffectPrefab, rigidbody2D.position + Vector2.up * 1.0f, Quaternion.identity);
        GameObject dustEffectObject = Instantiate(dustEffectPrefab, rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);

        Destroy(Shield);

        animator.SetTrigger("BOSS2_Death");
        broken = false;
        rigidbody2D.simulated = false;

        audioSource.Stop();

        audioSource.PlayOneShot(audioClip2);

        BOSSMusic.SetActive(false);
        backgroundMusic2.SetActive(true);
        BOSS2HealthBar.SetActive(false);
        Arena2.SetActive(false);
    }
}
