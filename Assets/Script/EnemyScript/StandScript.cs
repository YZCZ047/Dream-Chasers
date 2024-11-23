using UnityEngine;

public class IdleTurnMonsterSimpleInstant : MonoBehaviour
{
    public float turnInterval = 5f;  // 每隔多少秒转一次
    private float timer = 0f;        // 计时器

    void Update()
    {
        timer += Time.deltaTime; // 累加时间

        if (timer >= turnInterval) // 当计时器达到指定间隔时间
        {
            timer = 0f; // 重置计时器

            // 直接在 Y 轴旋转 90 度
            transform.Rotate(0, 90f, 0);
        }
    }
}
