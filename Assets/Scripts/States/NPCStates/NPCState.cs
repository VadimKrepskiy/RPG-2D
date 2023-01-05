using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCState : State
{
    protected NPC _npc;
    public NPCState(NPC npc)
    {
        _npc = npc;
    }
}
