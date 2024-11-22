using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator anim;

    protected PlayerHead playerHead;


    // **���״̬**
    #region States
    // ״̬�������ڹ�����ҵĲ�ͬ״̬��Idle��Move�ȣ���
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerHeadIdleState idleStateHead { get; private set; }
    #endregion


    private void Awake()
    {
        // ��ʼ��״̬������������ҵ��ض�״̬��
        stateMachine = new PlayerStateMachine();
        idleStateHead = new PlayerHeadIdleState(this, stateMachine, "HeadIdle");
    }
    void Start()
    {
        // ���ó�ʼ״̬ΪIdle��
        stateMachine.InitializeHead(idleStateHead);
    }

    
    void Update()
    {
        stateMachine.currentStateHead.Update();
    }
    public void ZeroVelocity() => rb.velocity = new Vector2(0, 0);
    public void SetForce(float _xForce, float _yForce)// �����������С����
    {
        rb.AddForce(new Vector2(_xForce, _yForce));

    }
    public void SetVelocity(float _xVelocity, float _yVelocity)// ��������ٶȴ�С����
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }
}
