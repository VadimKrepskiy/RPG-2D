using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player) : base(player)
    {
    }

    public override void Enter()
    {
        
    }
    public override void Exit()
    {
        
    }
    public override void FixedUpdate()
    {
        if (_player.OnMove)
            _player.SwitchState<PlayerMovingState>();
    }
    public override void Update()
    {
        
    }
}
