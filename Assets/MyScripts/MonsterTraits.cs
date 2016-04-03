using UnityEngine;
using System.Collections;

public class MonsterTraits : MonoBehaviour {
    public class MonsTraits
    {
        public int cslot;
        public string name;
        public int atk;
        public int def;

        public void editMonsTraits(int cslotf, int atkf, int deff)
        {
            cslot = cslotf;
            atk = atkf;
            def = deff;
        }
    }

}
