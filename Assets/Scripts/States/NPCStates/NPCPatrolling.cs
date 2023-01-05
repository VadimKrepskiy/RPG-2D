using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrollingState : NPCState
{
    public NPCPatrollingState(NPC npc) : base(npc)
    {
    }

    public override void Enter()
    {
        _npc.animator.SetBool("OnMove", true);
    }

    public override void Exit()
    {
        _npc.animator.SetBool("OnMove", false);
    }

    public override void FixedUpdate()
    {
        if (Vector3.Distance(_npc.PlayerObject.transform.position, _npc.transform.position) <= 3f)
            _npc.SwitchState<NPCPursuitState>();
        if (Vector2.Distance(_npc.path[_npc.CurrentPoint], _npc.transform.position) < 0.2f)
        {
            _npc.SwitchPoint();
        }
        _npc.Move((Vector3)_npc.path[_npc.CurrentPoint] - _npc.transform.position);
    }

    public override void Update()
    {
        
    }
}
