using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform ball;    
    public float speed = 6f;   
    public float reactionDelay = 0.1f;  

    private float targetY;

    void Update()
    {
        if (ball == null) return;

        
        targetY = Mathf.Lerp(targetY, ball.position.y, reactionDelay);

        Vector2 targetPosition = new Vector2(transform.position.x, targetY);

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );
    }
}