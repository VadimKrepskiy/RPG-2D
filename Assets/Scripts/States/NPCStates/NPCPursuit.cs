using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class NPCPursuitState : NPCState
{
    public NPCPursuitState(NPC npc) : base(npc)
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
        float distance = Vector3.Distance(_npc.PlayerObject.transform.position, _npc.transform.position);
        if (distance < 1f)
        {
            _npc.animator.SetBool("OnMove", false);
            _npc.Attack(_npc.player);
            _npc.Move(Vector3.zero);
        }
        else
        {
            _npc.animator.SetBool("OnMove", true);
            _npc.Move(_npc.PlayerObject.transform.position - _npc.transform.position);
        }
        if (distance > 4f)
            _npc.SwitchState<NPCPatrollingState>();
    }

    public override void Update()
    {
        
    }
}
