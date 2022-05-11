using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird.Controller
{
    public class WallController : MonoBehaviour
    {
        public int wallPassCount;

        [SerializeField] ComplexityController complexityController;

        void Start()
        {
           ResetWallPasses();
        }

        public void ResetWallPasses()
        {
            wallPassCount = 0;
        }
    }
}