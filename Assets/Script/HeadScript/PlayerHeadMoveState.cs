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

        if (playerHead.IsGroundDetected() && Input.GetKeyDown(KeyCode.W))// �ڵ��ϲ��Ұ��ո�
        {
            playerHead.SetForce(0, playerHead.jumpForce);// ������
            stateMachine.ChangeStateHead(playerHead.jumpStateHead);// ������Ծ״̬
        }
        if (playerHead.rb.velocity.x < 6 && playerHead.rb.velocity.x > -6 && playerHead.IsGroundDetected() && xInput == 0)
        {
            stateMachine.ChangeStateHead(playerHead.idleStateHead);
        }


    }

}
