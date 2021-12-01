using System.Collections;
using UnityEngine;

public class ObjectMoveBetweenPoints : MonoBehaviour
{
    //the list of nodes to create the path are stored under the parent
    public Transform pathParent;
    private Vector3[] waypoints;


    //For the moving object
    public GameObject PrefabObjectToMove;
    private GameObject instance;


    private int WaypointsIndex;

    public float MovementSpeed = 3f;
    //the amount of time the object stays still
    public float NodeWaitTime = 0.5f;


    //for finding the next location
    private float DistanceToTarget;

    private Vector3 targetWaypoint;

    void Awake()
    {
        pathParent = transform.GetChild(0);
        waypoints = new Vector3[pathParent.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        { waypoints[i] = pathParent.GetChild(i).position; }

        instance = Instantiate(PrefabObjectToMove, transform);

        StartCoroutine(FollowPath(waypoints));
    }


    public IEnumerator FollowPath(Vector3[] waypoints)
    {
        //starts at the first position when the coroutine starts
        instance.transform.position = waypoints[0];
        //sets the next target to the 2nd child
        WaypointsIndex = 1;
        targetWaypoint = waypoints[WaypointsIndex];

        while (true)
        {
            //move towards goal
            instance.transform.position = Vector3.MoveTowards(instance.transform.position, targetWaypoint, MovementSpeed * Time.deltaTime);

            //find how far away the target is
            DistanceToTarget = Vector3.Distance(targetWaypoint, instance.transform.position);

            //when its close, pick the next on the list. If at the end of the list, return 0
            if (DistanceToTarget < 0.5f)
            {
                Debug.Log("NEw Target");
                WaypointsIndex = (WaypointsIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[WaypointsIndex];
                yield return new WaitForSeconds(NodeWaitTime);
            }
            yield return null;
        }
    }

}
