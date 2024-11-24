using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadGroundState : PlayerHeadState
{
    public PlayerHeadGroundState(PlayerHead _playerHead, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerHead, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 0.2f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xInput != 0)
        {
            playerHead.SetVelocity(xInput * playerHead.moveSpeed * 0.8f, playerHead.rb.velocity.y);
        }

        if (playerHead.IsGroundDetected() && stateTimer < 0)
        {
            stateMachine.ChangeStateHead(playerHead.idleStateHead);
        }
        //if (playerHead.rb.velocity.y > 3f && stateTimer < 0.1f)
        //{
        //    stateMachine.ChangeStateHead(playerHead.jumpStateHead);
        //}
    }
}
