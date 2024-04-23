using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChasing: NPCStrategy, IMovable
{
    private Transform player;
    private bool canMove = true;
    public NPCChasing(GameObject target, Transform player) : base(target) 
    {
        this.player = player;
    }

    public override void Act()
    {
        Move();
    }
    public void Move()
    {
        if (canMove ==false) return;
        nPC.transform.position = Vector2.MoveTowards(nPC.transform.position, player.transform.position, 2f * Time.deltaTime);
    }
    public void EnableMove() => canMove = true;

    public void DisableMove() => canMove = false;
}
