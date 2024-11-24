using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadIdleState : PlayerHeadState
{
    public PlayerHeadIdleState(PlayerHead _playerHead, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerHead, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 0.1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0 && stateTimer > -0.01f)
        {
            playerHead.ZeroVelocity();
        }

        if (xInput != 0)
        {
            stateMachine.ChangeStateHead(playerHead.moveStateHead);
        }
        if (playerHead.IsGroundDetected() && Input.GetKeyDown(KeyCode.W))// �ڵ��ϲ��Ұ��ո�
        {
            playerHead.SetForce(0, playerHead.jumpForce);// ������
            stateMachine.ChangeStateHead(playerHead.jumpStateHead);// ������Ծ״̬
        }
    }
}
