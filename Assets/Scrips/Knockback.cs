using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Knockback : MonoBehaviour
{
    public float thrust; 
    public float knockTime;
    
    
    //public Rigidbody2D Rigbert;

    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        //For Breakable Objects
        if (other.gameObject.CompareTag("breakable"))
        {
            other.GetComponent<Pot>().Smash();
        }
        else if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                Vector2 difference = (hit.transform.position - transform.position);
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);

                if (other.gameObject.CompareTag("Enemy"))
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    StartCoroutine(KnockCoE(hit));
                }
                if (other.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<Player>().currentState = PlayerState.stagger;
                    StartCoroutine(KnockCoP(hit));
                }
                
                
            }
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage();
        }


    }


    public IEnumerator KnockCoP(Rigidbody2D RB)
    {
        
            
        yield return new WaitForSeconds(knockTime);
        RB.velocity = Vector2.zero;
        RB.GetComponent<Player>().currentState = PlayerState.idle;
        RB.velocity = Vector2.zero;

    }
    public IEnumerator KnockCoE(Rigidbody2D RB)
    {
        yield return new WaitForSeconds(knockTime);
        RB.velocity = Vector2.zero;
        RB.GetComponent<Enemy>().currentState = EnemyState.stagger;
        
        RB.velocity = Vector2.zero;
    
    }



}
