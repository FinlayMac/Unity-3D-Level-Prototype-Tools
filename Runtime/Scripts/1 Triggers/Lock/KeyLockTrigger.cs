using System.Collections.Generic;
using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class KeyLockTrigger : MonoBehaviour
    {

        public bool HasKey = false;

        public GameObject[] ActivatedObjects;
        private List<IActivate> objectsToActivate = new List<IActivate>();

        private void Awake()
        {
            foreach (GameObject child in ActivatedObjects)
            { objectsToActivate.Add(child.GetComponent<IActivate>()); }
        }


        public void CollectedKey()
        { HasKey = true; }

        public void AttemptUnlock()
        {
            if (HasKey)
            {
                foreach (IActivate child in objectsToActivate)
                { child.Activate(); }

                //makes it single activation only
                HasKey = false;
            }
        }


    }
}