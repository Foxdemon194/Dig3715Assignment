using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    private GameObject playerControl;
    [SerializeField] float time = 0;
    [SerializeField] bool isPowerdUp;
    [SerializeField] float jumpBoostIncrement = 10;

    private void Start()
    {
        playerControl = GameObject.Find("PlayerCapsule");
        time = 0;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0 && isPowerdUp)
        {
            JumpBoostDeactivate();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            JumpBoostActivate();
        }
    }

    void JumpBoostActivate()
    {
        time = 6;
        playerControl.GetComponent<PlayerControl>().jumpHeight += jumpBoostIncrement;
        Collider myCollider = this.GetComponent<Collider>();
        myCollider.enabled = false;
        MeshRenderer myMesh = this.GetComponent<MeshRenderer>();
        myMesh.enabled = false;
    }

    void JumpBoostDeactivate()
    {
        isPowerdUp = false;
        playerControl.GetComponent<PlayerControl>().jumpHeight -= jumpBoostIncrement;

    }
}
