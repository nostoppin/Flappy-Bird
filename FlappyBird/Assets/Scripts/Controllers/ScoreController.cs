using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    #region ints
    public int currentScore;
    
    #endregion

    #region UI

    [SerializeField] Text osdScoreText;
    
    #endregion


    void Start()
    {
        currentScore = 0; 
        osdScoreText.text = currentScore.ToString();
    }

    public void IncrementScore(int score)
    {
        currentScore += score;

        UpdateOSDScore();
    }

    void UpdateOSDScore()
    {
        osdScoreText.text = currentScore.ToString();
    }
}
