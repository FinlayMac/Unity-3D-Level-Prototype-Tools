using UnityEngine;
using TMPro;

namespace Finlay._3dToolsForLevelDesign
{
    public class UpdateUIText : MonoBehaviour
    {

        private TextMeshProUGUI playerUIText;

        private void Awake()
        { playerUIText = GetComponent<TextMeshProUGUI>(); }


        private void OnEnable()
        {
            ActivateText.UpdateUIText += UpdateText;
            ActivateText.EndUIText += EndText;

            // Interaction.UpdateUIText += UpdateText;
            // Interaction.EndUIText += EndText;
        }

        private void OnDisable()
        {
            ActivateText.UpdateUIText -= UpdateText;
            ActivateText.EndUIText -= EndText;

            // Interaction.UpdateUIText -= UpdateText;
            // Interaction.EndUIText -= EndText;
        }


        void UpdateText(string message)
        { playerUIText.text = message; }

        void EndText(float durationOfMessage)
        { Invoke("EndTextNow", durationOfMessage); }

        void EndTextNow()
        { playerUIText.text = ""; }
    }

}