using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    // Create variables to hold player scores, initialize as 0
    int playerOneScore, playerTwoScore;
    [SerializeField]
    BallScript gameBall;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    AudioClip goalScored;
    [SerializeField]
    AudioClip endGame;
    AudioSource audSource;
    [SerializeField]
    GameObject endGameScreen;
    CameraShakeScript camShake;

    // Start is called before the first frame update
    void Start()
    {
        audSource = GetComponent<AudioSource>();
        camShake = GetComponent<CameraShakeScript>();
        StartNewGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // GoalScored function
    // Increases players score when goal is scored
    public void GoalScored(int playerNumber)
    {
        camShake.Shake();
        PlaySound(goalScored); // Play sound when goal is scored

        // Increase score of scoring player
        if (playerNumber == 1)
        {
            playerOneScore++;
            gameBall.Reset();
        }
        else if (playerNumber == 2)
        {
            playerTwoScore++;
            gameBall.Reset();
        }

        // Check for winning score
        if (playerOneScore == 3)
        {
            gameBall.Stop();
            GameOver(1);            
        }
        else if (playerTwoScore == 3)
        {
            gameBall.Stop();
            GameOver(2);
        }

        UpdateScoreText();
    }

    //GameOver function
    // Called when winning condition of 3 goals is met, resets the score
    void GameOver(int winner)
    {
        PlaySound(endGame); // Play sound when game is over
        gameBall.Stop();
        endGameScreen.SetActive(true);
    }

    //UpdateScoreText function
    // Updates the score header in game when goals are scored
    void UpdateScoreText()
    {
        scoreText.text = "Player One" + playerOneScore.ToString() + " - " + playerTwoScore.ToString() + " Player Two";
    }

    //PlaySound function
    // Plays audio clips
    void PlaySound(AudioClip soundClip)
    {
        audSource.clip = soundClip;
        audSource.Play();
    }

    //StartNewGame function
    // Resets the game state
    public void StartNewGame()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        UpdateScoreText();
        endGameScreen.SetActive(false);
        gameBall.Reset();
    }
}
