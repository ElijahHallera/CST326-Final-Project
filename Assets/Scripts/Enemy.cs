using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    [Header("State Machine")]
    public EnemyState currentState;

    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject deathEffect;
    public bool isBoss;

    void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DeathEffect();
            Destroy(this.gameObject);
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockBackTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockBackTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockBackTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockBackTime);
            myRigidbody.velocity = Vector2.zero;
            //Gets enemy script and sets the currentState enum to idle
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

}
