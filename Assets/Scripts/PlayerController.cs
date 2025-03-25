using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;
    public float jumpForce = 8;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.velocity = new Vector2(player.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        player.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), player.velocity.y);
    }
}
