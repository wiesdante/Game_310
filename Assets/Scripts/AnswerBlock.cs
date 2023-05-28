using Managers;
using UnityEngine;

public class AnswerBlock : MonoBehaviour
{
    public float answer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>();
            player.currentAnswer = answer;
            player.isOnAnswerBlock = true;
            
            UIManager.Instance.OpenPromptBox("Answer","If you think the correct answer is " + answer + ", press E.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>();
            player.isOnAnswerBlock = false;
            
            UIManager.Instance.ClosePromptBox();
        }
    }
}
