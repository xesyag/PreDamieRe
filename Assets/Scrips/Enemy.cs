using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    interact,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int die;
    public float speed;
    public string enemyName;
    public int baseAttack;
    public Animator anim;
    public int damage = 5;
    public ItemDrop getItem;
    public GameObject coin;
    
   


    [SerializeField] public Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        getItem = GetComponent<ItemDrop>();
    }

   
    public void TakeDamage()
    {
        
        die -= damage;
        Debug.Log("damage TAKEN !");
        if (die <= 0)
        {
            Vector3 deathPos = this.gameObject.transform.position;
            
            /*if (getItem != null)
            {
                getItem.DropItem();
                Debug.Log("Dropped an Item " + getItem);
            }*/
            //Destroy(gameObject);
            this.gameObject.SetActive(false);
            GameObject prefabToSpawn = Instantiate(coin, deathPos, Quaternion.identity);                                           

        }
    }
    


}


