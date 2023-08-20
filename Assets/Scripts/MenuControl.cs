using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.UI.CanvasScaler;

public class MenuControl : MonoBehaviour
{
    public static MenuControl instance;

    [SerializeField]
    private Button btnPlay, btnVolume, btnQuit;

    [SerializeField]
    private Image ImgVolumeHigh, ImgVolumeMute;

    [SerializeField]
    private GameObject PnlMenu;

    void Start()
    {
        instance = this;
        btnVolume.onClick.AddListener(Volume);
        btnPlay.onClick.AddListener(ChangeScene);
        btnQuit.onClick.AddListener(QuitConfirm);
        SoundManager.instance.TurnOnMenuMusic();
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

    private void QuitConfirm()
    {
        SceneManager.LoadScene("QuitingScene", LoadSceneMode.Additive);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    private void Volume()
    {
        if (SoundManager.instance.GetMusicVolume() > 1 || SoundManager.instance.GetMusicVolume() < 0)
        {
            SoundManager.instance.ChangeMusicVolume(1);
        }

        PnlMenu.gameObject.SetActive(false);
        btnVolume.gameObject.SetActive(false);
        SceneManager.LoadScene("VolumeSettingScene", LoadSceneMode.Additive);
    }
    public void OpenMenu()
    {
        PnlMenu.gameObject.SetActive(true);
        btnVolume.gameObject.SetActive(true);
    }
}
