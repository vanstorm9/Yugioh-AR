/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    

    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES
        private GameObject field = GameObject.Find("FieldTarget");
        public GameObject main_model;
        private GameObject master = GameObject.Find("MasterObject");
        private int counter = 0;
        
        public SpawnScript summon;
        public MasterControl master_cont;


        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            field = GameObject.Find("FieldTarget");
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            master = GameObject.Find("MasterObject");
            master_cont = master.GetComponent("MasterControl") as MasterControl;
            //Debug.Log("master: " + master);
            //Debug.Log("master_cont: " + master_cont);
            //Debug.Log("cont: " + master_cont.mode);
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);


            foreach (Renderer component in rendererComponents)
                {
                    // A print statement here prints out multiple times as long as card is in view

                    //Debug.Log(mTrackableBehaviour.TrackableName + " is on the field");
         
                    component.enabled = true;
                }

                // Enable colliders:
                foreach (Collider component in colliderComponents)
                {
                    component.enabled = true;
                }
            

      
            
            summon = field.GetComponent("SpawnScript") as SpawnScript;
            
            if (master_cont.mode == 0)
            {
                // If statementt to summon the model only once
                if (counter == 0)
                {
                    summon.summonToField(main_model);
                    counter++;
                }
                foreach (Renderer component in rendererComponents)
                {
                    // A print statement here prints out multiple times as long as card is in view

                    //Debug.Log(mTrackableBehaviour.TrackableName + " is on the field");

                    component.enabled = false;
                }

                // Enable colliders:
                foreach (Collider component in colliderComponents)
                {
                    component.enabled = false;
                }

            }
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        

        #endregion // PRIVATE_METHODS
    }
}
