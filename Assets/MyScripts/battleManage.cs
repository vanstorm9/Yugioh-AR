using UnityEngine;
using System.Collections;

public class battleManage : MonoBehaviour {

    // Use this for initialization
    public void battlePhase(GameObject attacker, GameObject defender)
    {
        Debug.Log("Entering battle phase");
        
        MonsterTraits attacker_traits = attacker.GetComponent("MonsterTraits") as MonsterTraits;
        MonsterTraits defender_traits = defender.GetComponent("MonsterTraits") as MonsterTraits;
        Debug.Log(attacker_traits.real_name + " is now attacking " + defender_traits.real_name);

        // Assuming the defender is in attack mode
        if (attacker_traits.atk > defender_traits.atk)
        {
            // If attacker is stronger than defender
            Debug.Log(attacker_traits.real_name + " destroyed " + defender_traits.real_name + "!");
            Debug.Log("Opponent lost " + (attacker_traits.atk - defender_traits.atk) + "LP!");
        }
        else if (attacker_traits.atk == defender_traits.atk)
        {
            // If attacker and defender are equal
            Debug.Log(attacker_traits.real_name + " and " + defender_traits.real_name + "were both destoryed!");

        }
        else if (attacker_traits.atk < defender_traits.atk) {
            // If attacker is weaker than defender
            Debug.Log(attacker_traits.real_name + " was destroyed by " + defender_traits.real_name + "!");
            Debug.Log("You lost " + (defender_traits.atk - attacker_traits.atk) + "LP!");
        }
        
    }
	

}
