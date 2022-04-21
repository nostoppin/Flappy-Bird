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
            }
        }
    }
}