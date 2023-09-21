using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameObject gameControl;

    private void Start()
    {
        gameControl = GameObject.Find("GameControl");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var gameControlScript = gameControl.GetComponent<GameControl>();
            gameControlScript.goal();
        }
    }
}
