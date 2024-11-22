using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;

    protected PlayerHead playerHead;


    // **玩家状态**
    #region States
    // 状态机，用于管理玩家的不同状态（Idle、Move等）。
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerHeadIdleState idleStateHead { get; private set; }
    #endregion


    private void Awake()
    {
        // 初始化状态机，并定义玩家的特定状态。
        stateMachine = new PlayerStateMachine();
        idleStateHead = new PlayerHeadIdleState(this, stateMachine, "HeadIdle");
    }
    void Start()
    {
        // 设置初始状态为Idle。
        stateMachine.InitializeHead(idleStateHead);
    }

    
    void Update()
    {
        stateMachine.currentStateHead.Update();
    }
    public void ZeroVelocity() => rb.velocity = new Vector2(0, 0);
    public void SetForce(float _xForce, float _yForce)// 定义给予力大小函数
    {
        rb.AddForce(new Vector2(_xForce, _yForce));

    }
    public void SetVelocity(float _xVelocity, float _yVelocity)// 定义给予速度大小函数
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }
}
