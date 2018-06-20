using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu_Buttons : MonoBehaviour {

    // Use this for initialization
    Resolution[] resolutions;

    public GameObject MainMenu;
    public GameObject SettingMenu;

    public AudioMixer Mixer;

    public Dropdown resolutionDropdown;

    void Start()
    {
        Screen.fullScreen = false;
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    
	
	// Update is called once per frame
	public void QuitGame()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("Minigame");
    }

    public void Settings()
    {
        MainMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        SettingMenu.SetActive(false);
    }
    public void SetVolume(float volume)
    {
        Mixer.SetFloat("Volume", volume);
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, false);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
