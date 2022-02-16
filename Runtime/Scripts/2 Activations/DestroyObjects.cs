using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class DestroyObjects : MonoBehaviour, IActivate
    {
        public GameObject[] ObjectsToDestroy;

        public void Activate()
        {
            foreach (GameObject child in ObjectsToDestroy)
            { Destroy(child); }
        }

        public void Deactivate()
        {

        }
    }
}