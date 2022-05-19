using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FlappyBird.View
{
    public class PlayerView : MonoBehaviour
    {
        private float playerJumpVel;
        [SerializeField] Rigidbody2D playerRigidBody;


        private void Start()
        {
            playerRigidBody.Sleep();

            playerJumpVel = 4.5f;
        }
        public void MovePlayer()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (playerRigidBody.IsSleeping())
                {
                    playerRigidBody.WakeUp();
                }
                playerRigidBody.velocity = Vector2.up * playerJumpVel;
            }
        }
    }
}