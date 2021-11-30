using UnityEngine;
using System;

public class StoryBeat : MonoBehaviour
{
    public static event Action<string> UpdateUIText;
    public static event Action<float> EndUIText;


    public string Message = "Please change to a message you want to display";
    public float DurationInSeconds = 5f;
    public bool DestroyAfterShowing = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UpdateUIText?.Invoke(Message);
            EndUIText?.Invoke(DurationInSeconds);

            Invoke("ResetText", DurationInSeconds);
        }
    }

    void ResetText()
    {
        if (DestroyAfterShowing)
        { Destroy(gameObject); }
    }

}
