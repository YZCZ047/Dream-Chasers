using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadIsAttacked : MonoBehaviour
{
    public float knockbackForce = 1000f;  // ���˵�����
    public float knockbackDuration = 0.5f;  // ����ʱ��
    public Rigidbody2D rb;
    private bool isKnockedBack = false;  // �ж��Ƿ��Ѿ�����

    void Start()
    {
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // ����������ˣ�������˱�ǩΪ "Enemy"��
        if (other.CompareTag("Enemy") && PlayerHead.invincible < 0 && !PlayerHead.isAttacked)
        {
            Debug.Log("isAttacked");
            PlayerHead.isAttacked = true;
            // ������˷��򣺵���λ�������֮�������
            Vector2 knockbackDirection = (transform.position - other.transform.position).normalized;

            rb.AddForce(knockbackDirection * knockbackForce);

            // ִ�л���Ч��
            //Knockback(knockbackDirection);
        }
    }

    //void Knockback(Vector2 direction)
    //{
    //    if (isKnockedBack) return;  // ����Ѿ����ڻ���״̬�����ظ�ִ��

    //    isKnockedBack = true;

    //    // Ӧ����������ܵ�����
    //    rb.AddForce(direction * knockbackForce * 50);

    //    // �ڻ��˽�����ָ�����״̬
    //    StartCoroutine(RecoverFromKnockback());
    //}

    //private IEnumerator RecoverFromKnockback()
    //{
    //    // ����ʱ���ָ�
    //    yield return new WaitForSeconds(knockbackDuration);
    //    isKnockedBack = false;
    //}
}
