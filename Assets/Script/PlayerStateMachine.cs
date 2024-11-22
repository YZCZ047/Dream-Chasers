using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    #region Head
    // 当前状态的引用，用于存储和管理当前状态。
    public PlayerHeadState currentStateHead { get; private set; }

    // **初始化函数**
    // 初始化状态机，将当前状态设置为指定的初始状态。
    public void InitializeHead(PlayerHeadState _startState)
    {
        currentStateHead = _startState;
        currentStateHead.Enter();
    }

    // **状态切换函数**
    // 当状态发生改变时调用，退出当前状态并进入新的状态。
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
    // 当前状态的引用，用于存储和管理当前状态。
    public PlayerFootState currentStateFoot { get; private set; }

    // **初始化函数**
    // 初始化状态机，将当前状态设置为指定的初始状态。
    public void InitializeFoot(PlayerFootState _startState)
    {
        currentStateFoot = _startState;
        currentStateFoot.Enter();
    }

    // **状态切换函数**
    // 当状态发生改变时调用，退出当前状态并进入新的状态。
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
    // 当前状态的引用，用于存储和管理当前状态。
    public PlayerHandState currentStateHand { get; private set; }

    // **初始化函数**
    // 初始化状态机，将当前状态设置为指定的初始状态。
    public void InitializeHand(PlayerHandState _startState)
    {
        currentStateHand = _startState;
        currentStateHand.Enter();
    }

    // **状态切换函数**
    // 当状态发生改变时调用，退出当前状态并进入新的状态。
    public void ChangeStateHand(PlayerHandState _newState)
    {
        currentStateHand.Exit();
        currentStateHand = _newState;
        currentStateHand.Enter();
    }
    #endregion
}
