using UnityEngine;
using System.Collections;

public class battleManage : MonoBehaviour {
    private GameObject Explosion;
    //private bool mShowGUIButton;
    //private Rect attackButton = new Rect(30, 30, 120, 40); // GUI

  
    // Use this for initialization
    public void battlePhase(GameObject attacker, GameObject defender)
    {
        //mShowGUIButton = true;
        Explosion = GameObject.Find("Explosion");
        
        // Entering battle phase (monster is preparing an attack)
        Explosion.SetActive(true);
       
       // Explode.PlayAnimation();

        MonsterTraits attacker_traits = attacker.GetComponent("MonsterTraits") as MonsterTraits;
        MonsterTraits defender_traits = defender.GetComponent("MonsterTraits") as MonsterTraits;
        Debug.Log(attacker_traits.real_name + " is now attacking " + defender_traits.real_name);

        // Assuming the defender is in attack mode
        if (attacker_traits.atk > defender_traits.atk)
        {
            // If attacker is stronger than defender
            Debug.Log(attacker_traits.real_name + " destroyed " + defender_traits.real_name + "!");
            Debug.Log("Opponent lost " + (attacker_traits.atk - defender_traits.atk) + "LP!");

            // Explosions
            int explosion_slot = defender_traits.cslot;
            
            
            Debug.Log("Explosion has occured");
            Destroy(defender);
            



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

            int explosion_slot = attacker_traits.cslot;
        }
        
        
        
    }



        /*
    void OnGUI()
        {
            //	GUI.Label(new Rect (Screen.width - (Screen.width * 0.9f) - 50.0f, Screen.height - Screen.height, 100.0f, 30.0f), "Player 1 Score: " + Player1LifePoints, MyGUIstyle);
            //	GUI.Label(new Rect (Screen.width - (Screen.width * 0.3f) - 50.0f, Screen.height - Screen.height, 100.0f, 30.0f), "Player 1 Score: " + Player2LifePoints, MyGUIstyle);

            if (mShowGUIButton)
            {
                // draw the GUI button
                if (GUI.Button(attackButton, "ATK/3000"))
                {
                    Debug.Log("Attack!");
                    Explode = GameObject.Find("Explode");
                    Explode.SetActive(true);    
                //StartCoroutine(StartWait());
                // do something on button click 
            }
             
            }
        }


    void Update()
    {

    }
    */

}
