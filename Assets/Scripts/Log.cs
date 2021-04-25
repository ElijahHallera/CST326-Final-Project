using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class inherits from Enemy, which inherits from
//MonoBehaviour

public class Log : Enemy
{
    public Rigidbody2D myRigidbody;
    public Transform target; //player location
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition; //goes back to original position
    public Animator animator;

    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //Looks for player object 
        target = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnimation(temp - transform.position);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                animator.SetBool("wakeUp", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            animator.SetBool("wakeUp", false);
        }
    }

    public void SetAnimatorFloat(Vector2 setVector)
    {
        animator.SetFloat("moveX", setVector.x);
        animator.SetFloat("moveY", setVector.y);
    }

    public void changeAnimation(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimatorFloat(Vector2.right);
            }else if (direction.x < 0)
            {
                SetAnimatorFloat(Vector2.left);
            }

        }else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimatorFloat(Vector2.up);
            }else if (direction.y < 0)
            {
                SetAnimatorFloat(Vector2.down);
            }
        }
    }

    public void ChangeState(EnemyState newState)
    {
        //checks currentState enum inherited from Enemy Script
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
