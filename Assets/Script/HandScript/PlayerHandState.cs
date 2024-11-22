using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandState
{
    // ״̬�����ã����ڹ�����ҵ�״̬��
    protected PlayerStateMachine stateMachine;

    // ��Ҷ�������á�
    protected PlayerHand playerHand;

    protected float stateTimer;

    protected float xInput;
    // ����״̬��Ӧ��Animator�������ơ�
    private string animBoolName;

    // **���캯��**
    // ʹ����Ҷ���״̬���Ͷ��������������Ƴ�ʼ��״̬��
    public PlayerHandState(PlayerHand _playerHand, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.playerHand = _playerHand;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    // **����״̬**
    // ��״̬������ʱ���ã�������Ӧ�Ķ�����
    public virtual void Enter()
    {
        playerHand.anim.SetBool(animBoolName, true);
    }

    // **����״̬**
    // ����ڸ�״̬��ÿ֡���ã����ڴ���������߼���
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");

    }
    // **�˳�״̬**
    // ��״̬����ʱ���ã��رն�Ӧ�Ķ�����
    public virtual void Exit()
    {
        playerHand.anim.SetBool(animBoolName, false);

    }
}
