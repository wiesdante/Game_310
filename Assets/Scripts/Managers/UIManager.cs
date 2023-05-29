using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [Header("PromptBox Related")]
        public RectTransform promptBoxPanel;
        public TextMeshProUGUI promptTitle;
        public TextMeshProUGUI promptText;


        public void OpenPromptBox(string title, string text, float animationDelay)
        {
            promptTitle.text = title;
            promptText.text = text;
            promptBoxPanel.DOAnchorPosY(65,animationDelay,true);
        }

        public void ClosePromptBox(float animationDelay)
        {
            promptBoxPanel.DOAnchorPosY(-65,animationDelay,true);
        }
    }
}
