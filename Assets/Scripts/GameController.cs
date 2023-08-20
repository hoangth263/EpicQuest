using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    private Button btnPause;

    void Start()
    {
        instance = this;
     
        btnPause.onClick.AddListener(Pause);
    }

    private void Pause()
    {
        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        SceneManager.UnloadSceneAsync("PauseScene");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if ( PauseControl.instance == null)
            {
                Pause();
            }
            else
            {
                UnPause();
              
            }
        }
    }
}
