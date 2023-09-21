using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour
{
    private GameObject gameControl;

    void Start()
    {
        gameControl = GameObject.Find("GameControl");
    }

    void Update()
    {
        //additional line I decided to insert to make the coin rotate
        transform.Rotate(0, 70 * Time.deltaTime, 0);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerTouched();
        }
    }

    void playerTouched()
    {
        var gameControlScript = gameControl.GetComponent<GameControl>();
        gameControlScript.tomatoes = gameControlScript.tomatoes + 1;
        Destroy(gameObject);
    }

}
