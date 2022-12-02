using System;
using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class ActivateText : MonoBehaviour, IActivate
    {
        public static event Action<string> UpdateUIText;
        public static event Action<float> ShowUIText;


        public string Message = "Please change to a message you want to display";
        public float DurationInSeconds = 5f;
        private bool StartCountDown = false;

        public void Activate()
        {
            ShowUIText?.Invoke(DurationInSeconds);
            UpdateUIText?.Invoke(Message);
        }

        private void Update()
        {
            if (StartCountDown)
            {
                DurationInSeconds -= Time.deltaTime;
                if (DurationInSeconds < 0) { Destroy(gameObject); }
            }
        }

        public void Deactivate()
        {
            ShowUIText?.Invoke(0f);
            UpdateUIText?.Invoke("");
        }
    }
}