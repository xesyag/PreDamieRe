using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Timeline;

public enum PlayerState
{
    walk, attack, interact, idle, stagger

}
public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    [SerializeField] private UIInventory uiInventory;
    
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    private Animator animator;
    [SerializeField] private Rigidbody2D myRigidbody;
    private Vector3 change;
    public PlayerState currentState;
    private Inventory inventory;
   
   

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);



    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack
            && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
       else if(currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }
        
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        currentState = PlayerState.walk;
    }
    void UpdateAnimationAndMove()
    {
        

        if (change != Vector3.zero)
        {
            
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
            
        }
        MoveCharacter();

    }

    void MoveCharacter()
    {
        //myRigidbody.MovePosition(transform.position + change * moveSpeed * Time.deltaTime);
        //myRigidbody.velocity = change * moveSpeed * Time.deltaTime * Rigbert;
        transform.position = Vector2.MoveTowards(transform.position, transform.position + change, moveSpeed * Time.deltaTime);
    }




}
    

      
    

   
  

