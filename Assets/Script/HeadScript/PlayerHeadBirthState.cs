using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadBirthState : PlayerHeadState
{
    public PlayerHeadBirthState(PlayerHead _playerHead, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerHead, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("to Idle");
    }

    public override void Update()
    {
        base.Update();
        stateMachine.ChangeStateHead(playerHead.idleStateHead);
    }
}
