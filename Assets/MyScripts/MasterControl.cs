using UnityEngine;
using System.Collections;

public class MasterControl : MonoBehaviour {

    public GameObject field;
    public int mode = 0;
    public bool battlePhase = false;

    private battleManage batManage;

    GameObject attacker;
    GameObject defender;

    // Use this for initialization


    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 25, 100, 30), "Mode 0"))
        {
            mode = 0;
        }
        else if (GUI.Button(new Rect(10, 60, 100, 30), "Mode 1")) {
            mode = 1;
        }

        if (battlePhase)
        {
            if (GUI.Button(new Rect(Screen.width - 100, 25, 100, 30), "Attack"))
            {
                batManage.battlePhase(attacker, defender);
            }
        }
    }


    void Start()
    {
        battlePhase = false;
        batManage = GameObject.Find("FieldTarget").GetComponent("battleManage") as battleManage;
    }

    public void engageBattlePhase(GameObject attacker_i, GameObject defender_i)
    {
        attacker = attacker_i;
        defender = defender_i;

        battlePhase = true;
        Debug.Log("Battlephase is: " + battlePhase);
    }

    public void endBattlePhase()
    {
        attacker = null;
        defender = null;
    }
  
   
}
