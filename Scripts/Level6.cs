using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class Level6 : MonoBehaviour
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

    public GameObject Enemy2_1;
    public GameObject Enemy2_2;
    public GameObject Enemy2_3;
    public GameObject Enemy2_4;
    public GameObject Enemy2_5;
    public GameObject Enemy2_6;
    public GameObject Enemy2_7;
    public GameObject Enemy2_8;
    public GameObject Enemy2_9;
    public GameObject Enemy2_10;
    public GameObject Enemy2_11;
    public GameObject Enemy2_12;
    public GameObject Enemy2_13;
    public GameObject Enemy2_14;
    public GameObject Enemy2_15;
    public GameObject Enemy2_16;
    public GameObject Enemy2_17;
    public GameObject Enemy2_18;
    public GameObject Enemy2_19;
    public GameObject Enemy2_20;
    public GameObject Enemy2_21;
    public GameObject Enemy2_22;
    public GameObject Enemy2_23;
    public GameObject Enemy2_24;
    public GameObject Enemy2_25;
    public GameObject Enemy2_26;
    public GameObject Enemy2_27;
    public GameObject Enemy2_28;
    public GameObject Enemy2_29;
    public GameObject Enemy2_30;

    public GameObject Health2_1;

    public GameObject Cog2_1;

    public GameObject Jambi;

    public GameObject Boss;

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

        Enemy2Controller enemy2_1 = Enemy2_1.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_2 = Enemy2_2.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_3 = Enemy2_3.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_4 = Enemy2_4.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_5 = Enemy2_5.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_6 = Enemy2_6.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_7 = Enemy2_7.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_8 = Enemy2_8.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_9 = Enemy2_9.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_10 = Enemy2_10.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_11 = Enemy2_11.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_12 = Enemy2_12.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_13 = Enemy2_13.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_14 = Enemy2_14.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_15 = Enemy2_15.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_16 = Enemy2_16.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_17 = Enemy2_17.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_18 = Enemy2_18.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_19 = Enemy2_19.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_20 = Enemy2_20.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_21 = Enemy2_21.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_22 = Enemy2_22.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_23 = Enemy2_23.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_24 = Enemy2_24.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_25 = Enemy2_25.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_26 = Enemy2_26.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_27 = Enemy2_27.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_28 = Enemy2_28.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_29 = Enemy2_29.GetComponent<Enemy2Controller>();
        Enemy2Controller enemy2_30 = Enemy2_30.GetComponent<Enemy2Controller>();

        HealthCollectible2 health2_1 = Health2_1.GetComponent<HealthCollectible2>();

        AmmoCollectible2 cog2_1 = Cog2_1.GetComponent<AmmoCollectible2>();

        NPC jambi = Jambi.GetComponent<NPC>();

        BOSS boss = Boss.GetComponent<BOSS>();

        if (player != null && isPlayerAtTrigger == 0)
        {
            isPlayerAtTrigger = 1;
            audioSource.PlayOneShot(audioClip);

            SaveGame.Save<int>("health", player.currentHealth);
            SaveGame.Save<int>("ammo", player.numberOfCogs);
            SaveGame.Save<Vector2>("position", player.rigidbody2d.position);


            SaveGame.Save<bool>(enemy2_1.enemyNo, enemy2_1.broken);
            SaveGame.Save<Vector2>(enemy2_1.enemyNoPos, enemy2_1.transform.position);

            SaveGame.Save<bool>(enemy2_2.enemyNo, enemy2_2.broken);
            SaveGame.Save<Vector2>(enemy2_2.enemyNoPos, enemy2_2.transform.position);

            SaveGame.Save<bool>(enemy2_3.enemyNo, enemy2_3.broken);
            SaveGame.Save<Vector2>(enemy2_3.enemyNoPos, enemy2_3.transform.position);

            SaveGame.Save<bool>(enemy2_4.enemyNo, enemy2_4.broken);
            SaveGame.Save<Vector2>(enemy2_4.enemyNoPos, enemy2_4.transform.position);

            SaveGame.Save<bool>(enemy2_5.enemyNo, enemy2_5.broken);
            SaveGame.Save<Vector2>(enemy2_5.enemyNoPos, enemy2_5.transform.position);

            SaveGame.Save<bool>(enemy2_6.enemyNo, enemy2_6.broken);
            SaveGame.Save<Vector2>(enemy2_6.enemyNoPos, enemy2_6.transform.position);

            SaveGame.Save<bool>(enemy2_7.enemyNo, enemy2_7.broken);
            SaveGame.Save<Vector2>(enemy2_7.enemyNoPos, enemy2_7.transform.position);

            SaveGame.Save<bool>(enemy2_8.enemyNo, enemy2_8.broken);
            SaveGame.Save<Vector2>(enemy2_8.enemyNoPos, enemy2_8.transform.position);

            SaveGame.Save<bool>(enemy2_9.enemyNo, enemy2_9.broken);
            SaveGame.Save<Vector2>(enemy2_9.enemyNoPos, enemy2_9.transform.position);

            SaveGame.Save<bool>(enemy2_10.enemyNo, enemy2_10.broken);
            SaveGame.Save<Vector2>(enemy2_10.enemyNoPos, enemy2_10.transform.position);

            SaveGame.Save<bool>(enemy2_11.enemyNo, enemy2_11.broken);
            SaveGame.Save<Vector2>(enemy2_11.enemyNoPos, enemy2_11.transform.position);

            SaveGame.Save<bool>(enemy2_12.enemyNo, enemy2_12.broken);
            SaveGame.Save<Vector2>(enemy2_12.enemyNoPos, enemy2_12.transform.position);

            SaveGame.Save<bool>(enemy2_13.enemyNo, enemy2_13.broken);
            SaveGame.Save<Vector2>(enemy2_13.enemyNoPos, enemy2_13.transform.position);

            SaveGame.Save<bool>(enemy2_14.enemyNo, enemy2_14.broken);
            SaveGame.Save<Vector2>(enemy2_14.enemyNoPos, enemy2_14.transform.position);

            SaveGame.Save<bool>(enemy2_15.enemyNo, enemy2_15.broken);
            SaveGame.Save<Vector2>(enemy2_15.enemyNoPos, enemy2_15.transform.position);

            SaveGame.Save<bool>(enemy2_16.enemyNo, enemy2_16.broken);
            SaveGame.Save<Vector2>(enemy2_16.enemyNoPos, enemy2_16.transform.position);

            SaveGame.Save<bool>(enemy2_17.enemyNo, enemy2_17.broken);
            SaveGame.Save<Vector2>(enemy2_17.enemyNoPos, enemy2_17.transform.position);

            SaveGame.Save<bool>(enemy2_18.enemyNo, enemy2_18.broken);
            SaveGame.Save<Vector2>(enemy2_18.enemyNoPos, enemy2_18.transform.position);

            SaveGame.Save<bool>(enemy2_19.enemyNo, enemy2_19.broken);
            SaveGame.Save<Vector2>(enemy2_19.enemyNoPos, enemy2_19.transform.position);

            SaveGame.Save<bool>(enemy2_20.enemyNo, enemy2_20.broken);
            SaveGame.Save<Vector2>(enemy2_20.enemyNoPos, enemy2_20.transform.position);

            SaveGame.Save<bool>(enemy2_21.enemyNo, enemy2_21.broken);
            SaveGame.Save<Vector2>(enemy2_21.enemyNoPos, enemy2_21.transform.position);

            SaveGame.Save<bool>(enemy2_22.enemyNo, enemy2_22.broken);
            SaveGame.Save<Vector2>(enemy2_22.enemyNoPos, enemy2_22.transform.position);

            SaveGame.Save<bool>(enemy2_23.enemyNo, enemy2_23.broken);
            SaveGame.Save<Vector2>(enemy2_23.enemyNoPos, enemy2_23.transform.position);

            SaveGame.Save<bool>(enemy2_24.enemyNo, enemy2_24.broken);
            SaveGame.Save<Vector2>(enemy2_24.enemyNoPos, enemy2_24.transform.position);

            SaveGame.Save<bool>(enemy2_25.enemyNo, enemy2_25.broken);
            SaveGame.Save<Vector2>(enemy2_25.enemyNoPos, enemy2_25.transform.position);

            SaveGame.Save<bool>(enemy2_26.enemyNo, enemy2_26.broken);
            SaveGame.Save<Vector2>(enemy2_26.enemyNoPos, enemy2_26.transform.position);

            SaveGame.Save<bool>(enemy2_27.enemyNo, enemy2_27.broken);
            SaveGame.Save<Vector2>(enemy2_27.enemyNoPos, enemy2_27.transform.position);

            SaveGame.Save<bool>(enemy2_28.enemyNo, enemy2_28.broken);
            SaveGame.Save<Vector2>(enemy2_28.enemyNoPos, enemy2_28.transform.position);

            SaveGame.Save<bool>(enemy2_29.enemyNo, enemy2_29.broken);
            SaveGame.Save<Vector2>(enemy2_29.enemyNoPos, enemy2_29.transform.position);

            SaveGame.Save<bool>(enemy2_30.enemyNo, enemy2_30.broken);
            SaveGame.Save<Vector2>(enemy2_30.enemyNoPos, enemy2_30.transform.position);



            SaveGame.Save<bool>(health2_1.collectibleNo, health2_1.active);



            SaveGame.Save<bool>(cog2_1.collectibleNo, cog2_1.active);



            SaveGame.Save<bool>(jambi.JambiNo, false);



            SaveGame.Save<Vector2>(boss.transform.name, boss.transform.position);

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
