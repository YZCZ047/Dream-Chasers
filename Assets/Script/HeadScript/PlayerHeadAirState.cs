using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadAirState : PlayerHeadState
{
    public PlayerHeadAirState(PlayerHead _playerHead, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerHead, _stateMachine, _animBoolName)
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
        if (playerHead.isDash)
        {
            stateMachine.ChangeStateHead(playerHead.dashStateHead);
            return;
        }

        if (xInputJump != 0 && !playerHead.isWall)
        {
            playerHead.SetVelocity(playerHead.xInput * playerHead.moveSpeed * 0.8f, playerHead.rb.velocity.y);
        }


        if (playerHead.IsGroundDetected())
        {
            stateMachine.ChangeStateHead(playerHead.groundStateHead);
        }

        if (playerHead.IsLeftWallDetected() || playerHead.IsRightWallDetected())// Ω¯»ÎWall
        {
            stateMachine.ChangeStateHead(playerHead.wallStateHead);
        }
    }
}
