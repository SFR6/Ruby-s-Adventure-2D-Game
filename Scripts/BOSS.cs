using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    ///float speed;
    public bool vertical;
    public float changeTime = 1.5f;
    public int health = 10;

    Rigidbody2D rigidbody2D;
    public float timer;
    float sitTimer;
    int isMoving = -2;

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
    AudioSource audioSource;
    bool isPlaying;

    public float timeInvincible = 3f;
    bool isInvincible;
    float invincibleTimer;

    public GameObject Shield;

    public GameObject BOSSHealthBar;
    public GameObject BOSSMusic;
    public GameObject backgroundMusic2;
    public GameObject Arena;

    public GameObject Ammo;
    public GameObject Health;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        timer = changeTime;
        sitTimer = 0f;
        ///speed = 0f;
        audioSource.PlayOneShot(audioClip5);
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (broken == false)
        {
            return;
        }

        sitTimer = Mathf.Clamp(sitTimer += Time.deltaTime, 0f, 3f);
        animator.SetFloat("BOSS_Sit", sitTimer);

        timer -= Time.deltaTime;

        if (sitTimer == 3f && isPlaying == false)
        {
            audioSource.Play();
            isPlaying = true;
        }

        if (timer < 0)
        {
            timer = changeTime;
            ++isMoving;
            if (isMoving == 16)
            {
                GameObject AMMO = Instantiate(Ammo, rigidbody2D.position + Vector2.left * 10.0f + Vector2.down * 3.0f, Quaternion.identity);
                GameObject HEALTH = Instantiate(Health, rigidbody2D.position + Vector2.left * 10.0f + Vector2.up * 2.0f, Quaternion.identity);
                Destroy(AMMO, 5f);
                Destroy(HEALTH, 5f);
                isMoving = 0;
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

        if (sitTimer > 1.5f)
        {
            Vector2 position = rigidbody2D.position;

            animator.SetInteger("BOSS_IsMoving", isMoving);
            if (isMoving == 0 || isMoving == 4 || isMoving == 8 || isMoving == 12)
            {
                animator.SetFloat("BOSS_MoveX", -1);
                animator.SetFloat("BOSS_MoveY", 0);
                position.x -= (Time.deltaTime * 8f);
            }
            else if (isMoving == 2 || isMoving == 6 || isMoving == 10 || isMoving == 14)
            {
                animator.SetFloat("BOSS_MoveX", 1);
                animator.SetFloat("BOSS_MoveY", 0);
                position.x += (Time.deltaTime * 8f);
            }
            else if (isMoving == 3 || isMoving == 15)
            {
                animator.SetFloat("BOSS_MoveX", 0);
                animator.SetFloat("BOSS_MoveY", 1);
                position.y += (Time.deltaTime * 3.5f);
            }
            else if (isMoving == 7 || isMoving == 11)
            {
                animator.SetFloat("BOSS_MoveX", 0);
                animator.SetFloat("BOSS_MoveY", -1);
                position.y -= (Time.deltaTime * 3.5f);
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
        health = Mathf.Clamp(health, 0, 10);
        UIBOSSHealthBar.instance.SetValue(health / 10f);
    }

    public void Death()
    {
        GameObject deathEffectObject = Instantiate(deathEffectPrefab, rigidbody2D.position + Vector2.up * 1.0f, Quaternion.identity);
        GameObject dustEffectObject = Instantiate(dustEffectPrefab, rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);

        Destroy(Shield);

        animator.SetTrigger("BOSS_Death");
        broken = false;
        rigidbody2D.simulated = false;

        audioSource.Stop();

        audioSource.PlayOneShot(audioClip2);

        BOSSMusic.SetActive(false);
        backgroundMusic2.SetActive(true);
        BOSSHealthBar.SetActive(false);
        Arena.SetActive(false);
    }
}
