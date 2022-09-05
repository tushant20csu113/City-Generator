using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSetter : MonoBehaviour
{
    public int scoreToReach;

    private int playerScore;
    private int enemyScore;

    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI enemyScoreText;
  
    //Singleton
    public static ScoreSetter Instance { get; private set; }
    private void Start()
    {
        Instance = this;
    }
    public void IncreasePlayerScore()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
        CheckScore();
    }
    public void IncreaseEnemyScore()
    {
        enemyScore++;
        enemyScoreText.text = enemyScore.ToString();
        CheckScore();
    }
    private void CheckScore()
    {
        if(playerScore==scoreToReach||enemyScore==scoreToReach)
        {

        }
    }
}
