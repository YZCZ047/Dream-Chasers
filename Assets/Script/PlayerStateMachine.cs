using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    #region Head
    // ��ǰ״̬�����ã����ڴ洢�͹���ǰ״̬��
    public PlayerHeadState currentStateHead { get; private set; }

    // **��ʼ������**
    // ��ʼ��״̬��������ǰ״̬����Ϊָ���ĳ�ʼ״̬��
    public void InitializeHead(PlayerHeadState _startState)
    {
        currentStateHead = _startState;
        currentStateHead.Enter();
    }

    // **״̬�л�����**
    // ��״̬�����ı�ʱ���ã��˳���ǰ״̬�������µ�״̬��
    public void ChangeStateHead(PlayerHeadState _newState)
    {
        currentStateHead.Exit();
        currentStateHead = _newState;
        currentStateHead.Enter();
    }
    #endregion

    /// <summary>
    /// //////////////////////////////////////////////////////////////////
    /// </summary>

    #region Foot
    // ��ǰ״̬�����ã����ڴ洢�͹���ǰ״̬��
    public PlayerFootState currentStateFoot { get; private set; }

    // **��ʼ������**
    // ��ʼ��״̬��������ǰ״̬����Ϊָ���ĳ�ʼ״̬��
    public void InitializeFoot(PlayerFootState _startState)
    {
        currentStateFoot = _startState;
        currentStateFoot.Enter();
    }

    // **״̬�л�����**
    // ��״̬�����ı�ʱ���ã��˳���ǰ״̬�������µ�״̬��
    public void ChangeStateFoot(PlayerFootState _newState)
    {
        currentStateFoot.Exit();
        currentStateFoot = _newState;
        currentStateFoot.Enter();
    }
    #endregion

    /// <summary>
    /// //////////////////////////////////////////////////////////////////
    /// </summary>

    #region Hand
    // ��ǰ״̬�����ã����ڴ洢�͹���ǰ״̬��
    public PlayerHandState currentStateHand { get; private set; }

    // **��ʼ������**
    // ��ʼ��״̬��������ǰ״̬����Ϊָ���ĳ�ʼ״̬��
    public void InitializeHand(PlayerHandState _startState)
    {
        currentStateHand = _startState;
        currentStateHand.Enter();
    }

    // **״̬�л�����**
    // ��״̬�����ı�ʱ���ã��˳���ǰ״̬�������µ�״̬��
    public void ChangeStateHand(PlayerHandState _newState)
    {
        currentStateHand.Exit();
        currentStateHand = _newState;
        currentStateHand.Enter();
    }
    #endregion
}
