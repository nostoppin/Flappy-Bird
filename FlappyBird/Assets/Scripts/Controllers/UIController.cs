using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlappyBird.Controller;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FlappyBird.Controller
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] string complimentTextOne;
        [SerializeField] string complimentTextTwo;
        [SerializeField] string complimentTextThree;
        [SerializeField] string defaultText;


        [SerializeField] TextMesh complimentText;
        [SerializeField] GameObject godText;
        [SerializeField] GameObject gameOverPanel;

        [SerializeField] ScoreController scoreController;
        [SerializeField] GameController gameController;

        private void Start()
        {
            defaultText = " ";
            complimentText.text = defaultText;

            complimentTextOne = "Good!";
            complimentTextTwo = "...Woah";
            complimentTextThree = "himadri approves";
        }

        public void InitComplimentText()
        {
            if (scoreController.currentScore == 100 )
            {
                complimentText.text = complimentTextOne;
                Debug.Log("Here");
            }
            if (scoreController.currentScore == 300)
            {
                complimentText.text = complimentTextTwo;
            }
            if (scoreController.currentScore == 600)
            {
                complimentText.text = complimentTextThree;
            }
            if (scoreController.currentScore == 1000)
            {
                godText.SetActive(true);
            }
            Invoke("DefaultComplimentToNull", 1.5f);
        }

        void DefaultComplimentToNull()
        {
            complimentText.text = defaultText;
        }

        public void InitGameOver()
        {
            gameController.keepSpawnObstacles = false;
            Invoke("DeactivateAllObstacles",1.5f);

            gameOverPanel.SetActive(true);
        }

        void DeactivateAllObstacles()
        {
            gameController.DeactivateAllObstacles();
        }

        // BUTTONS
        public void RestartGame()
        {
            SceneManager.LoadScene(1); //gameScene
        }
    }
}