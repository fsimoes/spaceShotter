using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    
    //explosion object
    public GameObject explosion;
    //player explosion object
    public GameObject playerExplosion;
    //controll score
    public int scoreValue;
    //game controller instance
    private GameController gameController;


    private void Start()
    {
        //get the player controller
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        
        if (gameControllerObject != null)
        {  
            //get game controller script
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if collide with player
        if (other.tag == "Player")
        {
            //show player explosion
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //show game over
            gameController.GameOver();
            //disable player
            other.gameObject.SetActive(false);
        }
        //add the score
        gameController.AddScore(scoreValue);
        //show item explosion
        Instantiate(explosion, transform.position, transform.rotation);
       //destroy game object that colides
        Destroy(gameObject);
    }
}
