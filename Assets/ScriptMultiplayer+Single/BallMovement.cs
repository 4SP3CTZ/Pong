using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip paddleBounceSound;
    public AudioClip wallBounceSound;
    public AudioClip powerUpSound;
    public AudioClip goalSound;

    public bool lastHitLeft;
    public Rigidbody2D rb;
    public float speed = 8f;
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);
        LaunchBallLeftFirst();
    }

   
    public void ResetBall()
    {
        rb.velocity = Vector2.zero;            
        transform.position = startPos;         
    }

    public void LaunchBallLeftFirst()
    {
        ResetBall();  

        StartCoroutine(LaunchAfterReset());
    }

    IEnumerator LaunchAfterReset()
    {
        yield return new WaitForSeconds(0.1f);

        Vector2 direction = new Vector2(-1f, Random.Range(-0.5f, 0.5f)).normalized;
        rb.velocity = direction * speed;
    }

    public void LaunchBallRightFirst()
    {
        ResetBall();

        StartCoroutine(LaunchAfterResetRight());
    }

    IEnumerator LaunchAfterResetRight()
    {
        yield return new WaitForSeconds(0.1f);

        Vector2 direction = new Vector2(1f, Random.Range(-0.5f, 0.5f)).normalized;
        rb.velocity = direction * speed;
    }

    void ApplyPowerUp(PowerUpType type)
    {
        bool left = lastHitLeft;

        switch (type)
        {
            case PowerUpType.ChangeDirection:
                rb.velocity = -rb.velocity;
                break;

            case PowerUpType.DoublePoints:
                if (left)
                    GameManager.Instance.leftDoublePoint = true;
                else
                    GameManager.Instance.rightDoublePoint = true;
                break;

            case PowerUpType.SpeedUp:
                rb.velocity *= 5f;
                break;
    }
}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (audioSource != null && paddleBounceSound != null)
                audioSource.PlayOneShot(paddleBounceSound);
            
            if (GetComponent<AudioSource>() != null)
            GetComponent<AudioSource>().Play();
            
            float y = transform.position.y - collision.transform.position.y;

            float xDirection = collision.transform.position.x < 0 ? 1f : -1f;

            Vector2 newDir = new Vector2(xDirection, y).normalized;

            rb.velocity = newDir * speed;

            transform.position += new Vector3(newDir.x * 0.05f, 0, 0);
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            if (audioSource != null && wallBounceSound != null)
                audioSource.PlayOneShot(wallBounceSound);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftGoal"))
        {
            audioSource.PlayOneShot(goalSound);
            if (GameManager.Instance != null)
            GameManager.Instance.AddRightScore();

            LaunchBallLeftFirst();
        }

        if (collision.CompareTag("RightGoal"))
        {
            audioSource.PlayOneShot(goalSound);
            if (GameManager.Instance != null)
            GameManager.Instance.AddLeftScore();

            LaunchBallRightFirst();
        }
        if (collision.CompareTag("PowerUp"))
        {
            PowerUp p = collision.GetComponent<PowerUp>();
            audioSource.PlayOneShot(powerUpSound);

            if (p != null)
            ApplyPowerUp(p.type);

            Destroy(collision.gameObject);
        }
    }
}
