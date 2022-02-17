using System;
using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class ActivateText : MonoBehaviour, IActivate
    {
        public static event Action<string> UpdateUIText;
        public static event Action<float> EndUIText;


        public string Message = "Please change to a message you want to display";
        public float DurationInSeconds = 5f;
        public bool DestroyAfterShowing = true;

        public void Activate()
        {
            UpdateUIText?.Invoke(Message);
            EndUIText?.Invoke(DurationInSeconds);

            if (DestroyAfterShowing)
            { Invoke("Destroy", DurationInSeconds); }
        }

        void Destroy()
        { Destroy(gameObject); }

        public void Deactivate()
        { UpdateUIText?.Invoke(""); }
    }
}