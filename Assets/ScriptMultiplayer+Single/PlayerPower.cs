using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    public bool isLeftPaddle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            BallMovement ball = collision.collider.GetComponent<BallMovement>();

            if (ball != null)
            {
                ball.lastHitLeft = isLeftPaddle;
            }
        }
    }
}
