using UnityEngine;
using System.Collections;

public class battleManage : MonoBehaviour {
    private GameObject Explosion;
    private GameObject attacker;
    private GameObject defender;
    private GameObject attacker_attack;


    void Start()
    {
        Explosion = GameObject.Find("Explosion");
        Explosion.SetActive(false);
    }

    // Allows us to time our explosion
    IEnumerator PlayExplosionIE(int delay_int)
    {
        //print(Time.time);

        attacker_attack = attacker.transform.FindChild("Attack").gameObject;
        // Delay at n seconds
        yield return new WaitForSeconds(delay_int);

        // Animation commands / settings
        attacker_attack.SetActive(false);
        Explosion.SetActive(true);
    }

    private void attackAnimations()
    {
        StartCoroutine(PlayExplosionIE(1));
        
    }

    // Use this for initialization
    public void battlePhase(GameObject attacker_i, GameObject defender_i)
    {
        // Turning our input GameObjects into our global variables
        attacker = attacker_i;
        defender = defender_i;

        //mShowGUIButton = true;
        // Entering battle phase (monster is preparing an attack)

        MonsterTraits attacker_traits = attacker.GetComponent("MonsterTraits") as MonsterTraits;
        MonsterTraits defender_traits = defender.GetComponent("MonsterTraits") as MonsterTraits;
        Debug.Log(attacker_traits.real_name + " is now attacking " + defender_traits.real_name);

        attackAnimations(); // Commence attack animations

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
