using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadMoveState : PlayerHeadState
{
    public PlayerHeadMoveState(PlayerHead _playerHead, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerHead, _stateMachine, _animBoolName)
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

        playerHead.VelocityContral();

        playerHead.SetForce(xInput * playerHead.moveSpeed, 0);

        if (playerHead.IsGroundDetected() && Input.GetKeyDown(KeyCode.W))// 在地上并且按空格
        {
            playerHead.SetForce(0, playerHead.jumpForce);// 给予力
            stateMachine.ChangeStateHead(playerHead.jumpStateHead);// 进入跳跃状态
        }
        if (playerHead.rb.velocity.x < 6 && playerHead.rb.velocity.x > -6 && playerHead.IsGroundDetected() && xInput == 0)
        {
            stateMachine.ChangeStateHead(playerHead.idleStateHead);
        }


    }

}
