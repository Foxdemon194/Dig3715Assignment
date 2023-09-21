using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public int coins;
    public int minimumCoins;

    public int tomatoes;
    public int minimumTomatoes;

    public Text scoreCoins;
    public Text scoreTomatoes;
    public Text GameOverText;

    public CharacterController characterController;
    public GameObject playerCapsule;

    //public GameObject gameOverText;

    public GameObject ObjGameOverUI;

    private bool alive;


    void Start()
    {
        ObjGameOverUI = GameObject.Find("CanvasGameOver");
        ObjGameOverUI.SetActive(false);

        playerCapsule = GameObject.Find("PlayerCapsule");
        playerCapsule.GetComponent<Collider>().enabled = true;

        characterController = playerCapsule.GetComponent<CharacterController>();
        characterController.enabled = true;

        alive = true;
    }

    void Update()
    {

        scoreCoins.text = "Coins: " + coins.ToString() + "/" + minimumCoins.ToString();
        scoreTomatoes.text = "Tomatoes: " + tomatoes.ToString() + "/" + minimumTomatoes.ToString();
        /*
        if(tomatoes == minimumTomatoes && coins == minimumCoins)
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0f;
        } 
        */
    }

    public void death()
    {
        alive = false;
        gameOver();
    }

    public void goal()
    {
        gameOver();
    }

    private void gameOver()
    {
        characterController.enabled = false;
        playerCapsule.GetComponent<Collider>().enabled = false;

        ObjGameOverUI.SetActive(true);

        if (alive == false)
        {
            GameOverText.text = "You Lost!";
        }
        else if (alive == true && coins >= minimumCoins && tomatoes >= minimumTomatoes)
        {
            GameOverText.text = "You collected Everything!";
        }
        else if (alive == true && coins >= minimumCoins)
        {
            GameOverText.text = "You collected all the coins!";
        }
        else if (alive == true && coins < minimumCoins)
        {
            GameOverText.text = "You reached the goal but you didn't get enough coins!";
        }
    }

}
