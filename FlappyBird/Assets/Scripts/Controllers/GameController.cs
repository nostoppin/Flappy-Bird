using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.Controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] WallController wallController;
        [SerializeField] PlayerController playerController;

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
        private float spawnIntervalTime;
        private float spawnElapsedTime;
        #endregion

        void Start()
        {
            wallCount = 5;
            obstacleArray = new GameObject[wallCount];

            InitObstacleArray();

            spawnIntervalTime = 3f;
            spawnStartTime = Time.time;
        }

        void Update()
        {
            SpawnObstacles();

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
                        float randomValue_Y = Random.Range(-5f, 5f);

                        obstacleArray[i].transform.position = new Vector2(9.5f, randomValue_Y);
                        obstacleArray[i].SetActive(true);

                        spawnElapsedTime = 0;
                        spawnStartTime = Time.time;

                        break;
                    }
                }
            }
        }
    }
}

