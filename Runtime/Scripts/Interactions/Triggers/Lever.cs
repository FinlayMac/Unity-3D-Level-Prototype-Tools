using UnityEngine;
using System.Collections.Generic;

public class Lever : MonoBehaviour, IInteractable
{
    public GameObject[] ActivatedObjects;
    private List<IActivate> objectsToActivate = new List<IActivate>();
    public bool IsOn = false;

    private void Awake()
    {
        foreach (GameObject child in ActivatedObjects)
        { objectsToActivate.Add(child.GetComponent<IActivate>()); }
    }

    //When something interacts, toggles all states
    public void Interact()
    {
        IsOn = !IsOn;

        if (IsOn)
        {
            foreach (IActivate child in objectsToActivate)
            {
                child.Activate();
                Debug.Log("Activated");
            }
        }
        else
        {
            foreach (IActivate child in objectsToActivate)
            {
                child.Deactivate();
                Debug.Log("Stopped");
            }
        }

    }

}
