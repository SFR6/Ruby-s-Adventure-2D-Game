using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class RubyController : MonoBehaviour
{
    public float speed = 5.0f;

    public int maxHealth = 5;
    public float timeInvincible = 1.25f;
    public int health { get { return currentHealth; } }
    public int currentHealth;

    bool isInvincible;
    float invincibleTimer;

    public Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    public GameObject projectilePrefab;

    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioClip audioClip;
    public AudioClip audioClip2;
    public AudioClip audioClip3;

    public int numberOfCogs = 0;

    public GameObject shadow;
    Renderer renderer;
    public BoxCollider2D boxCollider2D;

    public GameObject deathCanvas;

    public GameObject Music;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        boxCollider2D = GetComponent<BoxCollider2D>();
        renderer = GetComponent<Renderer>();

        if (SaveGame.Exists("secret"))
        {
            currentHealth = SaveGame.Load<int>("health2");
            numberOfCogs = SaveGame.Load<int>("ammo2");
            rigidbody2d.position = SaveGame.Load<Vector2>("position2");
        }
        else if (!SaveGame.Exists("secret") && SaveGame.Exists("health"))
        {
            currentHealth = SaveGame.Load<int>("health");
            numberOfCogs = SaveGame.Load<int>("ammo");
            rigidbody2d.position = SaveGame.Load<Vector2>("position");
        }
        else if (!SaveGame.Exists("health"))
        {
            currentHealth = maxHealth;
        }
        ChangeAmmo(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            Music.SetActive(false);
            Destroy(rigidbody2d);
            Destroy(animator);
            Destroy(audioSource);
            Destroy(boxCollider2D);
            Destroy(renderer, 1f);
            Destroy(shadow, 1f);
            deathCanvas.SetActive(true);
            Cursor.visible = true;
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        if (isWalking)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Pause();
        }

        if (isInvincible == true)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        if (PauseMenu.gameIsPaused == false)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKeyDown(KeyCode.F1))
                {
                    Vector2 vector2 = new Vector2(116.055f, 1.32f);
                    transform.position = vector2;
                }
                else if (Input.GetKeyDown(KeyCode.F2))
                {
                    Vector2 vector2 = new Vector2(244.39f, 1.32f);
                    transform.position = vector2;
                }
                else if (Input.GetKeyDown(KeyCode.F3))
                {
                    Vector2 vector2 = new Vector2(372.725f, 1.32f);
                    transform.position = vector2;
                }
                else if (Input.GetKeyDown(KeyCode.F4))
                {
                    Vector2 vector2 = new Vector2(501.06f, 1.32f);
                    transform.position = vector2;
                }
                else if (Input.GetKeyDown(KeyCode.F5))
                {
                    Vector2 vector2 = new Vector2(631.395f, 1.32f);
                    transform.position = vector2;
                }
                else if (Input.GetKeyDown(KeyCode.F6))
                {
                    Vector2 vector2 = new Vector2(757.73f, 1.32f);
                    transform.position = vector2;
                }
                else if (Input.GetKeyDown(KeyCode.F7))
                {
                    Vector2 vector2 = new Vector2(886.065f, 1.32f);
                    transform.position = vector2;
                }
                else if (Input.GetKeyDown(KeyCode.F8))
                {
                    Vector2 vector2 = new Vector2(1016.4f, 1.32f);
                    transform.position = vector2;
                }
                else if (Input.GetKeyDown(KeyCode.F9))
                {
                    Vector2 vector2 = new Vector2(1148.735f, 1.32f);
                    transform.position = vector2;
                }
                else if (Input.GetKeyDown(KeyCode.F10))
                {
                    Vector2 vector2 = new Vector2(1270.15f, 1.32f);
                    transform.position = vector2;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && numberOfCogs > 0)
            {
                Launch();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, Vector2.up, 1.5f, LayerMask.GetMask("NPC"));
                RaycastHit2D hit2 = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, Vector2.down, 1.5f, LayerMask.GetMask("NPC"));
                RaycastHit2D hit3 = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, Vector2.left, 1.5f, LayerMask.GetMask("NPC"));
                RaycastHit2D hit4 = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, Vector2.right, 1.5f, LayerMask.GetMask("NPC"));
                if (hit.collider != null)
                {
                    NPC character = hit.collider.GetComponent<NPC>();
                    if (character != null)
                    {
                        character.displayDialog();
                    }
                }
                if (hit2.collider != null)
                {
                    NPC character = hit2.collider.GetComponent<NPC>();
                    if (character != null)
                    {
                        character.displayDialog();
                    }
                }
                if (hit3.collider != null)
                {
                    NPC character = hit3.collider.GetComponent<NPC>();
                    if (character != null)
                    {
                        character.displayDialog();
                    }
                }
                if (hit4.collider != null)
                {
                    NPC character = hit4.collider.GetComponent<NPC>();
                    if (character != null)
                    {
                        character.displayDialog();
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        ChangeHealth(0);

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth (int amount)
    {
        if (amount < 0)
        {
            animator.SetTrigger("Hit");

            if (isInvincible == true)
            {
                return;
            }
            audioSource2.PlayOneShot(audioClip);
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }

    public void ChangeAmmo (int amount)
    {
        numberOfCogs += amount;
        UINumberOfCogs.instance.SetValue(numberOfCogs);
    }

    void Launch()
    {
        ChangeAmmo(-1);

        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }
}
