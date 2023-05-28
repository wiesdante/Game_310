using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [Header("PromptBox Related")]
        public GameObject promptBoxPanel;
        public TextMeshProUGUI promptTitle;
        public TextMeshProUGUI promptText;


        public void OpenPromptBox(string title, string text, float animationDelay, bool instant)
        {
            promptTitle.text = title;
            promptText.text = text;

            if (instant)
            {
                var position = promptBoxPanel.transform.position;
                position = new Vector3(position.x, 65,
                    position.z);
                promptBoxPanel.transform.position = position;
            }
            else
            {
                promptBoxPanel.transform.DOMoveY(65, animationDelay, true);
 
            }
        }

        public void ClosePromptBox(float animationDelay, bool instant)
        {
            if (instant)
            {
                var position = promptBoxPanel.transform.position;
                position = new Vector3(position.x, -65,
                    position.z);
                promptBoxPanel.transform.position = position;
            }
            else
            {
                promptBoxPanel.transform.DOMoveY(-65, animationDelay, true);
            }
        }
    }
}
