using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float health = 100f;
    public bool isPlayerAlive = true;
    public GameObject healthText;

    public GameManager gameManager;
 
   
    public void Hit(float damage)
    {
        health -= damage;
        
        healthText.GetComponent<Text>().text = health.ToString() + " HP";

        if (health <= 0)
        {
            isPlayerAlive=false;
            //SceneManager.LoadScene(0);//0 is the scene number
            gameManager.EndGame();
        }
    }
}
