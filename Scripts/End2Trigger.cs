using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class End2Trigger : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject mainCanvas;
    public GameObject endCanvas;

    public AudioSource audioSource2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController player = other.GetComponent<RubyController>();

        if (player != null)
        {
            Cursor.visible = true;

            Destroy(player.audioSource);
            Destroy(player.animator);

            SaveGame.Delete("secret");
            SaveGame.Delete("health2");
            SaveGame.Delete("ammo2");
            SaveGame.Delete("position2");

            SaveGame.Delete("BOSS3");
            SaveGame.Delete("Jambi10");

            Time.timeScale = 0f;

            mainCanvas.SetActive(false);
            endCanvas.SetActive(true);
            audioSource.Play();

            audioSource2.Stop();
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
