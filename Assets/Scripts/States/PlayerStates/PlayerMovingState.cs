using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerState
{
    public PlayerMovingState(Player player) : base(player)
    {
    }

    public override void Enter()
    {
        _player.animator.SetBool("OnMove", true);
    }

    public override void Exit()
    {
        _player.animator.SetBool("OnMove", false);
    }
    public override void FixedUpdate()
    {
        if (!_player.OnMove)
            _player.SwitchState<PlayerIdleState>();
        _player.Move();
    }
    public override void Update()
    {
        
    }
    
}
