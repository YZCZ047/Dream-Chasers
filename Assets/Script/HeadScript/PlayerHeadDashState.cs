using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadDashState : PlayerHeadState
{
    public PlayerHeadDashState(PlayerHead _playerHead, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerHead, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("in dash");
        stateTimer = playerHead.dashTime;
        playerHead.dashTimeCool = playerHead.dashTimeCD;
    }

    public override void Exit()
    {
        base.Exit();
        playerHead.isDash = false;
    }

    public override void Update()
    {
        base.Update();

        if (playerHead.IsLeftWallDetected() || playerHead.IsRightWallDetected())
        {
            stateMachine.ChangeStateHead(playerHead.wallStateHead);
        }

            if (stateTimer > 0)
        {
            if (xInput == 0)
            {
                playerHead.SetVelocity(playerHead.dashSpeed * playerHead.facingDir, 0);
            }
            else
            {
                playerHead.SetVelocity(playerHead.dashSpeed * playerHead.dashDir, 0);
            }
        }


        if (stateTimer < 0)
        {
            
            if (playerHead.IsGroundDetected())
            {
                stateMachine.ChangeStateHead(playerHead.moveStateHead);
            }
            else
            {
                stateMachine.ChangeStateHead(playerHead.airStateHead);
            }
        }
    }
}
