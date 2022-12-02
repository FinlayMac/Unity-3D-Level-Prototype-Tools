using UnityEngine;
using TMPro;

namespace Finlay._3dToolsForLevelDesign
{
    public class UpdateUIText : MonoBehaviour
    {

        private TextMeshProUGUI playerUIText;
        private Animator animator;

        private bool MessageRunning = false;
        public float Messagelength = 0;
        private int newMessageTrigger;
        private int closeMessageTrigger;

        private void Awake()
        {
            playerUIText = GetComponentInChildren<TextMeshProUGUI>();
            animator = GetComponent<Animator>();

            newMessageTrigger = Animator.StringToHash("NewMessage");
            closeMessageTrigger = Animator.StringToHash("CloseMessage");
        }


        private void OnEnable()
        {
            ActivateText.UpdateUIText += UpdateText;
            ActivateText.ShowUIText += ShowForTime;
        }

        private void OnDisable()
        {
            ActivateText.UpdateUIText -= UpdateText;
            ActivateText.ShowUIText -= ShowForTime;
        }


        void UpdateText(string message) { playerUIText.text = message; }

        void ShowForTime(float durationOfMessage)
        {
            if (durationOfMessage > 0)
            {
                animator.SetTrigger(newMessageTrigger);
                MessageRunning = true;
            }
            else
            {
                animator.SetTrigger(closeMessageTrigger);
                MessageRunning = false;
            }

            Messagelength = durationOfMessage;
        }

        private void Update()
        {
            if (MessageRunning)
            {
                Messagelength -= Time.deltaTime;
                if (Messagelength <= 0)
                {
                    animator.SetTrigger(closeMessageTrigger);
                    MessageRunning = false;
                }
            }
        }
    }

}