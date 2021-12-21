using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class KeyLockTriggerGizmos : MonoBehaviour
    {
        public Transform Key;
        public Transform Lock;

        public KeyLockTrigger ActivatedObjectList;
        public Color HighlightColour = new Color(0.9f, 0.8f, 0.1f, 1f);

        private void OnDrawGizmos()
        {
            Gizmos.color = HighlightColour;

            if (Key && Lock) { Gizmos.DrawLine(Key.position, Lock.transform.position); }

            if (ActivatedObjectList)
            {
                if (ActivatedObjectList.ActivatedObjects.Length > 0)
                {
                    foreach (GameObject child in ActivatedObjectList.ActivatedObjects)
                    { Gizmos.DrawLine(Lock.position, child.transform.position); }
                }
            }

        }
    }

}
