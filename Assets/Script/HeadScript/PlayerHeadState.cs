using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadState
{
    // ״̬�����ã����ڹ�����ҵ�״̬��
    protected PlayerStateMachine stateMachine;

    // ��Ҷ�������á�
    protected PlayerHead playerHead;

    protected float stateTimer;

    protected float xInput;
    // ����״̬��Ӧ��Animator�������ơ�
    private string animBoolName;

    // **���캯��**
    // ʹ����Ҷ���״̬���Ͷ��������������Ƴ�ʼ��״̬��
    public PlayerHeadState(PlayerHead _playerHead, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.playerHead = _playerHead;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    // **����״̬**
    // ��״̬������ʱ���ã�������Ӧ�Ķ�����
    public virtual void Enter()
    {
        playerHead.anim.SetBool(animBoolName, true);
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
        playerHead.anim.SetBool(animBoolName, false);

    }
}
