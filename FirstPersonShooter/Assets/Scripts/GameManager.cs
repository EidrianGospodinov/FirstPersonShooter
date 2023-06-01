using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int enemyAlive = 0;

    public int round = 0;
    public GameObject[] spawnPoints;

    public GameObject enemyPrefab;

    public Text RoundsSurvived;

    public Text OnPauseMenu;

    public GameObject EndScreen;

    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        if (enemyAlive == 0)
        {
            round++;
            NextWave();
        }
    }
    void NextWave()
    {
        for (var x = 0; x < round; x++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            //spawn enemy
            /*GameObject enemySpawned=*/
            Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            // enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            enemyAlive++;
        }
    }
    public void Pause()
    {
       
        
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            OnPauseMenu.text = "Pause";
            EndScreen.SetActive(true);
            RoundsSurvived.text = round.ToString();
        

    }
    public void Resume()
    {
        if(FindObjectOfType<PlayerManager>().isPlayerAlive)
        {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        EndScreen.SetActive(false);
        }
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        OnPauseMenu.text = "Game Over";
        EndScreen.SetActive(true);
        RoundsSurvived.text=round.ToString();
    }
}
