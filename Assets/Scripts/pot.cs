using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        animator.SetBool("smash", false);
    }

    // Update is called once per frame

    public void Smash()
    {
        SoundManager.instance.PotBreaking();
        animator.SetBool("smash", true);
        StartCoroutine(breakCo());
    }
    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
