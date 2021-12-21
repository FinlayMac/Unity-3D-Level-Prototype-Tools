using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class LockZone : MonoBehaviour
    {
        private KeyLockTrigger parent;

        private void Awake()
        { parent = GetComponentInParent<KeyLockTrigger>(); }

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                //send signal to interaction
                parent.AttemptUnlock();
            }
        }
    }
}