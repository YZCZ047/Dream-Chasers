using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadJumpState : PlayerHeadState
{
    public PlayerHeadJumpState(PlayerHead _playerHead, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerHead, _stateMachine, _animBoolName)
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
        if (playerHead.isDash)
        {
            stateMachine.ChangeStateHead(playerHead.dashStateHead);
            return;
        }

        if (xInputJump != 0 && !playerHead.isWall)
        {
            
            playerHead.SetVelocity(xInput * playerHead.moveSpeed * 0.8f, playerHead.rb.velocity.y);
        }


        if (playerHead.rb.velocity.y < 0)
        {
            stateMachine.ChangeStateHead(playerHead.airStateHead);
        }

        if (playerHead.IsLeftWallDetected() || playerHead.IsRightWallDetected())// ½øÈëWall
        {
            stateMachine.ChangeStateHead(playerHead.wallStateHead);
        }
        if (playerHead.IsGroundDetected() && stateTimer < 0)
        {
            stateMachine.ChangeStateHead(playerHead.groundStateHead);
        }
    }
}
