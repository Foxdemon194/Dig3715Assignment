using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public float movementSpeed;
    public float startingJumpHeight;
    public float jumpHeight;
    public float gravityScale;
    private bool gameIsPaused;


    private Vector3 movementDirection;
    private bool groundedPlayer;

    public GameObject pauseMenu;



    void Start()
    {
        jumpHeight = startingJumpHeight;
        controller = GetComponent<CharacterController>();
        pauseMenu.SetActive(false);
        gameIsPaused = false;
    }

    void Update()
    {
        movementDirection = new Vector3(Input.GetAxis("Horizontal") * movementSpeed,
        movementDirection.y, Input.GetAxis("Vertical") * movementSpeed);

        if(Input.GetButtonDown("Cancel"))
        {
            PauseWasClicked();
        }

        if (controller.isGrounded)
        {
            movementDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                movementDirection.y = jumpHeight;
            }
        }
        movementDirection.y = movementDirection.y + (Physics.gravity.y * gravityScale);
        controller.Move(movementDirection * Time.deltaTime);
    }

    public void PauseWasClicked()
    {
        if (!gameIsPaused)
        {
            gameIsPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else if (gameIsPaused)
        {
            gameIsPaused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

}