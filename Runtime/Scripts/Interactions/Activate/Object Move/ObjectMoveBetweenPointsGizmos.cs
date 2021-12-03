using UnityEngine;

[RequireComponent(typeof(ObjectMoveBetweenPoints))]
public class ObjectMoveBetweenPointsGizmos : MonoBehaviour
{

    private ObjectMoveBetweenPoints parent;
    private Vector3 startPosition, previousPosition, targetWaypoint;

    public Color lines = Color.white;
    public Color nodes = Color.red;
    public Color mesh = Color.yellow;


    void OnDrawGizmos()
    {
        if (parent == null) { parent = GetComponent<ObjectMoveBetweenPoints>(); }

        if (parent.pathParent)
        {
            startPosition = parent.pathParent.GetChild(0).position;
            previousPosition = startPosition;

            foreach (Transform waypoint in parent.pathParent)
            {
                Gizmos.color = nodes;
                Gizmos.DrawWireSphere(waypoint.position, .3f);
                Gizmos.color = lines;
                Gizmos.DrawLine(previousPosition, waypoint.position);
                previousPosition = waypoint.position;
            }
            Gizmos.DrawLine(previousPosition, startPosition);

            if (parent.PrefabObjectToMove)
            {
                Gizmos.color = mesh;
                Gizmos.DrawMesh(parent.PrefabObjectToMove.GetComponent<MeshFilter>().sharedMesh, startPosition);
            }
        }


    }
}
