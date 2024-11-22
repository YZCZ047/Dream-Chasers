using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandIdleState : PlayerHandState
{
    public PlayerHandIdleState(PlayerHand _playerHand, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerHand, _stateMachine, _animBoolName)
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
