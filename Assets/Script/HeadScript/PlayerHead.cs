using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    [Header("whatIsGround")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform LWallCheck;
    [SerializeField] private float LwallCheckDistance;
    [SerializeField] private Transform RWallCheck;
    [SerializeField] private float RWallCheckDistance;

    [Header("Move info")]
    public float moveSpeed;
    public float jumpForce;
    public float xInput;

    public bool Ground;
    public bool isWall;
    public float isWallCool = 0.5f;




    [Header("Dash info")]
    [SerializeField] public static bool canDash = true;//Ϊ��Ӣ����׼��
    public bool isDash;
    public float isDashCool = 0.2f;
    public float dashSpeed = 15f;
    public float dashTime = 0.2f;
    public float dashTimeCool;
    public float dashTimeCD = 0.5f;
    public int dashDir = 1;

    public int facingDir = 1;
    public bool facingRight = true;

    public Rigidbody2D rb;
    public Animator anim;

    protected PlayerHead playerHead;



    // **���״̬**
    #region States
    // ״̬�������ڹ�����ҵĲ�ͬ״̬��Idle��Move�ȣ���
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerHeadIdleState idleStateHead { get; private set; }
    public PlayerHeadMoveState moveStateHead { get; private set; }
    public PlayerHeadJumpState jumpStateHead { get; private set; }
    public PlayerHeadAirState airStateHead { get; private set; }
    public PlayerHeadGroundState groundStateHead { get; private set; }
    public PlayerHeadDashState dashStateHead { get; private set; }
    public PlayerHeadDamageState damageStateHead { get; private set; }
    public PlayerHeadDeadState deadStateHead { get; private set; }
    public PlayerHeadBirthState birthStateHead { get; private set; }
    public PlayerHeadWallState wallStateHead { get; private set; }
    #endregion


    private void Awake()
    {
        // ��ʼ��״̬������������ҵ��ض�״̬��
        stateMachine = new PlayerStateMachine();
        idleStateHead = new PlayerHeadIdleState(this, stateMachine, "HeadIdle");
        moveStateHead = new PlayerHeadMoveState(this, stateMachine, "HeadMove");
        jumpStateHead = new PlayerHeadJumpState(this, stateMachine, "HeadJump");
        airStateHead = new PlayerHeadAirState(this, stateMachine, "HeadJump");
        groundStateHead = new PlayerHeadGroundState(this, stateMachine, "HeadGround");
        dashStateHead = new PlayerHeadDashState(this, stateMachine, "HeadDush");
        damageStateHead = new PlayerHeadDamageState(this, stateMachine, "HeadDamage");
        deadStateHead = new PlayerHeadDeadState(this, stateMachine, "HeadDead");
        birthStateHead = new PlayerHeadBirthState(this, stateMachine, "HeadBirth");
        wallStateHead = new PlayerHeadWallState(this, stateMachine, "HeadWall");
    }
    void Start()
    {
        // ���ó�ʼ״̬ΪIdle��
        stateMachine.InitializeHead(birthStateHead);
        
        
    }

    
    void Update()
    {
        stateMachine.currentStateHead.Update();

        xInput = Input.GetAxisRaw("Horizontal");

        Ground = IsGroundDetected();

        WallDetect();

        DashDirChange();

        dashTimeCool -= Time.deltaTime;
        isWallCool -= Time.deltaTime;
        isDashCool -= Time.deltaTime;

        if (rb.velocity.x < -15f)
        {
            rb.velocity = new Vector2(-15f, rb.velocity.y);
        }
        else if (rb.velocity.x > 15f)
        {
            rb.velocity = new Vector2(15f, rb.velocity.y);
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimeCool < 0 && canDash)
        {
            isDash = true;
            stateMachine.ChangeStateHead(dashStateHead);

        }


        if (!IsGroundDetected() && !isDash)
        {
            stateMachine.ChangeStateHead(airStateHead);
        }
        if (IsGroundDetected())
        {
            isWall = false;
        }



    }
    #region DashDirChange
    private void DashDirChange()
    {
        if (xInput > 0)
        {
            dashDir = 1;
        }
        else if (xInput < 0)
        {
            dashDir = -1;
        }
    }
    #endregion

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

    #region VelocityContral
    public void VelocityContral()
    {
        if (rb.velocity.x < -8f)
        {
            rb.velocity = new Vector2(-8f, rb.velocity.y);
        }
        else if (rb.velocity.x > 8f)
        {
            rb.velocity = new Vector2(8f, rb.velocity.y);
        }
    }
    #endregion

    #region WallDetect
    private void WallDetect()
    {
        
        // ǽ����
        if (IsLeftWallDetected() )
        {
            isWall = true;
            if (rb.velocity.x < -6 && IsGroundDetected())// �ٶ�̫�������Wall
            {
                stateMachine.ChangeStateHead(wallStateHead);// ����Wall
            }
            if (!IsGroundDetected()) //�ٶ�̫С���ڿ������������赯��
            {
                stateMachine.ChangeStateHead(wallStateHead);
                SetForce(70f, 0);
            }
            if (rb.velocity.x < -0.5f && !IsGroundDetected())// �����ٶȴ�С�ص�
            {
                stateMachine.ChangeStateHead(wallStateHead);
                SetVelocity(-rb.velocity.x * 1.5f, 0);
            }

        }
        if (IsRightWallDetected())
        {
            isWall = true;
            if (rb.velocity.x > 6 && IsGroundDetected())
            {
                stateMachine.ChangeStateHead(wallStateHead);// ����Wall
            }
            if (rb.velocity.x < 0.5f && !IsGroundDetected())
            {
                SetForce(-7f, 0);
                stateMachine.ChangeStateHead(wallStateHead);
            }
            else if (rb.velocity.x > 0.5f)
            {

                SetVelocity(-rb.velocity.x * 1.5f, 0);
                stateMachine.ChangeStateHead(wallStateHead);
            }

        }
    }
    #endregion


    #region Velocity
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
    #endregion

    #region RayDetected
    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public bool IsLeftWallDetected() => Physics2D.Raycast(LWallCheck.position, Vector2.left, LwallCheckDistance, whatIsGround);
    public bool IsRightWallDetected() => Physics2D.Raycast(RWallCheck.position, Vector2.right, RWallCheckDistance, whatIsGround);
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(LWallCheck.position, new Vector3(LWallCheck.position.x - LwallCheckDistance, LWallCheck.position.y));
        Gizmos.DrawLine(RWallCheck.position, new Vector3(RWallCheck.position.x + RWallCheckDistance, RWallCheck.position.y));
    }
    #endregion
}
