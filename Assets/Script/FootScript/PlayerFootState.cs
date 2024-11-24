using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootState
{
    // ״̬�����ã����ڹ�����ҵ�״̬��
    protected PlayerStateMachine stateMachine;

    // ��Ҷ�������á�
    protected PlayerFoot playerFoot;

    protected float stateTimer;

    protected float xInput;
    // ����״̬��Ӧ��Animator�������ơ�
    private string animBoolName;

    // **���캯��**
    // ʹ����Ҷ���״̬���Ͷ��������������Ƴ�ʼ��״̬��
    public PlayerFootState(PlayerFoot _playerFoot, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.playerFoot = _playerFoot;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    // **����״̬**
    // ��״̬������ʱ���ã�������Ӧ�Ķ�����
    public virtual void Enter()
    {
        playerFoot.anim.SetBool(animBoolName, true);
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
        playerFoot.anim.SetBool(animBoolName, false);

    }
}
