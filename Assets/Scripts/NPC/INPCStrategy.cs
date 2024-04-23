using UnityEngine;
public abstract class NPCStrategy
{
    protected GameObject nPC;
    public NPCStrategy(GameObject gameObject)
    {
      nPC = gameObject;
    }
    public abstract void Act();
}