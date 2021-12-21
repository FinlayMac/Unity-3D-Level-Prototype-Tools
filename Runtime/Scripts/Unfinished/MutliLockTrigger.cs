using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Finlay._3dToolsForLevelDesign
{
    public class MutliLockTrigger : MonoBehaviour
    {

        //TODO finish
        //how to get signals from triggered items
        //triggered item could send an event
        //events wont be unique
        
        public GameObject[] KeyObjects;
        private List<IActivate> ListOfTriggers = new List<IActivate>();



        private void Awake()
        {
            foreach (GameObject child in KeyObjects)
            { ListOfTriggers.Add(child.GetComponent<IActivate>()); }
        }


    }
}