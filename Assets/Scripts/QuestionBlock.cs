using Managers;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public string question;
    public float correctAnswer;

    private void Start()
    {
        SetupQuestion();
    }

    private void SetupQuestion()
    {
        GameManager.Instance.currentCorrectAnswer = correctAnswer;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.OpenPromptBox("Question",question,0.5f,false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.ClosePromptBox(0.5f,false);
        }
    }
}
