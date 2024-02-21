using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using EZCameraShake;

public class MusicStopTrigger : MonoBehaviour
{
    float timer;

    public GameObject Music;
    public GameObject sirenHead;

    public GameObject SaveIcon;

    public Transform Boss3;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0f)
        {
            SaveIcon.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController player = other.GetComponent<RubyController>();

        if (player != null)
        {
            timer = 3f;

            SaveGame.Save<Vector2>(Boss3.name, Boss3.position);
            SaveGame.Save<bool>("Jambi10", false);
            SaveGame.Save<bool>("secret", true);

            SaveGame.Save<int>("health2", player.currentHealth);
            SaveGame.Save<int>("ammo2", player.numberOfCogs);
            SaveGame.Save<Vector2>("position2", player.rigidbody2d.position);

            Music.SetActive(false);
            sirenHead.SetActive(true);

            SaveIcon.SetActive(true);

            CameraShaker.Instance.StartShake(3f, 3f, 1f);

            Destroy(gameObject, 5f);
        }
    }
}
