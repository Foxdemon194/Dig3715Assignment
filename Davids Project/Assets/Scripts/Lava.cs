using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private GameObject gameControl;

    //AI Stuff
    public GameObject upObject;
    public GameObject downObject;
    public float speed;
    [SerializeField] bool goingUp;

    private void Start()
    {
        gameControl = GameObject.Find("GameControl");
        goingUp = true;
    }

    private void Update()
    {
        if (goingUp)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, upObject.transform.position, speed * Time.deltaTime);
        }
        else if(!goingUp)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, downObject.transform.position, speed * Time.deltaTime);
        }


        if (this.transform.position.y >= upObject.transform.position.y)
        {
            goingUp = false;
        }

        if (this.transform.position.y <= downObject.transform.position.y)
        {
            goingUp = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var gameControlScript = gameControl.GetComponent<GameControl>();
            gameControlScript.death();
        }

    }
}
