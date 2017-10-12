using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    AudioSource explosionSound;
    public int scoreValue;
    private GameController gameController;


    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        explosionSound = GetComponent<AudioSource>();
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            other.gameObject.SetActive(false);
        }
        gameController.AddScore(scoreValue);
        Instantiate(explosion, transform.position, transform.rotation);
      
        if (explosionSound)
        {
            explosionSound.Play();
        }
        Destroy(gameObject);
    }
}
