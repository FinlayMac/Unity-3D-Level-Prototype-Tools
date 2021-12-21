using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class ZoneTrigger : MonoBehaviour
    {
        public bool OnlyActivate = false;
        public GameObject[] ActivatedObjects;
        private List<IActivate> objectsToActivate = new List<IActivate>();

        private void Awake()
        {
            foreach (GameObject child in ActivatedObjects)
            { objectsToActivate.Add(child.GetComponent<IActivate>()); }
        }

        private void OnTriggerEnter()
        {
            foreach (IActivate child in objectsToActivate)
            { child.Activate(); }
        }

        private void OnTriggerExit()
        {
            if (OnlyActivate == false)
            {
                foreach (IActivate child in objectsToActivate)
                { child.Deactivate(); }
            }
        }
    }
}