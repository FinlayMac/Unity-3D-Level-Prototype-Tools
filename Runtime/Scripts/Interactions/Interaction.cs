using UnityEngine;
using System;

namespace Finlay.FinlayTools
{
    public class Interaction : MonoBehaviour
    {

        //if you first need a key to interact, add a GO here.
        //the GO should have a collectObject script
        public GameObject RequiredKey;
        private bool KeyCollected = true;
        private string keyName;


        //if a key is required, the player must first collect it
        private void Awake()
        {
            if (RequiredKey)
            {
                KeyCollected = false;
                keyName = RequiredKey.name;
            }
        }




        //Updating the UI
        public static event Action<string> UpdateUIText;
        public static event Action<float> EndUIText;
        private string UseName;
        private string KeyName;


        //player walks into key area and collects key
        public void CollectedKey()
        {
            KeyCollected = true;
            UpdateUIText?.Invoke("You collected the " + keyName);
            EndUIText?.Invoke(5f);
        }


        //Player walks into interaction zone
        public void PlayerInUseZone()
        {

            if (KeyCollected)
            {
                //performs interactions
                CheckToShow();
                CheckToDestroy();
                UpdateUIText?.Invoke($"You interacted with the {UseLocation.gameObject.name}");
                EndUIText?.Invoke(5f);
            }
            else
            {
                UpdateUIText?.Invoke("You need to collect the " + keyName);
                EndUIText?.Invoke(5f);
            }
        }




        #region Show After Interaction


        //if you want to show an object after colliding, add a gameobject here
        //remember to set gameobject to inactive
        public GameObject ShowAfterInter;

        void CheckToShow()
        {
            if (ShowAfterInter)
            { ShowAfterInter.SetActive(true); }
        }
        #endregion


        #region Destroy After Interaction

        //if you want to remove an object when you enter the trigger, add a GO here
        public GameObject DestroyAfterInter;

        void CheckToDestroy()
        {
            //destroy after player collision
            if (DestroyAfterInter)
            { Destroy(DestroyAfterInter); }
        }
        #endregion


        #region Gizmos

        //Used for getting the location of the use area for gizmos
        private Transform UseLocation;
        private void Start()
        { UseLocation = GetComponentInChildren<UseObject>().gameObject.transform; }

        private void OnDrawGizmos()
        {
            if (UseLocation)
            {
                if (RequiredKey) { Gizmos.DrawLine(UseLocation.position, RequiredKey.transform.position); }

                if (DestroyAfterInter) { Gizmos.DrawLine(UseLocation.position, DestroyAfterInter.transform.position); }

                if (ShowAfterInter) { Gizmos.DrawLine(UseLocation.position, ShowAfterInter.transform.position); }
            }
        }
        #endregion

    }
}