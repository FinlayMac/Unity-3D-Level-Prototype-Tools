using UnityEngine;

public class ActivateLight : MonoBehaviour, IActivate
{
    private Light light;

    private void Awake()
    { light = GetComponent<Light>(); }

    public void Activate()
    { light.enabled = true; }

    public void Deactivate()
    { light.enabled = false; }
}
