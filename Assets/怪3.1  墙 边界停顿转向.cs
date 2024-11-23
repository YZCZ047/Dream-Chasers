using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.right; // 初始移动方向
    public float moveSpeed = 2f; // 小怪的移动速度
    public float pauseTime = 2f; // 停顿时间（单位：秒）

    private Rigidbody2D rb;
    private bool isPaused = false; // 是否处于停顿状态

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 获取刚体组件
    }

    void FixedUpdate()
    {
        if (!isPaused)
        {
            // 持续向当前方向移动
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        }
        else
        {
            // 停顿时速度为0
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 检测是否碰到墙
        if (collision.collider.CompareTag("Wall"))
        {
            StartCoroutine(PauseAndReverse());
        }
    }

    System.Collections.IEnumerator PauseAndReverse()
    {
        // 进入停顿状态
        isPaused = true;
        Debug.Log("Paused at wall.");

        // 等待指定的停顿时间
        yield return new WaitForSeconds(pauseTime);

        // 停顿结束后反向移动
        ReverseDirection();

        // 退出停顿状态
        isPaused = false;
    }

    void ReverseDirection()
    {
        // 反转移动方向
        moveDirection = -moveDirection;

        // 翻转小怪的朝向
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        Debug.Log("Reversed direction. Now moving " + (moveDirection.x > 0 ? "right" : "left"));
    }
}
