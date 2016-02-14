using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject SpawnObject;
    public GameObject RefObject;
    private GameObject SpawnPoint;
    int counter = 0;
    void Start()
    {
        SpawnPoint = GameObject.Find("Spawn");
        RefObject = GameObject.Find("Cube");
    }
	// Update is called once per frame
	void Update () {
        if (counter == 0)
        {
            GameObject tempGameObject;
            Debug.Log("Obj: " + SpawnObject);
            Debug.Log("Point: " + SpawnPoint);
            tempGameObject = Instantiate(this.SpawnObject, this.SpawnPoint.transform.position, this.SpawnPoint.transform.rotation) as GameObject;
            tempGameObject.transform.parent = this.transform;
            counter++;
        }
        Debug.Log("Pos: " + SpawnPoint.transform.position);
        Debug.Log("Ref_pos:" + RefObject.transform.position);
    }
}
