using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float moveSpeed = 2f; // 小怪的移动速度
    public float leftBoundary = -5f; // 左边界的世界坐标
    public float rightBoundary = 5f; // 右边界的世界坐标

    private Vector2 moveDirection = Vector2.right; // 初始移动方向

    void Update()
    {
        // 持续移动
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // 检查是否到达边界
        if (transform.position.x <= leftBoundary)
        {
            // 到达左边界，转向
            moveDirection = Vector2.right;
            FlipDirection();
        }
        else if (transform.position.x >= rightBoundary)
        {
            // 到达右边界，转向
            moveDirection = Vector2.left;
            FlipDirection();
        }
    }

    void FlipDirection()
    {
        // 翻转小怪的朝向
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        Debug.Log("Direction flipped!");
    }
}
