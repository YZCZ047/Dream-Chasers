using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public int facingDir = 1;
    public bool facingRight = true;

    public Rigidbody2D rb;
    public Animator anim;

    protected PlayerHand playerHand;


    // **玩家状态**
    #region States
    // 状态机，用于管理玩家的不同状态（Idle、Move等）。
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerHandIdleState idleStateHand { get; private set; }
    #endregion


    private void Awake()
    {
        // 初始化状态机，并定义玩家的特定状态。
        stateMachine = new PlayerStateMachine();
        idleStateHand = new PlayerHandIdleState(this, stateMachine, "HandIdle");
    }
    void Start()
    {
        // 设置初始状态为Idle。
        stateMachine.InitializeHand(idleStateHand);
    }


    void Update()
    {
        stateMachine.currentStateHand.Update();
    }

    #region Flip
    public void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float _x)
    {
        if (_x > 0.1f && !facingRight)
        {
            Flip();
        }
        else if (_x < -0.1f && facingRight)
        {
            Flip();
        }
    }
    #endregion

    public void ZeroVelocity() => rb.velocity = new Vector2(0, 0);
    public void SetForce(float _xForce, float _yForce)// 定义给予力大小函数
    {
        rb.AddForce(new Vector2(_xForce, _yForce));
        FlipController(_xForce);

    }
    public void SetVelocity(float _xVelocity, float _yVelocity)// 定义给予速度大小函数
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
}
