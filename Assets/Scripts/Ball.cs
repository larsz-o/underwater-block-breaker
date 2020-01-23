using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
 
    Vector2 paddleToBallVector;

    void Start()
    {
        //get the distance between the position of the ball object and the position of the paddle object
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // as the paddle moves, get the position and 
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        // then change the position of the ball (by setting it to the sum of the distance between the ball and the paddle to the paddle position)
        transform.position = paddlePos + paddleToBallVector;
    }
}
