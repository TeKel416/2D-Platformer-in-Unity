using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movimenta��o
    public float speed = 10;
    public float jumpForce = 16;

    // animação
    public Animator anim;
    
    // verifica��o se player est� no ch�o
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    // permiss�es de movimenta��o
    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canJump = true;

    private Rigidbody2D player;

    private bool locked = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.8f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        // Pulo com espa�o ou setinha pra cima ou W
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Jump();   
        }
    }

    void FixedUpdate()
    {
        if(!locked)
        {
            Walk();
            anim.SetBool("isWalking", player.velocity.x != 0);
        }
    }

    public void Push(Vector2 direction, float bounceDuration)
    {
        locked = true;
        player.AddForce(direction, ForceMode2D.Impulse);
        CancelInvoke("Unlock");
        Invoke("Unlock", bounceDuration);
    }

    private void Unlock()
    {
        locked = false;
    }

    void Walk()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (!canMoveLeft)
        {
            // Verifica se o input no eixo X � menor que zero (se anda pra esquerda)
            if (inputX < 0) 
            {
                inputX = 0;
            }
        }

        if (!canMoveRight)
        {
            // Verifica se o input no eixo X � maior que zero (se anda pra direita)
            if (inputX > 0)
            {
                inputX = 0;
            }
        }

        player.velocity = new Vector2(speed * inputX, player.velocity.y);
    }

    public void MoveLeft()
    {
        if (canMoveLeft)
        {
            Vector3 xPos = Vector3.left;
            transform.position += xPos * speed * Time.deltaTime;
            anim.SetBool("isWalking", true);
        }
    }

    public void MoveRight()
    {
        if (canMoveRight)
        {
            Vector3 xPos = Vector3.right;
            transform.position += xPos * speed * Time.deltaTime;
            anim.SetBool("isWalking", true);
        }
    }

    public void Jump()
    {
        if (canJump && isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
        }
    }

    public void EnableMovement(string movement)
    {
        switch (movement) 
        {
            case "jump":
                canJump = true;
                break;

            case "left":
                canMoveLeft = true; 
                break;

            case "right":
                canMoveRight = true;
                break;
        }
    }

    public void DisableMovement(string movement) 
    {
        switch (movement)
        {
            case "jump":
                canJump = false;
                break;

            case "left":
                canMoveLeft = false;
                break;

            case "right":
                canMoveRight = false;
                break;
        }
    }

    public void RestoreAllMovement()
    {
        canJump = canMoveLeft = canMoveRight = true;
    }
}
