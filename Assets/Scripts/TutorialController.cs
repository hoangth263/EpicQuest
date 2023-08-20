using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private Button btnPlay;

    void Start()
    {
        btnPlay.onClick.AddListener(Play);
    }

    private void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    void Update()
    {
        
    }
}
