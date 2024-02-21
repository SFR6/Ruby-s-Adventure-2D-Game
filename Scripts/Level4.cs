using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class Level4 : MonoBehaviour
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

    public GameObject Enemy1_1;
    public GameObject Enemy1_2;
    public GameObject Enemy1_3;
    public GameObject Enemy1_4;
    public GameObject Enemy1_5;
    public GameObject Enemy1_6;
    public GameObject Enemy1_7;
    public GameObject Enemy1_8;
    public GameObject Enemy1_9;
    public GameObject Enemy1_10;
    public GameObject Enemy1_11;
    public GameObject Enemy1_12;

    public GameObject Health1_1;
    public GameObject Health1_2;

    public GameObject Cog1_1;
    public GameObject Cog1_2;

    public GameObject Jambi;

    void Start()
    {
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

        EnemyController enemy1_1 = Enemy1_1.GetComponent<EnemyController>();
        EnemyController enemy1_2 = Enemy1_2.GetComponent<EnemyController>();
        EnemyController enemy1_3 = Enemy1_3.GetComponent<EnemyController>();
        EnemyController enemy1_4 = Enemy1_4.GetComponent<EnemyController>();
        EnemyController enemy1_5 = Enemy1_5.GetComponent<EnemyController>();
        EnemyController enemy1_6 = Enemy1_6.GetComponent<EnemyController>();
        EnemyController enemy1_7 = Enemy1_7.GetComponent<EnemyController>();
        EnemyController enemy1_8 = Enemy1_8.GetComponent<EnemyController>();
        EnemyController enemy1_9 = Enemy1_9.GetComponent<EnemyController>();
        EnemyController enemy1_10 = Enemy1_10.GetComponent<EnemyController>();
        EnemyController enemy1_11 = Enemy1_11.GetComponent<EnemyController>();
        EnemyController enemy1_12 = Enemy1_12.GetComponent<EnemyController>();


        HealthCollectible health1_1 = Health1_1.GetComponent<HealthCollectible>();
        HealthCollectible health1_2 = Health1_2.GetComponent<HealthCollectible>();

        AmmoCollectible cog1_1 = Cog1_1.GetComponent<AmmoCollectible>();
        AmmoCollectible cog1_2 = Cog1_2.GetComponent<AmmoCollectible>();

        NPC jambi = Jambi.GetComponent<NPC>();

        if (player != null && isPlayerAtTrigger == 0)
        {
            isPlayerAtTrigger = 1;
            audioSource.PlayOneShot(audioClip);

            SaveGame.Save<int>("health", player.currentHealth);
            SaveGame.Save<int>("ammo", player.numberOfCogs);
            SaveGame.Save<Vector2>("position", player.rigidbody2d.position);


            SaveGame.Save<bool>(enemy1_1.enemyNo, enemy1_1.broken);
            SaveGame.Save<Vector2>(enemy1_1.enemyNoPos, enemy1_1.transform.position);

            SaveGame.Save<bool>(enemy1_2.enemyNo, enemy1_2.broken);
            SaveGame.Save<Vector2>(enemy1_2.enemyNoPos, enemy1_2.transform.position);

            SaveGame.Save<bool>(enemy1_3.enemyNo, enemy1_3.broken);
            SaveGame.Save<Vector2>(enemy1_3.enemyNoPos, enemy1_3.transform.position);

            SaveGame.Save<bool>(enemy1_4.enemyNo, enemy1_4.broken);
            SaveGame.Save<Vector2>(enemy1_4.enemyNoPos, enemy1_4.transform.position);

            SaveGame.Save<bool>(enemy1_5.enemyNo, enemy1_5.broken);
            SaveGame.Save<Vector2>(enemy1_5.enemyNoPos, enemy1_5.transform.position);

            SaveGame.Save<bool>(enemy1_6.enemyNo, enemy1_6.broken);
            SaveGame.Save<Vector2>(enemy1_6.enemyNoPos, enemy1_6.transform.position);

            SaveGame.Save<bool>(enemy1_7.enemyNo, enemy1_7.broken);
            SaveGame.Save<Vector2>(enemy1_7.enemyNoPos, enemy1_7.transform.position);

            SaveGame.Save<bool>(enemy1_8.enemyNo, enemy1_8.broken);
            SaveGame.Save<Vector2>(enemy1_8.enemyNoPos, enemy1_8.transform.position);

            SaveGame.Save<bool>(enemy1_9.enemyNo, enemy1_9.broken);
            SaveGame.Save<Vector2>(enemy1_9.enemyNoPos, enemy1_9.transform.position);

            SaveGame.Save<bool>(enemy1_10.enemyNo, enemy1_10.broken);
            SaveGame.Save<Vector2>(enemy1_10.enemyNoPos, enemy1_10.transform.position);

            SaveGame.Save<bool>(enemy1_11.enemyNo, enemy1_11.broken);
            SaveGame.Save<Vector2>(enemy1_11.enemyNoPos, enemy1_11.transform.position);

            SaveGame.Save<bool>(enemy1_12.enemyNo, enemy1_12.broken);
            SaveGame.Save<Vector2>(enemy1_12.enemyNoPos, enemy1_12.transform.position);



            SaveGame.Save<bool>(health1_1.collectibleNo, health1_1.active);
            SaveGame.Save<bool>(health1_2.collectibleNo, health1_2.active);



            SaveGame.Save<bool>(cog1_1.collectibleNo, cog1_1.active);
            SaveGame.Save<bool>(cog1_2.collectibleNo, cog1_2.active);



            SaveGame.Save<bool>(jambi.JambiNo, false);

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
