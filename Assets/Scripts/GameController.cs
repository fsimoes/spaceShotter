using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text gameOverText;
    public Button restartBt;
    public GameObject player;
    public float createDistance;
    

    private bool gameOver;
    private bool restart;

    private int score;

    private void Start()
    {
        score = 0;
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartBt.gameObject.SetActive(restart);
        UpdateScore();
       StartCoroutine(SpawnWaves());
    }

    public void restartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++)
            {
                int signChanger = Random.Range(0, 2) * 2 - 1;
                float x = (player.transform.position.x + createDistance) * signChanger;
                signChanger = Random.Range(0, 2) * 2 - 1;
                float y = (player.transform.position.y + createDistance) * signChanger;
                signChanger = Random.Range(0, 2) * 2 - 1;
                float z = (player.transform.position.z + createDistance) * signChanger;
                Vector3 spawnPosition = new Vector3(x,y,z);//targetPostion
                hazard.GetComponent<Mover>().targetPostion = player.transform.position;
                Instantiate(hazard, spawnPosition, hazard.transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restart = true;
                restartBt.gameObject.SetActive(restart);
            }
        }
       
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
