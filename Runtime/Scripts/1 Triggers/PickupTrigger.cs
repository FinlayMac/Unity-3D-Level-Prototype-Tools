using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class PickupTrigger : MonoBehaviour
    {

        public GameObject[] ActivatedObjects;
        private List<IActivate> objectsToActivate = new List<IActivate>();

        private void Awake()
        {
            foreach (GameObject child in ActivatedObjects)
            { objectsToActivate.Add(child.GetComponent<IActivate>()); }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                foreach (IActivate child in objectsToActivate)
                { child.Activate(); }

                Destroy(gameObject);
            }
        }
    }
}