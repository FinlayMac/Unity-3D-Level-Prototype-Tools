using UnityEngine;

public class ShowHideObjects : MonoBehaviour, IActivate
{
    public GameObject[] ObjectsToShow;

    public void Activate()
    {
        foreach (GameObject child in ObjectsToShow)
        { child.SetActive(true); }
    }

    public void Deactivate()
    {
        foreach (GameObject child in ObjectsToShow)
        { child.SetActive(false); }
    }
}
