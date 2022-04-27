using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlappyBird.View;

namespace FlappyBird.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] PlayerView playerView;
        public void CheckInput()
        {
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            playerView.MovePlayer();
        }
    }
}