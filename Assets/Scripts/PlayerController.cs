using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 8;

    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jump();
    }

    void FixedUpdate()
    {
        walk();
    }

    void walk(bool left = true, bool right = true)
    {
        float inputX = Input.GetAxis("Horizontal");

        if (!left)
        {
            inputX = inputX > 0 ? inputX : 0;
        }

        if (!right)
        {
            inputX = inputX < 0 ? inputX : 0;
        }

        player.velocity = new Vector2(speed * inputX, player.velocity.y);
    }

    void jump(bool canJump = true)
    {
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.velocity = new Vector2(player.velocity.x, jumpForce);
            }
        }
    }
}
