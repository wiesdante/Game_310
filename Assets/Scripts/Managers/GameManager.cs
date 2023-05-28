using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Game Settings")]
        public int targetFrameRate = 60;

        [Header("Question Related")] 
        public float currentCorrectAnswer;

        private void Start()
        {
            Application.targetFrameRate = targetFrameRate;
        }

        public void AttemptToAnswer(float answer)
        {
            if (Math.Abs(answer - currentCorrectAnswer) < 0.01f)
            {
                UIManager.Instance.ClosePromptBox();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                UIManager.Instance.ClosePromptBox();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
