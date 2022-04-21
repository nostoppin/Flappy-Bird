using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.Controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] WallController wallController;

        #region GameObjects
        [SerializeField] GameObject obstacleWall;
        [SerializeField] GameObject bgImage;

        GameObject[] backGround;
        GameObject[] obstacleArray;
        #endregion

        #region Ints
        private int wallCount;
        private int bgImageCount;
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
            bgImageCount = 2;
            backGround = new GameObject[bgImageCount];

            InitObstacleArray();

            spawnIntervalTime = 5f;
            spawnStartTime = Time.time;
        }

        void Update()
        {
            SpawnObstacles();
        }

        private void InitObstacleArray()
        {
            for (int i = 0; i < obstacleArray.Length; i++)
            {
                obstacleArray[i] = Instantiate(obstacleWall, new Vector2(0, 0), Quaternion.identity);
                obstacleArray[i].SetActive(false);
            }
        }

        private void InitBgImages()
        {
            for (int i = 0; i < backGround.Length; i++)
            {
                backGround[i] = Instantiate(bgImage);
                backGround[i].SetActive(false);
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
                        Debug.Log("here");
                        obstacleArray[i].transform.position = new Vector2(9.5f, 0f);
                        obstacleArray[i].SetActive(true);

                        spawnElapsedTime = 0;
                        spawnStartTime = Time.time;

                        break;
                    }

                }

            }
        }

        private void MoveBackground()
        {
            for (int i = 0; i < backGround.Length; i++)
            {
                //backGround[i].transform
                backGround[i].SetActive(false);
            }
        }
    }
}

