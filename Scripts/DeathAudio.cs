using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class DeathAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioClip audioClip;
    public AudioClip audioClip2;

    // Start is called before the first frame update
    void Start()
    {
        int levelNo = SaveGame.Load<int>("level");
        if (levelNo < 6)
        {
            audioSource2.Stop();
            audioSource.PlayOneShot(audioClip);
        }
        else if (levelNo >= 6)
        {
            audioSource.Stop();
            audioSource2.PlayOneShot(audioClip2);
        }
    }
}
