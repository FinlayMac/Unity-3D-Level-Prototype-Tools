using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Finlay._3dToolsForLevelDesign
{
    public class Teleport : MonoBehaviour
    {

        public Transform positionToTeleportTo;
        public Color DestinationColour = Color.green;
        private void OnTriggerEnter(Collider other)
        { other.gameObject.transform.position = positionToTeleportTo.position; }


        private void OnDrawGizmos()
        {
            if (positionToTeleportTo)
            {
                Gizmos.color = DestinationColour;
                Gizmos.DrawLine(transform.position, positionToTeleportTo.position);
                Gizmos.DrawWireCube(positionToTeleportTo.position, Vector3.one);
            }
        }
    }
}