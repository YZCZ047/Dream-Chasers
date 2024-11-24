using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleEnemy : MonoBehaviour
{
    public float moveSpeed = 2f; // 小怪的移动速度
    private float stayTiming;
    public float stayTime;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    //[SerializeField] private LayerMask whatIsGround;

    private Vector2 moveDirection = Vector2.left;
    public bool facRight = false; // 初始移动方向

    void Update()
    {


        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance);

        if (hit.collider != null)
        {
            // 如果碰撞到物体，检查它的名字是否为 "MoveZone"
            if (hit.collider.name == "MoveZone")
            {
                transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
                stayTiming = stayTime;
            }
            // 如果碰撞物体不是 "MoveZone" 或者是 null（如果没有碰撞到任何物体）
            else
            {
                stayTiming -= Time.deltaTime;
            }
        }
        else
        {
            // 如果没有碰撞到任何物体，执行这部分逻辑
            stayTiming -= Time.deltaTime;
        }


        if (stayTiming < 0)
        {
            if (facRight)
            {
                moveDirection = Vector2.left;
                facRight = !facRight;
                FlipDirection();
                return;
            }
            else
            {
                moveDirection = Vector2.right;
                facRight = !facRight;
                FlipDirection();
                return;

            }
        }

    }

    void FlipDirection()
    {
        // 翻转小怪的朝向
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Debug.Log("Direction flipped!");
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }
}
