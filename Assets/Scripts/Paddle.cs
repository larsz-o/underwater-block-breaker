using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16;
    // cached references

    Ball ball;
    GameSession gameSession;
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameSession = FindObjectOfType<GameSession>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // creates a new 2D vector (which is attached to our paddle object)
        Vector2 paddlePos = new Vector2 (transform.position.x, transform.position.y);
        // set a limit on where the vector can move (avoid it from going off screen)
        // min value is 1 (the screen width divided by itself = 1, and the max is the screen width minus 1 since the paddle has a width as well)
        paddlePos.x = Mathf.Clamp(GetXPos(), screenWidthInUnits/screenWidthInUnits, screenWidthInUnits-1);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if(gameSession.IsAutoPlayEnabled())
        {
             //gets the position of the ball's x axis
            return ball.transform.position.x;
        } else {
             //gets the position of the mouse's x axis and divides it by the screen width, then converts that number into unity world units
            return Input.mousePosition.x/Screen.width * screenWidthInUnits;
        }
    }
}
