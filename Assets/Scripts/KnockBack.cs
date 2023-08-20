using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    // Start is called before the first frame update
   /* private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D enemy = other.gameObject.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                StopAllCoroutines();
                Debug.Log("hit");
*//*                Vector2 difference = enemy.transform.position - this.transform.position;
                difference = difference.normalized * thrust;
                enemy.AddRelativeForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));*//*
            }
        }
    }*/
    IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
        }
    }

}
