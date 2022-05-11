using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlappyBird.Model;
using FlappyBird.Controller;

namespace FlappyBird.View
{
    public class WallView : MonoBehaviour
    {
        #region Ints
        public float wallSpeed;
        #endregion

        #region Controllers
        GameObject scoreController;
        GameObject wallController;
        #endregion

        void Start()
        {
            wallSpeed = 3f;
        }
        private void Update()
        {
            MoveThisWall();
        }

        void MoveThisWall()
        {
            this.transform.Translate(new Vector2(-1, 0) * wallSpeed * Time.deltaTime);
            CheckBounds();
        }

        void DeactivateSelf(bool value)
        {
            this.gameObject.SetActive(!value);
        }

        void CheckBounds()
        {
            if (this.transform.position.x <= -9.5f)
            {
                DeactivateSelf(true);

                wallController = GameObject.Find("WallController");
                wallController.GetComponent<WallController>().wallPassCount += 1;

                print(wallController.GetComponent<WallController>().wallPassCount);

                if (wallController.GetComponent<WallController>().wallPassCount >= 5)
                {
                    //increase complexity
                    //ComplexityModifier();

                    wallController.GetComponent<WallController>().ResetWallPasses();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                //print("SCORE!");

                scoreController = GameObject.Find("ScoreController");
                scoreController.GetComponent<ScoreController>().IncrementScore(10);
            }
        }

        // private void ComplexityModifier()
        // {
        //     wallSpeed += 5f;
        // }
    }
}