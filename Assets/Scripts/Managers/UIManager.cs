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


        public void OpenPromptBox(string title, string text, float animationDelay)
        {
            promptTitle.text = title;
            promptText.text = text;
            promptBoxPanel.transform.DOMoveY(65, animationDelay, true);
        }

        public void ClosePromptBox(float animationDelay)
        {
            promptBoxPanel.transform.DOMoveY(-65, animationDelay, true);
        }
    }
}
