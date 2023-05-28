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


        public void OpenPromptBox(string title, string text)
        {
            promptTitle.text = title;
            promptText.text = text;
            promptBoxPanel.transform.DOMoveY(65, 0.5f, true);
        }

        public void ClosePromptBox()
        {
            promptBoxPanel.transform.DOMoveY(-65, 0.5f, true);
        }
    }
}
