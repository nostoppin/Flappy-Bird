using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FlappyBird.Controller
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] Animator transitionAnim;
        [SerializeField] Animator rulesAnim;

        [SerializeField] Text ruletext;
        [SerializeField] Button ruleButton;

        int ruleClickCount;

        public float transitionAnimTime;

        void Start()
        {
            transitionAnimTime = 1.5f;
        }
        public void OnPlayButtonPress()
        {
            StopAllCoroutines();
            StartCoroutine(LoadGameLevel(1));
        }

        public void OnHomeButtonPress()
        {
            StopAllCoroutines();
            StartCoroutine(LoadGameLevel(0));
        }

        public void OnExitButtonPress()
        {
            Application.Quit();
        }

        public void onRuleButtonPress()
        {

            ruleButton.interactable = false;

            ruleClickCount++;

            if (ruleClickCount == 1)
            {
                ruletext.text = "...really dude?";
                Invoke("ReactivateRuleButton", 4f);
            }
            if (ruleClickCount == 2)
            {
                ruletext.text = "stop...";
                Invoke("ReactivateRuleButton", 4f);
            }
            if (ruleClickCount == 3)
            {
                ruletext.text = "NOOB alert";
                Invoke("ReactivateRuleButton", 4f);
            }
            if (ruleClickCount == 4)
            {
                ruletext.text = "rules.exe crashed...";
            }
            
            rulesAnim.SetTrigger("StartRules");
        }

        void ReactivateRuleButton()
        {
            ruleButton.interactable = true;
        }

        IEnumerator LoadGameLevel(int levelIndex)
        {
            //play anim
            transitionAnim.SetTrigger("Start");

            //stop anim
            yield return new WaitForSeconds(transitionAnimTime);

            //load scene
            SceneManager.LoadScene(levelIndex);
        }
    }
}