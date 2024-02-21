using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using EZCameraShake;
using TMPro;

public class Tilemap : MonoBehaviour
{
    public GameObject tilemap;
    public GameObject tilemap2;
    public GameObject tilemap3;

    public GameObject environment;
    public GameObject environment2;

    public GameObject TreeForeground1;
    public GameObject TreeForeground2;
    public GameObject TreeForeground3;
    public GameObject TreeForeground4;
    public GameObject TreeForeground5;
    public GameObject TreeForeground6;
    public GameObject EndTrigger;

    public GameObject End2Trigger;
    public GameObject SirenHead;

    public GameObject Music;
    public GameObject HealthCollectibles;
    public GameObject HealthCollectibles2;
    public GameObject AmmoCollectibles;
    public GameObject AmmoCollectibles2;
    public GameObject Enemies;
    public GameObject Enemies2;

    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioClip2;

    void Start()
    {
        if (SaveGame.Exists("level"))
        {
            int levelNo = SaveGame.Load<int>("level");
            if (levelNo < 6)
            {
                tilemap.SetActive(true);
                tilemap2.SetActive(false);

                environment.SetActive(true);
                environment2.SetActive(false);
            }
            else if (levelNo >= 6)
            {
                tilemap.SetActive(false);
                tilemap2.SetActive(true);

                environment.SetActive(false);
                environment2.SetActive(true);
            }
        }

        if (SaveGame.Exists("secret"))
        {
            tilemap.SetActive(true);
            tilemap2.SetActive(false);
            tilemap3.SetActive(true);

            environment.SetActive(true);
            environment2.SetActive(false);

            Enemies.SetActive(false);
            Enemies2.SetActive(false);
            HealthCollectibles.SetActive(false);
            HealthCollectibles2.SetActive(false);
            AmmoCollectibles.SetActive(false);
            AmmoCollectibles2.SetActive(false);

            TreeForeground1.SetActive(false);
            TreeForeground2.SetActive(false);
            TreeForeground3.SetActive(false);
            TreeForeground4.SetActive(true);
            TreeForeground5.SetActive(true);
            TreeForeground6.SetActive(true);

            EndTrigger.SetActive(false);
            Music.SetActive(false);

            End2Trigger.SetActive(true);
            SirenHead.SetActive(true);

            CameraShaker.Instance.StartShake(3f, 3f, 1f);
        }
    }

    public void OnMouseHover()
    {
        audioSource.ignoreListenerPause = true;
        audioSource.PlayOneShot(audioClip);
    }

    public void OnMousePress()
    {
        audioSource.ignoreListenerPause = true;
        audioSource.PlayOneShot(audioClip2);
    }
}
