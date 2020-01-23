using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gets the position of the mouse's x axis and divides it by the screen width, then converts that number into unity world units
        float mousePosInUnits = Input.mousePosition.x/Screen.width * screenWidthInUnits;
        // creates a new 2D vector (which is attached to our paddle object)
        Vector2 paddlePos = new Vector2 (transform.position.x, transform.position.y);
        // set a limit on where the vector can move (avoid it from going off screen)
        // min value is 1 (the screen width divided by itself = 1, and the max is the screen width minus 1 since the paddle has a width as well)
        paddlePos.x = Mathf.Clamp(mousePosInUnits, screenWidthInUnits/screenWidthInUnits, screenWidthInUnits-1);
        transform.position = paddlePos;
    }
}
