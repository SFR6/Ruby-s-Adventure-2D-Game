using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class Level10 : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public CanvasGroup level;

    public int levelNo = 0;
    public string LevelName;

    public int isPlayerAtTrigger;
    float timer;
    float t = 2;

    public AudioClip audioClip;
    AudioSource audioSource;

    public GameObject SaveIcon;

    void Start()
    {
        SaveGame.Save<bool>("played", true);
        if (SaveGame.Exists(LevelName) && SaveGame.Load<int>(LevelName) == 2)
        {
            isPlayerAtTrigger = 2;
            levelNo = SaveGame.Load<int>("level");
            UILevel.instance.SetValue(levelNo);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController player = other.GetComponent<RubyController>();
        audioSource = GetComponent<AudioSource>();

        if (player != null && isPlayerAtTrigger == 0)
        {
            isPlayerAtTrigger = 1;
            audioSource.PlayOneShot(audioClip);

            SaveGame.Save<int>("health", player.currentHealth);
            SaveGame.Save<int>("ammo", player.numberOfCogs);
            SaveGame.Save<Vector2>("position", player.rigidbody2d.position);


            
            ++levelNo;
            SaveGame.Save<int>("level", levelNo);
            SaveGame.Save<int>(LevelName, 2);
            UILevel.instance.SetValue(levelNo);
        }
    }

    void Update()
    {
        if (isPlayerAtTrigger == 1)
        {
            FadeLevelIn();

            SaveIcon.SetActive(true);
        }

        if (timer > fadeDuration + displayImageDuration)
        {
            t -= Time.deltaTime;
            level.alpha = t;
        }

        if (level.alpha == 0 && isPlayerAtTrigger == 1)
        {
            ///SaveGame.Save<string>("trigger", LevelName);

            Destroy(audioSource);
            isPlayerAtTrigger = 2;

            SaveIcon.SetActive(false);
        }
    }

    void FadeLevelIn()
    {
        timer += Time.deltaTime;

        level.alpha = timer / fadeDuration;
    }
}
