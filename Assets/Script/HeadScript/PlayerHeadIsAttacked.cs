using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadIsAttacked : MonoBehaviour
{
    public float knockbackForce = 1000f;  // 击退的力度
    public float knockbackDuration = 0.5f;  // 持续时间
    public Rigidbody2D rb;
    private bool isKnockedBack = false;  // 判断是否已经击退

    void Start()
    {
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // 如果碰到敌人（假设敌人标签为 "Enemy"）
        if (other.CompareTag("Enemy") && PlayerHead.invincible < 0 && !PlayerHead.isAttacked)
        {
            Debug.Log("isAttacked");
            PlayerHead.isAttacked = true;
            // 计算击退方向：敌人位置与玩家之间的向量
            Vector2 knockbackDirection = (transform.position - other.transform.position).normalized;

            rb.AddForce(knockbackDirection * knockbackForce);

            // 执行击退效果
            //Knockback(knockbackDirection);
        }
    }

    //void Knockback(Vector2 direction)
    //{
    //    if (isKnockedBack) return;  // 如果已经处于击退状态，不重复执行

    //    isKnockedBack = true;

    //    // 应用力让玩家受到击退
    //    rb.AddForce(direction * knockbackForce * 50);

    //    // 在击退结束后恢复正常状态
    //    StartCoroutine(RecoverFromKnockback());
    //}

    //private IEnumerator RecoverFromKnockback()
    //{
    //    // 持续时间后恢复
    //    yield return new WaitForSeconds(knockbackDuration);
    //    isKnockedBack = false;
    //}
}
