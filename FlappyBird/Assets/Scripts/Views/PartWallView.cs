using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.View
{
    public class PartWallView : MonoBehaviour
    {
        //use only to check collision
        private void OnTriggerEnter2D(Collider2D thisCollider)
        {
            if (thisCollider.tag == "Player")
            {
                print("boundary!");

                //player loses

                //game over scene
            }
        }
    }
}