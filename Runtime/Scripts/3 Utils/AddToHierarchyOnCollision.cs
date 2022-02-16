using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class AddToHierarchyOnCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        { other.gameObject.transform.SetParent(transform); }

        private void OnCollisionExit(Collision other)
        { other.gameObject.transform.SetParent(null); }
    }
}