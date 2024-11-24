using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTurnMonsterSimpleInstant : MonoBehaviour
{
    public float turnInterval = 5f;  // 每隔多少秒转一次
    private float timer = 0f;        // 计时器
    public bool facRight = false;

    void Update()
    {
        timer += Time.deltaTime; // 累加时间

        if (timer >= turnInterval) // 当计时器达到指定间隔时间
        {
            timer = 0f; // 重置计时器

            if (facRight)
            {
                transform.Rotate(0, transform.rotation.y + 180f, 0);
                facRight = !facRight;
            }
            else
            {
                transform.Rotate(0, transform.rotation.y - 180f, 0);
                facRight = !facRight;

            }

        }
    }
}

