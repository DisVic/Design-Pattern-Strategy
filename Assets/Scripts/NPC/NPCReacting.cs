using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCReacting : NPCStrategy
{
    public NPCReacting(GameObject target) : base(target) { }

    public override void Act()
    {
        Debug.Log("Oh no! PLAYER!");
    }
}
