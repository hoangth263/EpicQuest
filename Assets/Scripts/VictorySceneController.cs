using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictorySceneController : MonoBehaviour
{
    [SerializeField] private Button btnMenu, btnVolume;
    public static VictorySceneController instance;

    void Start()
    {
        instance = this;
        SoundManager.instance.movementSfx.Stop();
        SoundManager.instance.Victory();
        btnMenu.onClick.AddListener(OpenMenu);
        btnVolume.onClick.AddListener(Volume);
    }

    private void Volume()
    {
        if (SoundManager.instance.GetMusicVolume() > 1 || SoundManager.instance.GetMusicVolume() < 0)
        {
            SoundManager.instance.ChangeMusicVolume(1);
        }

        //btnVolume.gameObject.SetActive(false);
        SceneManager.LoadScene("VolumeSettingScene", LoadSceneMode.Additive);
    }


    private void OpenMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
