using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.Controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] WallController wallController;
        [SerializeField] PlayerController playerController;
        [SerializeField] UIController uIController;

        #region GameObjects
        [SerializeField] GameObject obstacleWall;

        [SerializeField] GameObject obstacleHolder;
        GameObject[] obstacleArray;
        #endregion

        #region Ints
        private int wallCount;
        #endregion

        #region Floats
        private float spawnStartTime;
        public float spawnIntervalTime;
        private float spawnElapsedTime;
        #endregion

        #region bools
        public bool keepSpawnObstacles;
        #endregion

        void Start()
        {
            wallCount = 5;
            obstacleArray = new GameObject[wallCount];

            InitObstacleArray();
            keepSpawnObstacles = true;

            spawnIntervalTime = 3f;
            spawnStartTime = Time.time;
        }

        void Update()
        {
            if (keepSpawnObstacles)
            {
                SpawnObstacles();
            }

            playerController.CheckInput();
        }

        private void InitObstacleArray()
        {
            for (int i = 0; i < obstacleArray.Length; i++)
            {
                obstacleArray[i] = Instantiate(obstacleWall, new Vector2(0, 0), Quaternion.identity, obstacleHolder.transform);
                obstacleArray[i].SetActive(false);
            }
        }



        private void SpawnObstacles()
        {
            spawnElapsedTime = Time.time - spawnStartTime;

            if (spawnElapsedTime >= spawnIntervalTime)
            {
                for (int i = 0; i < obstacleArray.Length; i++)
                {
                    if (!obstacleArray[i].activeInHierarchy)
                    {
                        float randomValue_Y = Random.Range(-3f, 2f);

                        obstacleArray[i].transform.position = new Vector2(9.5f, randomValue_Y);
                        obstacleArray[i].SetActive(true);

                        spawnElapsedTime = 0;
                        spawnStartTime = Time.time;

                        break;
                    }
                }
            }
        }

        public void DeactivateAllObstacles()
        {
            for (int i = 0; i < obstacleArray.Length; i++)
            {
                obstacleArray[i].SetActive(false);
            }

            Invoke("CallGameOverPanel", 1.5f);
        }

        public void CallGameOverPanel()
        {
            uIController.InitGameOver();
        }
    }
}

