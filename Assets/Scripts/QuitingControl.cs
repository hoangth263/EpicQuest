using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitingControl : MonoBehaviour
{

    private Button btnConfirm;
    private Button btnCancel;

    void Start()
    {
        btnConfirm = transform.Find("Container/PnlMenu/BtnContainer/BtnConfirm").GetComponent<Button>();
        btnCancel = transform.Find("Container/PnlMenu/BtnContainer/BtnCancel").GetComponent<Button>();

        btnConfirm.onClick.AddListener(Quit);
        btnCancel.onClick.AddListener(Cancel);
    }

    private void Cancel()
    {
        SceneManager.UnloadSceneAsync("QuitingScene");
    }

    private void Quit()
    {
        Application.Quit();
    }
}
