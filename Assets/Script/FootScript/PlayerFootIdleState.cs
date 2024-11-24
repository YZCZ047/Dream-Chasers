using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootIdleState : PlayerFootState
{
    public PlayerFootIdleState(PlayerFoot _playerFoot, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerFoot, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
