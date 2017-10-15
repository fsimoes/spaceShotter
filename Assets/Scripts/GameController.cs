using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    //asteroids
    public GameObject hazard;
    //how many hazards per wave
    public int hazardCount;
    //time between hazards 
    public float spawnWait;
    //how long till wave start
    public float startWait;
    //time between waves
    public float waveWait;

    //score text object
    public Text scoreText;
    //game over text object
    public Text gameOverText;
    //restart button
    public Button restartBt;
    //player
    public GameObject player;
    //distance from player that the hazard will be created
    public float createDistance;

    //audio mixer
    public AudioMixer mixer;
    //snapshots
    public AudioMixerSnapshot[] spapshots;
    //snapshots weight
    float[] weight = new float[2];

    //is gameover
    private bool gameOver;
    // show restart button
    private bool restart;
    //current score
    private int score;

    private void Start()
    {
        //initialize variable
        score = 0;
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartBt.gameObject.SetActive(restart);
        UpdateScore();
        //start waves
        StartCoroutine(SpawnWaves());
        //initialize snapshot
        weight[0] = 1f;
        weight[1] = 0f;
        mixer.TransitionToSnapshots(spapshots, weight, 1);
    }

    public void restartGame()
    {
        //reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++)
            {
                //if game over do not create anymore item
                if (gameOver)
                {
                   break;
                }
               
                //set the spawn position to be in an area around the player
                Vector3 spawnPosition = player.transform.position +  Random.onUnitSphere * createDistance;
                //set the hazard direction to the player
                hazard.GetComponent<Mover>().targetPostion = player.transform.position;
                //create the hazard
                Instantiate(hazard, spawnPosition, hazard.transform.rotation);
                //wait to create a new one
                yield return new WaitForSeconds(spawnWait);
            }
            //wait for the next wave
            yield return new WaitForSeconds(waveWait);

            //if game over
            if (gameOver)
            {
                //show restart button
                restart = true;
                restartBt.gameObject.SetActive(restart);
            }
        }
       
    }

    public void AddScore(int newScoreValue)
    {
        //add score
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        //update the score text
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        //change the weight  of the snapshots
        weight[0] = 0f;
        weight[1] = 1f;
        //change the snapshot
        mixer.TransitionToSnapshots(spapshots, weight, 1);
        //show gameover text
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
