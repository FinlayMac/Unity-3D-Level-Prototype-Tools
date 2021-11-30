using UnityEngine;

namespace Finlay.FinlayTools
{
    public class CollectObject : MonoBehaviour
    {
        public bool DestroyAfterPickUp = true;

        private Interaction interaction;

        private void Awake()
        { interaction = GetComponentInParent<Interaction>(); }


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {

                interaction.CollectedKey();

                if (DestroyAfterPickUp)
                { Destroy(gameObject); }
            }
        }

    }
}