using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject SpawnObject;
    public GameObject RefObject;
    private GameObject SpawnPoint;
    private MonsterTraits monTraits;
    private battleManage batManage;


    //int counter = 0;

  

    // Update is called once per frame
    public void summonToField(GameObject ObjectToCopy) {
        // if (counter == 0)
        // {
        

        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Enable rendering:
       
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
        
        this.SpawnObject = ObjectToCopy;
            SpawnPoint = GameObject.Find("Spawn");   // add a function that allocates spawn location

            GameObject tempGameObject;

            
            tempGameObject = Instantiate(this.SpawnObject, this.SpawnPoint.transform.position, this.SpawnPoint.transform.rotation) as GameObject;
            tempGameObject.transform.parent = this.transform;

        // Only for Blue Eyes (future work is to have an external script to call from that will store values)
        tempGameObject.transform.localScale = new Vector3(0.01F, 0.01F, 0.01F);

        GameObject Kuribo_temp = GameObject.Find("DE_temp");  // Uses temp Kuribo as GameObject, must remove as soon as possible

        //Debug.Log("KU_temp: ", Kuribo_temp);
        //Debug.Log("BWED_temp: ", tempGameObject);
        //Debug.Log("BWED_real: ", ObjectToCopy);

        batManage = GetComponent("battleManage") as battleManage;
        batManage.battlePhase(tempGameObject, Kuribo_temp);


        

        //counter++;
        //}

        /*
        MonsterTraits monTraits = tempGameObject.GetComponent("MonsterTraits") as MonsterTraits;
        Debug.Log("ATK: " + monTraits.atk);

        Debug.Log("GO: " + tempGameObject);
        Debug.Log("GO Parent: " + tempGameObject.transform.parent.name);
        */
        //Debug.Log("Ref_pos:" + RefObject.transform.position);
    }
}