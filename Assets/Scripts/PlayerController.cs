using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    // movimenta��o
    public float speed = 10;
    public float jumpForce = 19;

    // animação
    private Animator anim;
    
    // verifica��o se player est� no ch�o
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;

    // permiss�es de movimenta��o
    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canJump = true;
    private bool locked = false;

    private Rigidbody2D player;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isDead", false);
        WakeUp();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.8f, 0.4f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (!locked && (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow) || UnityEngine.Input.GetKeyDown(KeyCode.W) || UnityEngine.Input.GetKeyDown(KeyCode.Space)))
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

    // Função para travar o player quando ele encostar no trampolim
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

    // Movimentação PC
    void Walk()
    {
        float inputX = UnityEngine.Input.GetAxis("Horizontal");

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
    public void Jump()
    {
        if (canJump && isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
        }
    }

    // Movimentação Mobile
    // TODO: andar aplicando força no rigidbody do player
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

    // Restrições de movimento
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

    // Morte
    public void Die()
    {
        anim.SetBool("isDead", true);
        player.Sleep();
        locked = true;
    }

    // Susto
    public void Scare(string movement)
    {
        DisableMovement(movement);
        // trava o player no ar
        player.velocity = new Vector2(0, player.velocity.y);
        player.Sleep();
        locked = true;
        anim.SetTrigger("scare");
        // destrava o player
        Invoke("Unlock", anim.GetCurrentAnimatorStateInfo(0).length);
        Invoke("WakeUp", anim.GetCurrentAnimatorStateInfo(0).length + 0.2f);
    }

    private void WakeUp()
    {
        player.WakeUp();
    }
}
