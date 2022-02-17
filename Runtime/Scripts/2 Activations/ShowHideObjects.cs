using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class ShowHideObjects : MonoBehaviour, IActivate
    {
        public GameObject[] ObjectsToShow;

        public void Activate()
        {
            foreach (GameObject child in ObjectsToShow)
            { child.SetActive(!child.activeInHierarchy); }
        }

        public void Deactivate()
        {
            foreach (GameObject child in ObjectsToShow)
            { child.SetActive(!child.activeInHierarchy); }
        }
    }
}