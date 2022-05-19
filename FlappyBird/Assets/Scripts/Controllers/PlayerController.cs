using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlappyBird.View;

namespace FlappyBird.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] PlayerView playerView;
        [SerializeField] GameController gameController;

        //only modified by partWallView
        public bool playHasControl;

        void Start()
        {
            playHasControl = true;
        }
        public void CheckInput()
        {
            if(playHasControl)
            {
                PlayerMovement();
            }
            
        }

        private void PlayerMovement()
        {
            playerView.MovePlayer();
        }

        public void SwitchOffGameElements()
        {
            gameController.CallGameOverPanel();
        }
    }
}