using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using BayatGames.SaveGameFree;
using TMPro;

public class PauseMenu : MonoBehaviour
{

    public GameObject gameUI;
    public GameObject levelUI;

    public GameObject pauseMenu;
    public GameObject settingsMenu;

    public static bool gameIsPaused = false;

    public AudioMixer audioMixer;

    Resolution[] resolutions;
    public Dropdown ResolutionDropdown;

    public Dropdown QualityDropdown;
    public Toggle fullscreenToggle;
    public Slider volumeSlider;

    void Start()
    {
        Cursor.visible = false;

        int CurrentResolutionIndex = 0;
        resolutions = Screen.resolutions;

        ResolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; ++i)
        {
            string Option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(Option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResolutionIndex = i;
            }
        }

        ResolutionDropdown.AddOptions(options);

        if (SaveGame.Exists("isFullscreen"))
        {
            Screen.fullScreen = SaveGame.Load<bool>("isFullscreen");
            fullscreenToggle.isOn = SaveGame.Load<bool>("isFullscreen");
        }
        if (SaveGame.Exists("Volume"))
        {
            audioMixer.SetFloat("volume", SaveGame.Load<float>("Volume"));
            volumeSlider.value = SaveGame.Load<float>("Volume");
        }
        if (SaveGame.Exists("qualityIndex"))
        {
            QualitySettings.SetQualityLevel(SaveGame.Load<int>("qualityIndex"));
            QualityDropdown.value = SaveGame.Load<int>("qualityIndex");
        }
        if (SaveGame.Exists("ResolutionIndex"))
        {
            Resolution resolution = resolutions[SaveGame.Load<int>("ResolutionIndex")];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            ResolutionDropdown.value = SaveGame.Load<int>("ResolutionIndex");
            ResolutionDropdown.RefreshShownValue();
        }
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        SaveGame.Save<int>("ResolutionIndex", ResolutionIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        gameUI.SetActive(true);
        levelUI.SetActive(true);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        Cursor.visible = true;
        gameUI.SetActive(false);
        levelUI.SetActive(false);
        pauseMenu.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Settings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Back()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void Menu()
    {
        SaveGame.Delete("secret");
        SaveGame.Delete("BOSS3");
        SaveGame.Delete("Jambi10");
        Resume();
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        SaveGame.Delete("secret");
        SaveGame.Delete("BOSS3");
        SaveGame.Delete("Jambi10");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        SaveGame.Save<float>("Volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        SaveGame.Save<int>("qualityIndex", qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        SaveGame.Save<bool>("isFullscreen", isFullscreen);
    }
}
