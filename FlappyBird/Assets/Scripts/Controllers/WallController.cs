using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlappyBird.Model;

namespace FlappyBird.Controller
{
    public class WallController : MonoBehaviour
    {
        public int wallPassCount;
        public int timeComplexityvalue;

        public bool spawnComplexityBool;
        
        [SerializeField] ComplexityController complexityController;
        
        WallModel wallModel;

        public float currentObstacleSpeed;

        void Start()
        {
            spawnComplexityBool = false;
            wallPassCount = 0;

            wallModel = new WallModel();
            wallModel.wallMoveSpeed = currentObstacleSpeed;

            //ResetWallPasses();
        }

        public void ResetWallPasses()
        {
            wallPassCount = 0;
        }

        public void CallComplexityController()
        {
            complexityController.IncreaseComplexity();
        }
    }
}