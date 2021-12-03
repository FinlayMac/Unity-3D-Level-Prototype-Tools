using UnityEngine;
using System.Collections.Generic;
public class PressurePlate : MonoBehaviour
{
    public GameObject[] ActivatedObjects;

    private List<IActivate> objectsToActivate = new List<IActivate>();
    private void Awake()
    {
        foreach (GameObject child in ActivatedObjects)
        { objectsToActivate.Add(child.GetComponent<IActivate>()); }
    }

    private void OnCollisionEnter(Collision other)
    {
        foreach (IActivate child in objectsToActivate)
        { child.Activate(); }
    }

    private void OnCollisionExit(Collision other)
    {
        foreach (IActivate child in objectsToActivate)
        { child.Deactivate(); }
    }
}
