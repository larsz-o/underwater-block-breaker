using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // cached component resources
    AudioSource gameAudioSource;
    Rigidbody2D myRigidBody2D;
    void Start()
    {
        //get the distance between the position of the ball object and the position of the paddle object
        paddleToBallVector = transform.position - paddle1.transform.position;
        gameAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
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
       private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        if (hasStarted) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            gameAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }

    }
}
