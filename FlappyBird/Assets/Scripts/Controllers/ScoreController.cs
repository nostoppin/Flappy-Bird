using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FlappyBird.Controller;

namespace FlappyBird.Controller
{
    public class ScoreController : MonoBehaviour
    {
        #region ints
        public int currentScore;

        #endregion

        #region UI
        [SerializeField] Text osdScoreText;
        #endregion

        [SerializeField] UIController uiController;


        void Start()
        {
            currentScore = 0;
            osdScoreText.text = currentScore.ToString();
        }

        public void IncrementScore(int score)
        {
            currentScore += score;

            UpdateOSDScore();

            uiController.InitComplimentText();
        }

        void UpdateOSDScore()
        {
            osdScoreText.text = currentScore.ToString();
        }
    }
}