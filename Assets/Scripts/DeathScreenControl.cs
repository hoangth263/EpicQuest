using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreenControl : MonoBehaviour
{
    [SerializeField]
    private Button btnRetry, btnMenu, btnVolume;

    [SerializeField]
    private GameObject container;

    public static DeathScreenControl instance;

    void Start() 
    { 
        instance = this;
        btnRetry.onClick.AddListener(RetryClick);
        btnMenu.onClick.AddListener(OpenMenu);
        btnVolume.onClick.AddListener(Volume);
        SoundManager.instance.DieMusic();
    }

    private void OpenMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void RetryClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void Volume()
    {
        if (SoundManager.instance.GetMusicVolume() > 1 || SoundManager.instance.GetMusicVolume() < 0)
        {
            SoundManager.instance.ChangeMusicVolume(1);
        }

        btnVolume.gameObject.SetActive(false);
        container.SetActive(false);
        SceneManager.LoadScene("VolumeSettingScene", LoadSceneMode.Additive);
    }

    public void OpenDeath()
    {
        container.SetActive(true);
        btnMenu.gameObject.SetActive(true);
    }
}
