using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movimentação
    public float speed = 10;
    public float jumpForce = 16;

    // verificação se player está no chão
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    // permissões de movimentação
    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canJump = true;

    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.8f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (isGrounded) 
        {
            Jump(canJump);
        }
    }

    void FixedUpdate()
    {
        Walk(canMoveLeft, canMoveRight);
    }

    void Walk(bool canMoveLeft, bool canMoveRight)
    {
        float inputX = Input.GetAxis("Horizontal");

        if (!canMoveLeft)
        {
            // Verifica se o input no eixo X é menor que zero (se anda pra esquerda)
            if (inputX < 0) 
            {
                inputX = 0;
            }
        }

        if (!canMoveRight)
        {
            // Verifica se o input no eixo X é maior que zero (se anda pra direita)
            if (inputX > 0)
            {
                inputX = 0;
            }
        }

        player.velocity = new Vector2(speed * inputX, player.velocity.y);
    }

    void Jump(bool canJump)
    {
        if (canJump)
        {
            // Pulo com espaço ou setinha pra cima
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                player.velocity = new Vector2(player.velocity.x, jumpForce);
            }
        }
    }

    public void ChangeMovementPermission(string movement)
    {
        switch (movement) 
        {
            case "jump":
                canJump = !canJump;
                break;

            case "left":
                canMoveLeft = !canMoveLeft; 
                break;

            case "right":
                canMoveRight = !canMoveRight;
                break;
        }
    }
}
