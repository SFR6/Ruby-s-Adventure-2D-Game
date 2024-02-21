using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using BayatGames.SaveGameFree;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject instructionsMenu;
    public GameObject loadingScreen;
    public GameObject deleteMenu;
    public Slider slider;

    public AudioMixer audioMixer;

    public GameObject newGameButton;
    public GameObject continueGameButton;
    public GameObject deleteProgressButton;

    public GameObject InstructionsText;
    float timer;

    bool played = false;

    bool instructions = false;

    public AudioSource audioSource;
    public GameObject background;
    public GameObject background2;
    public float timer2;
    public bool weird;

    ///public GameObject Image1;
    ///public GameObject Image2;

    Resolution[] resolutions;

    public AudioSource audioSourceButton;
    public AudioClip audioClip;
    public AudioClip audioClip2;

    void Start()
    {
        Cursor.visible = true;

        resolutions = Screen.resolutions;

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; ++i)
        {
            string Option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(Option);
        }

        if (SaveGame.Exists("instructions") && SaveGame.Load<bool>("instructions") == true)
        {
            instructions = true;
        }

        if (SaveGame.Exists("played") && SaveGame.Load<bool>("played") == true)
        {
            newGameButton.SetActive(false);
            continueGameButton.SetActive(true);
            deleteProgressButton.SetActive(true);
        }

        if (SaveGame.Exists("isFullscreen"))
        {
            Screen.fullScreen = SaveGame.Load<bool>("isFullscreen");
        }
        if (SaveGame.Exists("Volume"))
        {
            audioMixer.SetFloat("volume", SaveGame.Load<float>("Volume"));
        }
        if (SaveGame.Exists("qualityIndex"))
        {
            QualitySettings.SetQualityLevel(SaveGame.Load<int>("qualityIndex"));
        }

        if (SaveGame.Exists("ResolutionIndex"))
        {
            Resolution resolution = resolutions[SaveGame.Load<int>("ResolutionIndex")];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        weird = false;
        if (SaveGame.Exists("level") && SaveGame.Load<int>("level") >= 6 && !SaveGame.Exists("end"))
        {
            weird = true;
            timer2 = 20f;
        }
    }

    void Update()
    {
        if (weird == true)
        {
            timer2 -= Time.deltaTime;
            if (timer2 < 0f)
            {
                background.SetActive(false);
                background2.SetActive(true);
                audioSource.pitch = 0.7f;
            }
            if (timer2 < -0.7f)
            {
                background.SetActive(true);
                background2.SetActive(false);
                audioSource.pitch = 1f;
                timer2 = 20f;
            }
        }

        if (instructions == false)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                InstructionsText.SetActive(false);
            }
        }
    }

    public void PlayGame(int sceneIndex)
    {
        if (instructions == true)
        {
            played = true;
            SaveGame.Delete("end");
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }
        else if (instructions == false && InstructionsText.activeSelf == false)
        {
            timer = 2f;
            InstructionsText.SetActive(true);
        }
    }

    public void ContinueGame(int sceneIndex)
    {
        SaveGame.Delete("end");
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        Cursor.visible = false;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            yield return null;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        instructions = true;
        SaveGame.Save<bool>("instructions", instructions);
        instructionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Back()
    {
        instructionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Delete()
    {
        deleteMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void No()
    {
        deleteMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Yes()
    {
        newGameButton.SetActive(true);
        continueGameButton.SetActive(false);
        deleteProgressButton.SetActive(false);
        deleteMenu.SetActive(false);
        mainMenu.SetActive(true);
        SaveGame.DeleteAll();
        weird = false;
    }

    public void OnMouseHover()
    {
        audioSourceButton.PlayOneShot(audioClip);
    }

    public void OnMousePress()
    {
        audioSourceButton.PlayOneShot(audioClip2);
    }
}
