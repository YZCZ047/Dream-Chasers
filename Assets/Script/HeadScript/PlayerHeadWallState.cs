using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadWallState : PlayerHeadState
{
    public PlayerHeadWallState(PlayerHead _playerHead, PlayerStateMachine _stateMachine, string _animBoolName) : base(_playerHead, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 0.5f;// 碰撞最短晕眩时间
        Debug.Log(playerHead.isWall);
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            playerHead.isWall = false;
            if (playerHead.IsGroundDetected())// 在地上则恢复Idle
            {
                stateMachine.ChangeStateHead(playerHead.idleStateHead);
            }
        }
    }
}
