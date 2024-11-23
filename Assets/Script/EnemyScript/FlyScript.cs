using UnityEngine;

public class FlyingMonster : MonoBehaviour
{
    public float moveDistance = 3f;  // 单次飞行的距离（上下飞的范围）
    public float moveSpeed = 2f;    // 飞行速度
    public float pauseDuration = 1f; // 每次到达目标位置后的停留时间

    private Vector3 startPosition;  // 起始位置
    private Vector3 targetPosition; // 当前目标位置
    private bool movingUp = true;   // 是否正在向上飞
    private float pauseTimer = 0f;  // 停留计时器

    void Start()
    {
        // 初始化起始位置
        startPosition = transform.position;

        // 初始化目标位置（先向上飞）
        targetPosition = startPosition + Vector3.up * moveDistance;
    }

    void Update()
    {
        // 如果正在停留，倒计时到 0 后恢复飞行
        if (pauseTimer > 0f)
        {
            pauseTimer -= Time.deltaTime;
            return;
        }

        // 移动到目标位置
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 如果到达目标位置
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // 开始停留
            pauseTimer = pauseDuration;

            // 切换目标位置（上下切换）
            if (movingUp)
                targetPosition = startPosition + Vector3.down * moveDistance; // 向下飞
            else
                targetPosition = startPosition + Vector3.up * moveDistance;   // 向上飞

            movingUp = !movingUp; // 翻转飞行方向
        }
    }
}
