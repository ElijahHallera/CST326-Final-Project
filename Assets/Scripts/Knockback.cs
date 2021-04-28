using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust; //force that character knocks back with
    public float knockBackTime;
    public float damage;
    public PlayerHealth health;

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Breakable")&&collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<pot>().Smash();
        }
        */

        if (collision.gameObject.CompareTag("Enemy")||collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            //if enemy has rigidbody
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (collision.gameObject.CompareTag("Enemy") && collision.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    collision.GetComponent<Enemy>().Knock(hit, knockBackTime, damage);
                }

                if (collision.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    collision.GetComponent<PlayerMovement>().Knock(knockBackTime);
                    //collision.GetComponent<PlayerHealth>().playerHit();
                    health.playerHit();
                }
            }
        }
    }
}
