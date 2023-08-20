using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    private Rigidbody2D myRigidBody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;
    private Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentState.Equals(EnemyState.stagger))
        {
            StartCoroutine(Hurt());
        }
        CheckDistance();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

            if (collision.gameObject.CompareTag("Player"))
            {
                if (attachSpeed <= canAttack)
                {
                    collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-baseAttack);
                    canAttack = 0f;
                }
                else
                {
                    canAttack += Time.deltaTime;
                }
            
        }
      
    }
    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
             temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            myRigidBody.MovePosition(temp);
            anim.SetBool("wakeUp", true);
        }
        else if (Vector3.Distance(target.position,transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }    }
    IEnumerator Hurt()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("hurt", true);
        yield return null;
        anim.SetBool("hurt", false);
        yield return new WaitForSeconds(0.5f);
        currentState = EnemyState.idle;
    }



}
