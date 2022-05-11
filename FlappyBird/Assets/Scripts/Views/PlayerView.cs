using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.View
{
    public class PlayerView : MonoBehaviour
    {
        private float playerJumpVel;
        [SerializeField] Rigidbody2D playerRigidBody;

        private void Start()
        {
            playerJumpVel = 5.5f;
        }
        public void MovePlayer()
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerRigidBody.velocity = Vector2.up * playerJumpVel;
            }
        }
    }
}