using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField]
    private Image imgMusicVolume, imgSFXVolume;

    [SerializeField]
    private Button btnReturn, btnMusicUp, btnMusicDown, btnSFXUp, btnSFXDown;

    [SerializeField]
    private Sprite volume0, volume1, volume2, volume3, volume4, volume5;

    void Start()
    {
        btnMusicUp.onClick.AddListener(MusicUp);
        btnMusicDown.onClick.AddListener(MusicDown);

        btnSFXUp.onClick.AddListener(SFXUp);
        btnSFXDown.onClick.AddListener(SFXDown);

        btnReturn.onClick.AddListener(Return);

    }

    void Update()
    {
        SetVolumeImage();
    }

    private void Return()
    {
        SceneManager.UnloadSceneAsync("VolumeSettingScene");

        if (MenuControl.instance != null)
        {
            MenuControl.instance.OpenMenu();
        }
        if (PauseControl.instance != null)
        {
            PauseControl.instance.OpenMenu();
        }
        if (DeathScreenControl.instance != null)
        {
            DeathScreenControl.instance.OpenDeath();
        }
    }

    private void MusicDown()
    {
        switch (SoundManager.instance.GetMusicVolume())
        {
            case 1:
                SoundManager.instance.ChangeMusicVolume(0.8f);
                break;
            case 0.8f:
                SoundManager.instance.ChangeMusicVolume(0.6f);
                break;
            case 0.6f:
                SoundManager.instance.ChangeMusicVolume(0.4f);
                break;
            case 0.4f:
                SoundManager.instance.ChangeMusicVolume(0.2f);
                break;
            default:
                SoundManager.instance.ChangeMusicVolume(0);
                break;
        }
    }

    private void MusicUp()
    {
        switch (SoundManager.instance.GetMusicVolume())
        {
            case 0:
                SoundManager.instance.ChangeMusicVolume(0.2f);
                break;
            case 0.2f:
                SoundManager.instance.ChangeMusicVolume(0.4f);
                break;
            case 0.4f:
                SoundManager.instance.ChangeMusicVolume(0.6f);
                break;
            case 0.6f:
                SoundManager.instance.ChangeMusicVolume(0.8f);
                break;
            default:
                SoundManager.instance.ChangeMusicVolume(1);
                break;
        }
    }
    private void SFXDown()
    {
        switch (SoundManager.instance.GetSFXVolume())
        {
            case 1:
                SoundManager.instance.ChangeSFXVolume(0.8f);
                break;
            case 0.8f:
                SoundManager.instance.ChangeSFXVolume(0.6f);
                break;
            case 0.6f:
                SoundManager.instance.ChangeSFXVolume(0.4f);
                break;
            case 0.4f:
                SoundManager.instance.ChangeSFXVolume(0.2f);
                break;
            default:
                SoundManager.instance.ChangeSFXVolume(0);
                break;
        }
    }

    private void SFXUp()
    {
        switch (SoundManager.instance.GetSFXVolume())
        {
            case 0:
                SoundManager.instance.ChangeSFXVolume(0.2f);
                break;
            case 0.2f:
                SoundManager.instance.ChangeSFXVolume(0.4f);
                break;
            case 0.4f:
                SoundManager.instance.ChangeSFXVolume(0.6f);
                break;
            case 0.6f:
                SoundManager.instance.ChangeSFXVolume(0.8f);
                break;
            default:
                SoundManager.instance.ChangeSFXVolume(1);
                break;
        }
    }

    private void SetVolumeImage()
    {
        switch (SoundManager.instance.GetMusicVolume())
        {
            case 0:
                imgMusicVolume.sprite = volume0;
                break;
            case 0.2f:
                imgMusicVolume.sprite = volume1;
                break;
            case 0.4f:
                imgMusicVolume.sprite = volume2;
                break;
            case 0.6f:
                imgMusicVolume.sprite = volume3;
                break;
            case 0.8f:
                imgMusicVolume.sprite = volume4;
                break;
            case 1:
                imgMusicVolume.sprite = volume5;
                break;
            default:
                imgMusicVolume.sprite = volume5;
                break;
        }

        switch (SoundManager.instance.GetSFXVolume())
        {
            case 0:
                imgSFXVolume.sprite = volume0;
                break;
            case 0.2f:
                imgSFXVolume.sprite = volume1;
                break;
            case 0.4f:
                imgSFXVolume.sprite = volume2;
                break;
            case 0.6f:
                imgSFXVolume.sprite = volume3;
                break;
            case 0.8f:
                imgSFXVolume.sprite = volume4;
                break;
            case 1:
                imgSFXVolume.sprite = volume5;
                break;
            default:
                imgSFXVolume.sprite = volume5;
                break;
        }
    }

}