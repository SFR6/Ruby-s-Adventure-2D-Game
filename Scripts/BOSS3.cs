using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BOSS3 : MonoBehaviour
{
    ///float speed;
    public bool vertical;
    public float changeTime = 1.5f;
    public int health = 20;

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
    public AudioClip audioClip7;
    AudioSource audioSource;
    public AudioSource audioSource2;
    bool bombSound;

    public float timeInvincible = 5f;
    bool isInvincible;
    float invincibleTimer;

    public GameObject Shield;

    public GameObject BOSS3HealthBar;
    public GameObject BOSSMusic;
    public GameObject backgroundMusic;
    public GameObject Arena3;

    public GameObject firePoint;
    public GameObject firePoint2;
    bool isFirePointActive;
    bool isFirePoint2Active;

    public GameObject Ammo;
    public GameObject Health;

    int time;

    public GameObject Enemies;
    public GameObject Enemies2;
    public GameObject AmmoCollectibles;
    public GameObject AmmoCollectibles2;
    public GameObject HealthCollectibles;
    public GameObject HealthCollectibles2;

    public GameObject Tilemap;
    public GameObject Tilemap2;

    public GameObject environment;
    public GameObject environment2;

    public GameObject UIElement1;
    public GameObject UIElement2;
    public GameObject UIElement3;

    public TextMeshProUGUI levelText;

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
        bombSound = false;
        isFirePointActive = false;
        isFirePoint2Active = false;
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
        animator.SetFloat("BOSS3_Sit", sitTimer);

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = changeTime;
            ++isMoving;
            if (isMoving == 10)
            {
                isMoving = 0;
                ++time;
                if (time == 3)
                {
                    GameObject AMMO = Instantiate(Ammo, rigidbody2D.position + Vector2.left * 10.0f + Vector2.down * 3.0f, Quaternion.identity);
                    GameObject HEALTH = Instantiate(Health, rigidbody2D.position + Vector2.left * 10.0f + Vector2.down * 7.0f, Quaternion.identity);
                    Destroy(AMMO, 3f);
                    Destroy(HEALTH, 3f);
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

            animator.SetInteger("BOSS3_IsMoving", isMoving);
            if ((isMoving == 0 || isMoving == 5) && isFirePointActive == false)
            {
                audioSource.Pause();
                if (timer < 1.4f && bombSound == false)
                {
                    audioSource2.PlayOneShot(audioClip7);
                    bombSound = true;
                }

                if (timer < 0.6f)
                {
                    firePoint.SetActive(true);
                    isFirePointActive = true;
                }
                isFirePoint2Active = false;
            }
            else if (isMoving == 2 || isMoving == 7)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                position.x -= (Time.deltaTime * 8f);
                isFirePointActive = false;
                if (isFirePoint2Active == false && timer < 0.6f)
                {
                    audioSource.PlayOneShot(audioClip6);
                    firePoint2.SetActive(true);
                    isFirePoint2Active = true;
                }
            }
            else if (isMoving == 3 || isMoving == 8)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                position.x += (Time.deltaTime * 8f);
                isFirePointActive = false;
                isFirePoint2Active = false;
            }
            else if (isMoving == 1 || isMoving == 4)
            {
                bombSound = false;
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                position.y -= (Time.deltaTime * 4f);
                isFirePointActive = false;
                isFirePoint2Active = false;
            }
            else if (isMoving == 6 || isMoving == 9)
            {
                bombSound = false;
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                position.y += (Time.deltaTime * 4f);
                isFirePointActive = false;
                isFirePoint2Active = false;
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
        health = Mathf.Clamp(health, 0, 20);
        UIBOSSHealthBar.instance.SetValue(health / 20f);
    }

    public void Death()
    {
        Tilemap2.SetActive(false);
        Tilemap.SetActive(true);

        environment.SetActive(true);
        environment2.SetActive(false);


        GameObject deathEffectObject = Instantiate(deathEffectPrefab, rigidbody2D.position + Vector2.up * 1.0f, Quaternion.identity);
        GameObject dustEffectObject = Instantiate(dustEffectPrefab, rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);


        Destroy(Shield);

        animator.SetTrigger("BOSS3_Death");
        broken = false;
        rigidbody2D.simulated = false;

        audioSource.Stop();

        audioSource.PlayOneShot(audioClip2);

        BOSSMusic.SetActive(false);
        backgroundMusic.SetActive(true);
        BOSS3HealthBar.SetActive(false);
        Arena3.SetActive(false);

        Enemies.SetActive(false);
        Enemies2.SetActive(false);
        AmmoCollectibles.SetActive(false);
        AmmoCollectibles2.SetActive(false);
        HealthCollectibles.SetActive(false);
        HealthCollectibles2.SetActive(false);

        UIElements uiElement1 = UIElement1.GetComponent<UIElements>();
        UIElements uiElement2 = UIElement2.GetComponent<UIElements>();
        UIElements uiElement3 = UIElement3.GetComponent<UIElements>();

        uiElement1.image.sprite = uiElement1.sprite;
        uiElement2.image.sprite = uiElement2.sprite;
        uiElement3.image.sprite = uiElement3.sprite;

        levelText.text = "V0FJVCEgRE9OJ1QgTU9WRSE=";
        levelText.fontSize = 25;
        levelText.color = new Color(255f, 0f, 0f, 255f);
    }
}
