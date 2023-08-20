using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerState
    {
        walk, attack, interact
    }
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentState = PlayerState.walk;
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame


    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D)||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!SoundManager.instance.movementSfx.isPlaying)
            {
                SoundManager.instance.movementSfx.Play();
            }
        }
        else
        {
            if (SoundManager.instance.movementSfx.isPlaying)
            {
                SoundManager.instance.movementSfx.Stop();
            }
        }
        if (PlayerHealth.instance.GetHeatlh() <= 0 || VictorySceneController.instance != null)
        {
            if (SoundManager.instance.movementSfx.isPlaying)
            {
                SoundManager.instance.movementSfx.Stop();
            }
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();

        }
    }
    private IEnumerator AttackCo()
    {
        SoundManager.instance.SwingingSword();
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.4f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            Debug.Log(change.ToString());
            MoveCharacter();
        }
        else
        {
            myRigidbody.velocity = Vector3.zero;
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
            );
    }

}
