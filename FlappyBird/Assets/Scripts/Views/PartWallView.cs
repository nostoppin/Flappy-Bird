using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlappyBird.Controller;
using FlappyBird.View;

namespace FlappyBird.View
{
    public class PartWallView : MonoBehaviour
    {
        GameObject playerController;

        private void Start()
        {
            playerController = GameObject.Find("PlayerController");
        }

        //use only to check collision
        private void OnTriggerEnter2D(Collider2D thisCollider)
        {
            if (thisCollider.tag == "Player")
            {
                Debug.Log("OVER");
                //player loses
                playerController.GetComponent<PlayerController>().playHasControl = false;

                //game over scene
                playerController.GetComponent<PlayerController>().SwitchOffGameElements();
            }
        }
    }
}