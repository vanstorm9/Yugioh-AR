using UnityEngine;
using System.Collections;

public class MasterControl : MonoBehaviour {

    public GameObject field;
    public int mode = 0;
    // Use this for initialization

    void OnGUI()
    {
        if (GUI.Button(new Rect(25, 25, 100, 30), "Mode 0"))
        {
            mode = 0;
        }
        else if (GUI.Button(new Rect(25, 50, 100, 30), "Mode 1")) {
            mode = 1;
        }
    }

    /*
    public void summonToField()
    {
        field = GameObject.Find("FieldTarget");
        Debug.Log("field: "+field);
        //GameObject.Find("FieldTarget").GetComponent(SpawnScript).summonToTracker();

    }
    */
}
