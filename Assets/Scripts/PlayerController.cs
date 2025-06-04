using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movimentacao
    public float speed = 10;
    public float jumpForce = 19;
    private float Move;

    // animação
    public Animator anim;
    public RuntimeAnimatorController animNormal;
    public RuntimeAnimatorController animNoRight;
    public RuntimeAnimatorController animNoLeft;
    public RuntimeAnimatorController animNoJump;
    private bool isFacingRight;

    // verificacao se player esta no chao
    public Transform groundCheck;
    public LayerMask groundLayer; 
    public LayerMask trampolineLayer;
    private bool isGrounded; 
    private bool inTrampoline;

    // permissoes de movimentacao
    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canJump = true;
    private bool locked = false;

    private Rigidbody2D player;
    public bool hasWon;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();

        // Reiniciar estado do player
        anim.runtimeAnimatorController = animNormal;
        isFacingRight = true;
        anim.SetBool("isDead", false);
        WakeUp();
        hasWon = false;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.9f, 1.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        inTrampoline = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.9f, 1.1f), CapsuleDirection2D.Horizontal, 0, trampolineLayer);

        if (!locked && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            Jump();
        }

        if (!isGrounded && !inTrampoline)
        {
            anim.SetBool("isJumping", true);
        }
        else 
        {
            anim.SetBool("isJumping", false);
        }
    }

    void FixedUpdate()
    {
        if(!locked)
        {
            Move = Input.GetAxisRaw("Horizontal");
            Walk();
            anim.SetBool("isWalking", player.velocity.x != 0);

            if (!isFacingRight && Move > 0)
            {
                if (canMoveRight){
                    FlipSprite();
                }
            }
            else if (isFacingRight && Move < 0)
            {
                if (canMoveLeft){
                    FlipSprite();
                }
            }
        }
    }

    public void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    // Função para travar o player quando ele encostar no trampolim
    public void Push(Vector2 direction, float bounceDuration)
    {
        locked = true;
        player.AddForce(direction, ForceMode2D.Impulse);
        CancelInvoke("Unlock");
        Invoke("Unlock", bounceDuration);
    }

    // Movimentação PC
    void Walk()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (!canMoveLeft)
        {
            // Verifica se o input no eixo X eh menor que zero (se anda pra esquerda)
            if (inputX < 0) 
            {
                inputX = 0;
            }
        }

        if (!canMoveRight)
        {
            // Verifica se o input no eixo X eh maior que zero (se anda pra direita)
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

    // Restricoes de movimento
    public void DisableMovement(string movement) 
    {
        switch (movement)
        {
            case "jump":
                canJump = false;
                Invoke("SetNoJumpAnimator", anim.GetCurrentAnimatorStateInfo(0).length);
                break;

            case "left":
                canMoveLeft = false;
                if (isFacingRight)
                {
                    Invoke("SetNoLeftAnimator", anim.GetCurrentAnimatorStateInfo(0).length);
                }
                else
                {
                    
                    Invoke("SetNoRightAnimator", anim.GetCurrentAnimatorStateInfo(0).length);
                }
                break;

            case "right":
                canMoveRight = false;
                if (isFacingRight)
                {
                    Invoke("SetNoRightAnimator", anim.GetCurrentAnimatorStateInfo(0).length);
                } 
                else
                {
                    Invoke("SetNoLeftAnimator", anim.GetCurrentAnimatorStateInfo(0).length);
                }
                break;
        }
    }

    public void RestoreAllMovement()
    {
        canJump = canMoveLeft = canMoveRight = true;
        anim.runtimeAnimatorController = animNormal;
    }

    // Morte
    public void Die()
    {
        anim.SetBool("isDead", true);
        player.Sleep();
        locked = true;
    }

    // Vencer
    public void Win()
    {
        hasWon = true;
        anim.SetTrigger("win");
        player.Sleep();
        locked = true;
    }

    // Susto
    public void Scare(string movement)
    {
        // trava o player no ar
        player.velocity = new Vector2(0, player.velocity.y);
        player.Sleep();
        locked = true;
        anim.SetTrigger("scare");
        // destrava o player
        Invoke("Unlock", anim.GetCurrentAnimatorStateInfo(0).length);
        Invoke("WakeUp", anim.GetCurrentAnimatorStateInfo(0).length + 0.2f);

        // troca o animator do player e desativa seu movimento
        DisableMovement(movement);
    }

    private void SetNoLeftAnimator()
    {
        anim.runtimeAnimatorController = animNoLeft;
    }

    private void SetNoRightAnimator()
    {
        anim.runtimeAnimatorController = animNoRight;
    }

    private void SetNoJumpAnimator()
    {
        anim.runtimeAnimatorController = animNoJump;
    }

    private void WakeUp()
    {
        player.WakeUp();
    }

    private void Unlock()
    {
        locked = false;
    }
}
