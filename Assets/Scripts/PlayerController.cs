using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 10;

    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.velocity = new Vector2(0, jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player.velocity = new Vector2(0, -jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.velocity = new Vector2(speed, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.velocity = new Vector2(-speed, 0);
        }
    }
}
