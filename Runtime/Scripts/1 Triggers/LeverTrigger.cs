using UnityEngine;
using System.Collections.Generic;

namespace Finlay._3dToolsForLevelDesign
{
    public class LeverTrigger : MonoBehaviour, IInteractable
    {
        public bool IsOn = false;
        public GameObject[] ActivatedObjects;
        private List<IActivate> objectsToActivate = new List<IActivate>();
        private Animator anim;


        private void Awake()
        {
            anim = GetComponent<Animator>();

            foreach (GameObject child in ActivatedObjects)
            { objectsToActivate.Add(child.GetComponent<IActivate>()); }
        }

        //When something interacts, toggles all states
        public void Interact()
        {
            IsOn = !IsOn;

            if (IsOn)
            {
                anim.SetTrigger("Open");

                foreach (IActivate child in objectsToActivate)
                {
                    child.Activate();
                    Debug.Log("Activated");
                }
            }
            else
            {
                anim.SetTrigger("Closed");

                foreach (IActivate child in objectsToActivate)
                {
                    child.Deactivate();
                    Debug.Log("Stopped");
                }
            }

        }

    }
}