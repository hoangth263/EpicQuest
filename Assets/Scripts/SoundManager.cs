using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static SoundManager instance;

    [SerializeField] private AudioSource AudSource, sfx;
    [SerializeField] public AudioSource movementSfx;

    [SerializeField] private AudioClip takenDamage, potBreak, menuAudio, gameAudio, deathAudio, swingSword, monsterHit, monsterDie, victoryTrumpet;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ChangeMusicVolume(float volume)
    {
        AudSource.volume = volume;
    }
    public float GetMusicVolume()
    {
        return AudSource.volume;
    }
    public void ChangeSFXVolume(float volume)
    {
        sfx.volume = volume;
        movementSfx.volume = volume;
    }
    public float GetSFXVolume()
    {
        return sfx.volume;
    }
    public void TurnOnGameMusic()
    {
        AudSource.clip = gameAudio;
        AudSource.loop = true;
        AudSource.Play();
    }
    public void TurnOnMenuMusic()
    {
        AudSource.clip = menuAudio;
        AudSource.loop = true;
        AudSource.Play();
    }
    public void DieMusic()
    {
        AudSource.clip = deathAudio;
        AudSource.loop = false;
        AudSource.Play();
    }
    public void TakingDamage()
    {
        sfx.PlayOneShot(takenDamage);
    }
    public void SwingingSword()
    {
        sfx.PlayOneShot(swingSword);
    }
    public void PotBreaking()
    {
        sfx.PlayOneShot(potBreak);
    }
    public void HittingMonster()
    {
        sfx.PlayOneShot(monsterHit);
    }
    public void MonsterDying()
    {
        sfx.PlayOneShot(monsterDie);
    }
    public void Victory()
    {
        AudSource.clip = victoryTrumpet;
        AudSource.loop = false;
        AudSource.Play();
    }
}
