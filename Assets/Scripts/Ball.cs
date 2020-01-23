using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    void Start()
    {
        //get the distance between the position of the ball object and the position of the paddle object
        paddleToBallVector = transform.position - paddle1.transform.position;
    }
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }
    private void LockBallToPaddle()
    {
        // as the paddle moves, get the position and 
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        // then change the position of the ball (by setting it to the sum of the distance between the ball and the paddle to the paddle position)
        transform.position = paddlePos + paddleToBallVector;
    }
    // Update is called once per frame
    void Update()
    {
        // only do these things if the game hasn't begun yet.
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        } 

    }
}
