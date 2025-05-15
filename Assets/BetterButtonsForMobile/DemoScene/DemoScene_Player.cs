using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoScene_Player : MonoBehaviour
{
    [SerializeField] private Text moveSpeedText;

    private float speed = 3f;

    private void Update()
    {
        moveSpeedText.text = "Move Speed: " + speed;
    }

    public void IncreaseMoveSpeed(int amount)
    {
        speed += amount;
    }

    public void MoveLeft()
    {
        Vector3 xPos = Vector3.left;
        transform.position += xPos * speed * Time.deltaTime;
    }

    public void MoveRight()
    {
        Vector3 xPos = Vector3.right;
        transform.position += xPos * speed * Time.deltaTime;
    }
}
