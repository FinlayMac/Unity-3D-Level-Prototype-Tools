using UnityEngine;

namespace Finlay._3dToolsForLevelDesign.Player
{
    public class PlayerInteract : MonoBehaviour
    {
        private bool InteractButtonPressed = false;

        public void Interact(bool input)
        { InteractButtonPressed = input; }

        private void OnTriggerStay(Collider other)
        {
            if (InteractButtonPressed)
            {
                if (other.gameObject.GetComponent<IInteractable>() != null)
                { other.gameObject.GetComponent<IInteractable>().Interact(); }

                InteractButtonPressed = false;
            }
        }


    }
}