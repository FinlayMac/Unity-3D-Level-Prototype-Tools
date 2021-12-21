using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class KeyForLock : MonoBehaviour
    {
        public bool DestroyAfterPickUp = true;

        private KeyLockTrigger parent;

        private void Awake()
        { parent = GetComponentInParent<KeyLockTrigger>(); }


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {

                parent.CollectedKey();

                if (DestroyAfterPickUp)
                { Destroy(gameObject); }
            }
        }

    }
}