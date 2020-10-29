using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed;
    private float gravityValue = -9.81f;
    [SerializeField] private float jumpHight;
    private bool dobleJumped;
    private Vector3 respawn;
    
    [SerializeField] private float pushPower = 2;
    
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        respawn = transform.position;
    }


    private void Update()
    {
        Movement();
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);

            GameManager.Manager._score++;
        }

        if (other.CompareTag("Dmg"))
        {
            Death();
            transform.position = respawn;
        }
    }


    private void Movement()
    {
        groundedPlayer = _controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        _controller.Move(move * Time.deltaTime * playerSpeed);


        /*if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        } */


        playerVelocity.y += gravityValue * Time.deltaTime;
        _controller.Move(playerVelocity * Time.deltaTime);
              

        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += jumpHight;
            dobleJumped = false;
            transform.parent = null;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer == false && dobleJumped == false)
        {
            playerVelocity.y = jumpHight;
            dobleJumped = true;
        }

        if (groundedPlayer)
        {
            dobleJumped = false;
        }

        
        
    }

    
    private void Death()
    {
        _controller.enabled = false;
        transform.position = respawn;
        GameManager.Manager._lives--;
        _controller.enabled = true;
        
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Wall"))
        {
            dobleJumped = false;
        }


        if (hit.gameObject.CompareTag("Cube"))
        {
            Rigidbody body = hit.collider.attachedRigidbody;

            Vector3 direction = new Vector3(hit.moveDirection.x, 0, 0);

            body.velocity = pushPower * direction;
        }

        
    }
}

