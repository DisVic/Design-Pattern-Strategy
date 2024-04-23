using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatroling : NPCStrategy
{

    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    public NPCPatroling(GameObject target, Transform[] patrolPoints, float moveSpeed, int patrolDestination) : base(target) 
    {
        this.patrolPoints = patrolPoints;
        this.moveSpeed = moveSpeed;
        this.patrolDestination = patrolDestination;
    }

    public override void Act()
    {
        if(patrolDestination == 0)
        {
            nPC.transform.position = Vector2.MoveTowards(nPC.transform.position, patrolPoints[0].position, moveSpeed);
            if(Vector2.Distance(nPC.transform.position, patrolPoints[0].position) < 0.2f)
            {
                nPC.transform.localScale = new Vector3(1, 1, 1);    
                patrolDestination = 1;
            }
            Debug.Log(0);
        }
        if (patrolDestination == 1)
        {
            nPC.transform.position = Vector2.MoveTowards(nPC.transform.position, patrolPoints[1].position, moveSpeed);
            if (Vector2.Distance(nPC.transform.position, patrolPoints[1].position) < 0.2f)
            {
                nPC.transform.localScale = new Vector3(-1, 1, 1);
                patrolDestination = 0;
            }
        }
    }
}
