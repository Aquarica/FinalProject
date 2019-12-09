using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float spawnWaitH;
    //NEW
    public float startWait;
    public float waveWait;

    public GameObject[] hazardsTwo;

    public Text ScoreText;
    public Text gameOverText;
    public Text restartText;
   

    public int score;
    private bool gameOver;
    private bool restart;

   //controls music, win and lose
    public AudioClip winMusic;
    public AudioClip loseMusic;
    public AudioSource musicSource;




    //public float moveSpeed;

    //NEW NEW CODE
    
    [SerializeField] private Text timerText;
    float currentTime = 0f;
    float startingTime = 0f;

    
    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "'N' For Normal Mode  'H' For Hard Mode";
       
        score = 0;
        currentTime = startingTime;
        UpdateScore();

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Q' to Restart";
                restart = true;
                break;
            }
        }
    }

    IEnumerator SpawnWavesHard()
    {
        

        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazardsTwo[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWaitH);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Q' to Restart";
                restart = true;
                break;
            }
        }
    }


    private void Update()
    {
        currentTime += 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("Time:"+"0.0");

        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(SpawnWaves());
            gameOverText.text = "";
            currentTime += 1 * Time.deltaTime;
            timerText.text = currentTime.ToString("Time:" + "0.0");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(SpawnWavesHard());
            gameOverText.text = "";

        }

       /* if (Input.GetKeyDown(KeyCode.M))
        {
 
            StartCoroutine(SpawnWavesTime());
            gameOverText.text = "";
        }

    */


        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.Q))
            {
                SceneManager.LoadScene("Final Project");
                // or whatever the name of your scene is
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            gameOverText.text = "You win! Game By: Erica";
            gameOver = true;
            restart = true;
            musicSource.clip = winMusic;
            musicSource.Play();           
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over! Game By: Erica";
        gameOver = true;
        musicSource.clip = loseMusic;
        musicSource.Play();
    }


}