using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlappyBird.Controller;
using FlappyBird.Model;

namespace FlappyBird.Controller
{
    public class ComplexityController : MonoBehaviour
    {
        [SerializeField] WallController wallController;
        [SerializeField] GameController gameController;

        #region float
        
        float obstacleSpeedIncrementValue = 0.1f;
        float spawnTimeDecrementValue = 0.1f;
        #endregion

        private void Awake()
        {
            wallController.currentObstacleSpeed = 3f;
        }

        public void IncreaseComplexity()
        {
            wallController.currentObstacleSpeed += obstacleSpeedIncrementValue;

            if (wallController.spawnComplexityBool)
            {
                gameController.spawnIntervalTime -= spawnTimeDecrementValue;

                wallController.spawnComplexityBool = false;
            }
        }
    }
}