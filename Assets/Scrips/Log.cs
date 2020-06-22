using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    private Vector3 temp = Vector3.zero;

   
   

    // Start is called before the first frame update
    void Start()
    {
        
        
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        
        CheckDistance();
    }

    void CheckDistance()
    {
        if (target) 
        {
            if (Vector3.Distance(target.position, transform.position) <= chaseRadius
                && Vector3.Distance(target.position, transform.position) > attackRadius)
            {
                if (currentState == EnemyState.idle || currentState == EnemyState.walk || currentState == EnemyState.stagger)
                {
                    temp = (Vector2)(target.position - transform.position);
                }
               
            }
            else
            {
                temp = Vector2.zero; //stand still
            }
                
            transform.position = Vector2.MoveTowards(transform.position, transform.position + temp, speed * Time.deltaTime);
            SetAnimation(temp);
        }
    }
    void SetAnimation(Vector2 temp )
    {
        if (temp.magnitude > 0)
        {
            anim.SetFloat("MoveX", (temp.x));
            anim.SetFloat("MoveY", (temp.y));
            anim.SetBool("Wakeup", true);
            currentState = EnemyState.walk;

        }
        else
        {
            anim.SetBool("Wakeup", false);
            currentState = EnemyState.idle;
            
        }
    }

}
