using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class GameSession : MonoBehaviour
{
    //config params
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    // state
    int currentScore = 0;
    void Awake(){
        //check to see if we already have the gameStatus object in the game. We want to persist our score data, so if there already is one, 
        // don't destroy the old one to avoid resetting the score to 0. 
        // else statement prevents the destruction of the object in the future

        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1 )
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore = currentScore + pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
    public void ResetScore()
    {
        Destroy(gameObject);
    }
}
