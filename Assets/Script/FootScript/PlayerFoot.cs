using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    public int facingDir = 1;
    public bool facingRight = true;

    public Rigidbody2D rb;
    public Animator anim;

    protected PlayerFoot playerFoot;


    // **���״̬**
    #region States
    // ״̬�������ڹ�����ҵĲ�ͬ״̬��Idle��Move�ȣ���
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerFootIdleState idleStateFoot { get; private set; }
    #endregion


    private void Awake()
    {
        // ��ʼ��״̬������������ҵ��ض�״̬��
        stateMachine = new PlayerStateMachine();
        idleStateFoot = new PlayerFootIdleState(this, stateMachine, "FootIdle");
    }
    void Start()
    {
        // ���ó�ʼ״̬ΪIdle��
        stateMachine.InitializeFoot(idleStateFoot);
    }


    void Update()
    {
        stateMachine.currentStateFoot.Update();
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
    public void SetForce(float _xForce, float _yForce)// �����������С����
    {
        rb.AddForce(new Vector2(_xForce, _yForce));
        FlipController(_xForce);

    }
    public void SetVelocity(float _xVelocity, float _yVelocity)// ��������ٶȴ�С����
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
}
