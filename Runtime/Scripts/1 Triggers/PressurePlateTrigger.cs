using UnityEngine;
using System.Collections.Generic;

namespace Finlay._3dToolsForLevelDesign
{
    public class PressurePlateTrigger : MonoBehaviour
    {
        public GameObject[] ActivatedObjects;
        private Animator anim;

        private List<IActivate> objectsToActivate = new List<IActivate>();
        private void Awake()
        {
            anim = GetComponent<Animator>();

            foreach (GameObject child in ActivatedObjects)
            { objectsToActivate.Add(child.GetComponent<IActivate>()); }
        }

        private void OnCollisionEnter(Collision other)
        {
            anim.SetTrigger("Down");

            foreach (IActivate child in objectsToActivate)
            { child.Activate(); }
        }

        private void OnCollisionExit(Collision other)
        {
            anim.SetTrigger("Up");

            foreach (IActivate child in objectsToActivate)
            { child.Deactivate(); }
        }
    }
}