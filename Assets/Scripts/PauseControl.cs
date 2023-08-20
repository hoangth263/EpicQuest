using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
    public static PauseControl instance;

    [SerializeField]
    private Button btnResume, btnMenu, btnVolume;
    [SerializeField]
    private Image ImgVolumeHigh, ImgVolumeMute;
    [SerializeField]
    private GameObject PauseMenu;

    void Start()
    {
        instance = this;
        SoundManager.instance.movementSfx.Stop();
        btnResume.onClick.AddListener(Resume);
        btnMenu.onClick.AddListener(Menu);
        btnVolume.onClick.AddListener(Volume);
    }

    void Update()
    {
        if (SoundManager.instance.GetMusicVolume() == 0)
        {
            ImgVolumeHigh.gameObject.SetActive(false);
            ImgVolumeMute.gameObject.SetActive(true);
        }
        else
        {
            ImgVolumeHigh.gameObject.SetActive(true);
            ImgVolumeMute.gameObject.SetActive(false);
        }
    }

    private void Volume()
    {
        if (SoundManager.instance.GetMusicVolume() > 1 || SoundManager.instance.GetMusicVolume() < 0)
        {
            SoundManager.instance.ChangeMusicVolume(1);
        }

        PauseMenu.SetActive(false);
        btnVolume.gameObject.SetActive(false);
        SceneManager.LoadScene("VolumeSettingScene", LoadSceneMode.Additive);
    }

    public void OpenMenu()
    {
        PauseMenu.SetActive(true);
        btnVolume.gameObject.SetActive(true);
    }

    private void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void Resume()
    {
        SceneManager.UnloadSceneAsync("PauseScene"); 
        if (MenuControl.instance != null)
        {
            MenuControl.instance.OpenMenu();
        }
        Time.timeScale = 1;
    }
}
