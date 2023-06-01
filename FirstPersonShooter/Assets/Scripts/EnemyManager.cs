using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//important add Ai

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Animator enemyAnimator;
    float damage = 20;

    float zombieHealth = 100f;
    public GameManager gameManager;


    void Start()
    {
        gameManager =FindObjectOfType<GameManager>();
        //get the game object with tag player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //get to the destination of the player
        
       GetComponent<NavMeshAgent>().destination=player.transform.position;
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("Isrunning", true);
        }
        else
            enemyAnimator.SetBool("Isrunning", false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject==player)
        {
            player.GetComponent<PlayerManager>().Hit(damage);
        }
    }
    public void shotAt(int damage)
    {
        zombieHealth -= damage;
        if(zombieHealth <= 0)
        {
            /*enemyAnimator.SetBool("isDead", true);*/
            //destroy enemy
            
            //Invoke("destroyEnemy", 1);
            Destroy(gameObject);
            
            gameManager.enemyAlive--;

        }
    }
    void destroyEnemy()
    {
    }
}
