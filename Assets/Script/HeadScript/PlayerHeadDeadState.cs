using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadDeadState : PlayerHeadState
{
    public PlayerHeadDeadState(PlayerHead _playerHead, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerHead, _stateMachine, _animBoolName)
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
