using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandState
{
    // 状态机引用，用于管理玩家的状态。
    protected PlayerStateMachine stateMachine;

    // 玩家对象的引用。
    protected PlayerHand playerHand;

    protected float stateTimer;

    protected float xInput;
    // 动画状态对应的Animator参数名称。
    private string animBoolName;

    // **构造函数**
    // 使用玩家对象、状态机和动画布尔参数名称初始化状态。
    public PlayerHandState(PlayerHand _playerHand, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.playerHand = _playerHand;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    // **进入状态**
    // 当状态被激活时调用，开启对应的动画。
    public virtual void Enter()
    {
        playerHand.anim.SetBool(animBoolName, true);
    }

    // **更新状态**
    // 玩家在该状态下每帧调用，用于处理持续的逻辑。
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");

    }
    // **退出状态**
    // 当状态结束时调用，关闭对应的动画。
    public virtual void Exit()
    {
        playerHand.anim.SetBool(animBoolName, false);

    }
}
