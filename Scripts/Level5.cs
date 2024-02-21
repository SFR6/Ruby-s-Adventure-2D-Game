using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using UnityEditor;

public class Level5 : MonoBehaviour
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
    public AudioClip audioClip2;
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
    public GameObject Enemy1_13;
    public GameObject Enemy1_14;
    public GameObject Enemy1_15;
    public GameObject Enemy1_16;
    public GameObject Enemy1_17;
    public GameObject Enemy1_18;
    public GameObject Enemy1_19;
    public GameObject Enemy1_20;
    public GameObject Enemy1_21;
    public GameObject Enemy1_22;
    public GameObject Enemy1_23;
    public GameObject Enemy1_24;
    public GameObject Enemy1_25;
    public GameObject Enemy1_26;
    public GameObject Enemy1_27;
    public GameObject Enemy1_28;
    public GameObject Enemy1_29;
    public GameObject Enemy1_30;
    public GameObject Enemy1_31;
    public GameObject Enemy1_32;
    public GameObject Enemy1_33;
    public GameObject Enemy1_34;
    public GameObject Enemy1_35;
    public GameObject Enemy1_36;
    public GameObject Enemy1_37;

    public GameObject Health1_1;
    public GameObject Health1_2;
    public GameObject Health1_3;
    public GameObject Health1_4;
    public GameObject Health1_5;
    public GameObject Health1_6;

    public GameObject Cog1_1;
    public GameObject Cog1_2;
    public GameObject Cog1_3;
    public GameObject Cog1_4;

    public GameObject Jambi;

    public GameObject UIElement1;
    public GameObject UIElement2;
    public GameObject UIElement3;

    public GameObject MainCamera;

    public GameObject backgroundMusic;
    public GameObject backgroundMusic2;

    public GameObject Tilemap;
    public GameObject Tilemap2;
    public GameObject Environment;
    public GameObject Environment2;

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
        EnemyController enemy1_13 = Enemy1_13.GetComponent<EnemyController>();
        EnemyController enemy1_14 = Enemy1_14.GetComponent<EnemyController>();
        EnemyController enemy1_15 = Enemy1_15.GetComponent<EnemyController>();
        EnemyController enemy1_16 = Enemy1_16.GetComponent<EnemyController>();
        EnemyController enemy1_17 = Enemy1_17.GetComponent<EnemyController>();
        EnemyController enemy1_18 = Enemy1_18.GetComponent<EnemyController>();
        EnemyController enemy1_19 = Enemy1_19.GetComponent<EnemyController>();
        EnemyController enemy1_20 = Enemy1_20.GetComponent<EnemyController>();
        EnemyController enemy1_21 = Enemy1_21.GetComponent<EnemyController>();
        EnemyController enemy1_22 = Enemy1_22.GetComponent<EnemyController>();
        EnemyController enemy1_23 = Enemy1_23.GetComponent<EnemyController>();
        EnemyController enemy1_24 = Enemy1_24.GetComponent<EnemyController>();
        EnemyController enemy1_25 = Enemy1_25.GetComponent<EnemyController>();
        EnemyController enemy1_26 = Enemy1_26.GetComponent<EnemyController>();
        EnemyController enemy1_27 = Enemy1_27.GetComponent<EnemyController>();
        EnemyController enemy1_28 = Enemy1_28.GetComponent<EnemyController>();
        EnemyController enemy1_29 = Enemy1_29.GetComponent<EnemyController>();
        EnemyController enemy1_30 = Enemy1_30.GetComponent<EnemyController>();
        EnemyController enemy1_31 = Enemy1_31.GetComponent<EnemyController>();
        EnemyController enemy1_32 = Enemy1_32.GetComponent<EnemyController>();
        EnemyController enemy1_33 = Enemy1_33.GetComponent<EnemyController>();
        EnemyController enemy1_34 = Enemy1_34.GetComponent<EnemyController>();
        EnemyController enemy1_35 = Enemy1_35.GetComponent<EnemyController>();
        EnemyController enemy1_36 = Enemy1_36.GetComponent<EnemyController>();
        EnemyController enemy1_37 = Enemy1_37.GetComponent<EnemyController>();


        HealthCollectible health1_1 = Health1_1.GetComponent<HealthCollectible>();
        HealthCollectible health1_2 = Health1_2.GetComponent<HealthCollectible>();
        HealthCollectible health1_3 = Health1_3.GetComponent<HealthCollectible>();
        HealthCollectible health1_4 = Health1_4.GetComponent<HealthCollectible>();
        HealthCollectible health1_5 = Health1_5.GetComponent<HealthCollectible>();
        HealthCollectible health1_6 = Health1_6.GetComponent<HealthCollectible>();

        AmmoCollectible cog1_1 = Cog1_1.GetComponent<AmmoCollectible>();
        AmmoCollectible cog1_2 = Cog1_2.GetComponent<AmmoCollectible>();
        AmmoCollectible cog1_3 = Cog1_3.GetComponent<AmmoCollectible>();
        AmmoCollectible cog1_4 = Cog1_4.GetComponent<AmmoCollectible>();

        NPC jambi = Jambi.GetComponent<NPC>();

        UIElements uiElement1 = UIElement1.GetComponent<UIElements>();
        UIElements uiElement2 = UIElement2.GetComponent<UIElements>();
        UIElements uiElement3 = UIElement3.GetComponent<UIElements>();

        if (player != null && isPlayerAtTrigger == 0)
        {
            isPlayerAtTrigger = 1;
            audioSource.PlayOneShot(audioClip);
            audioSource.PlayOneShot(audioClip2);

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

            SaveGame.Save<bool>(enemy1_13.enemyNo, enemy1_13.broken);
            SaveGame.Save<Vector2>(enemy1_13.enemyNoPos, enemy1_13.transform.position);

            SaveGame.Save<bool>(enemy1_14.enemyNo, enemy1_14.broken);
            SaveGame.Save<Vector2>(enemy1_14.enemyNoPos, enemy1_14.transform.position);

            SaveGame.Save<bool>(enemy1_15.enemyNo, enemy1_15.broken);
            SaveGame.Save<Vector2>(enemy1_15.enemyNoPos, enemy1_15.transform.position);

            SaveGame.Save<bool>(enemy1_16.enemyNo, enemy1_16.broken);
            SaveGame.Save<Vector2>(enemy1_16.enemyNoPos, enemy1_16.transform.position);

            SaveGame.Save<bool>(enemy1_17.enemyNo, enemy1_17.broken);
            SaveGame.Save<Vector2>(enemy1_17.enemyNoPos, enemy1_17.transform.position);

            SaveGame.Save<bool>(enemy1_18.enemyNo, enemy1_18.broken);
            SaveGame.Save<Vector2>(enemy1_18.enemyNoPos, enemy1_18.transform.position);

            SaveGame.Save<bool>(enemy1_19.enemyNo, enemy1_19.broken);
            SaveGame.Save<Vector2>(enemy1_19.enemyNoPos, enemy1_19.transform.position);

            SaveGame.Save<bool>(enemy1_20.enemyNo, enemy1_20.broken);
            SaveGame.Save<Vector2>(enemy1_20.enemyNoPos, enemy1_20.transform.position);

            SaveGame.Save<bool>(enemy1_21.enemyNo, enemy1_21.broken);
            SaveGame.Save<Vector2>(enemy1_21.enemyNoPos, enemy1_21.transform.position);

            SaveGame.Save<bool>(enemy1_22.enemyNo, enemy1_22.broken);
            SaveGame.Save<Vector2>(enemy1_22.enemyNoPos, enemy1_22.transform.position);

            SaveGame.Save<bool>(enemy1_23.enemyNo, enemy1_23.broken);
            SaveGame.Save<Vector2>(enemy1_23.enemyNoPos, enemy1_23.transform.position);

            SaveGame.Save<bool>(enemy1_24.enemyNo, enemy1_24.broken);
            SaveGame.Save<Vector2>(enemy1_24.enemyNoPos, enemy1_24.transform.position);

            SaveGame.Save<bool>(enemy1_25.enemyNo, enemy1_25.broken);
            SaveGame.Save<Vector2>(enemy1_25.enemyNoPos, enemy1_25.transform.position);

            SaveGame.Save<bool>(enemy1_26.enemyNo, enemy1_26.broken);
            SaveGame.Save<Vector2>(enemy1_26.enemyNoPos, enemy1_26.transform.position);

            SaveGame.Save<bool>(enemy1_27.enemyNo, enemy1_27.broken);
            SaveGame.Save<Vector2>(enemy1_27.enemyNoPos, enemy1_27.transform.position);

            SaveGame.Save<bool>(enemy1_28.enemyNo, enemy1_28.broken);
            SaveGame.Save<Vector2>(enemy1_28.enemyNoPos, enemy1_28.transform.position);

            SaveGame.Save<bool>(enemy1_29.enemyNo, enemy1_29.broken);
            SaveGame.Save<Vector2>(enemy1_29.enemyNoPos, enemy1_29.transform.position);

            SaveGame.Save<bool>(enemy1_30.enemyNo, enemy1_30.broken);
            SaveGame.Save<Vector2>(enemy1_30.enemyNoPos, enemy1_30.transform.position);

            SaveGame.Save<bool>(enemy1_31.enemyNo, enemy1_31.broken);
            SaveGame.Save<Vector2>(enemy1_31.enemyNoPos, enemy1_31.transform.position);

            SaveGame.Save<bool>(enemy1_32.enemyNo, enemy1_32.broken);
            SaveGame.Save<Vector2>(enemy1_32.enemyNoPos, enemy1_32.transform.position);

            SaveGame.Save<bool>(enemy1_33.enemyNo, enemy1_33.broken);
            SaveGame.Save<Vector2>(enemy1_33.enemyNoPos, enemy1_33.transform.position);

            SaveGame.Save<bool>(enemy1_34.enemyNo, enemy1_34.broken);
            SaveGame.Save<Vector2>(enemy1_34.enemyNoPos, enemy1_34.transform.position);

            SaveGame.Save<bool>(enemy1_35.enemyNo, enemy1_35.broken);
            SaveGame.Save<Vector2>(enemy1_35.enemyNoPos, enemy1_35.transform.position);

            SaveGame.Save<bool>(enemy1_36.enemyNo, enemy1_36.broken);
            SaveGame.Save<Vector2>(enemy1_36.enemyNoPos, enemy1_36.transform.position);

            SaveGame.Save<bool>(enemy1_37.enemyNo, enemy1_37.broken);
            SaveGame.Save<Vector2>(enemy1_37.enemyNoPos, enemy1_37.transform.position);



            SaveGame.Save<bool>(health1_1.collectibleNo, health1_1.active);
            SaveGame.Save<bool>(health1_2.collectibleNo, health1_2.active);
            SaveGame.Save<bool>(health1_3.collectibleNo, health1_3.active);
            SaveGame.Save<bool>(health1_4.collectibleNo, health1_4.active);
            SaveGame.Save<bool>(health1_5.collectibleNo, health1_5.active);
            SaveGame.Save<bool>(health1_6.collectibleNo, health1_6.active);



            SaveGame.Save<bool>(cog1_1.collectibleNo, cog1_1.active);
            SaveGame.Save<bool>(cog1_2.collectibleNo, cog1_2.active);
            SaveGame.Save<bool>(cog1_3.collectibleNo, cog1_3.active);
            SaveGame.Save<bool>(cog1_4.collectibleNo, cog1_4.active);



            SaveGame.Save<bool>(jambi.JambiNo, false);



            uiElement1.image.sprite = uiElement1.sprite2;
            uiElement2.image.sprite = uiElement2.sprite2;
            uiElement3.image.sprite = uiElement3.sprite2;

            Tilemap.SetActive(false);
            Tilemap2.SetActive(true);
            Environment.SetActive(false);
            Environment2.SetActive(true);

            ++levelNo;
            SaveGame.Save<int>("level", levelNo);
            SaveGame.Save<int>(LevelName, 2);
            UILevel.instance.SetValue(levelNo);

            backgroundMusic.SetActive(false);
            backgroundMusic2.SetActive(true);
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
            GlitchEffect mainCamera = MainCamera.GetComponent<GlitchEffect>();
            mainCamera.colorIntensity = 0f;
            mainCamera.flipIntensity = 0f;
            mainCamera.intensity = 0f;

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
        GlitchEffect mainCamera = MainCamera.GetComponent<GlitchEffect>();
        mainCamera.colorIntensity = 1f;
        mainCamera.flipIntensity = 1f;
        mainCamera.intensity = 1f;

        timer += Time.deltaTime;

        level.alpha = timer / fadeDuration;
    }
}
