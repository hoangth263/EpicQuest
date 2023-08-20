using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PlayerMovement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    // Start is called before the first frame update
    public float maxHealth;
    public float health;
    public PlayerMovement playerMovement;
    private Animator animator;
    void Start()
    {
        instance = this;
        health = maxHealth;
        SoundManager.instance.TurnOnGameMusic();
    }

    public void UpdateHealth(float dame)
    {
        health+= dame;
        if (health > 0)
        {
            SoundManager.instance.TakingDamage();
        }
        if(health > maxHealth)
        {
            health=maxHealth;
        }else if(health <= 0) {
            health = 0f;
        }
        HeartDisplay.instance.UpdateHpDisplay(health);
        if (health <= 0f)
        {
            SceneManager.LoadScene("DeathScene");
            SoundManager.instance.movementSfx.Stop();
        }
    }

    public float GetHeatlh()
    {
        return health;
    }
}
