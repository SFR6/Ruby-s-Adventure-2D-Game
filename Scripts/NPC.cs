using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEngine.UIElements;

public class NPC : MonoBehaviour
{
    public float displayTime = 10.0f;
    public GameObject dialogBox;
    float timerDisplay;

    AudioSource audioSource;
    public AudioClip audioClip;

    public string JambiNo;

    public Renderer renderer;
    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    bool inactive = false;
    public GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        JambiNo = transform.name;

        dialogBox.SetActive(false);
        timerDisplay = -1.0f;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inactive == true)
        {
            return;
        }

        if (SaveGame.Exists(JambiNo) && SaveGame.Load<bool>(JambiNo) == false)
        {
            Inactive();
        }

        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            Canvas.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            Canvas.SetActive(false);
        }
    }

    public void displayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);

        audioSource.PlayOneShot(audioClip);
    }

    void Inactive()
    {
        inactive = true;
        renderer = GetComponent<Renderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        renderer.enabled = false;
        boxCollider2D.enabled = false;
        circleCollider2D.enabled = false;
        Destroy(audioSource);
    }
}
