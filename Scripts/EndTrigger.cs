using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class EndTrigger : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject mainCanvas;
    public GameObject endCanvas;
    public GameObject backgroundMusic2;

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
            Time.timeScale = 0f;

            Destroy(player.audioSource);
            Destroy(player.animator);

            Cursor.visible = true;

            mainCanvas.SetActive(false);
            backgroundMusic2.SetActive(false);
            endCanvas.SetActive(true);
            audioSource.Play();
        }
    }

    public void ReturnToMainMenu()
    {
        SaveGame.Save<bool>("end", true);
        SceneManager.LoadScene(0);
    }
}
