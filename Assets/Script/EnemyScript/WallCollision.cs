using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.right; // ��ʼ�ƶ�����
    public float moveSpeed = 2f; // С�ֵ��ƶ��ٶ�
    public float pauseTime = 2f; // ͣ��ʱ�䣨��λ���룩

    private Rigidbody2D rb;
    private bool isPaused = false; // �Ƿ���ͣ��״̬

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ��ȡ�������
    }

    void FixedUpdate()
    {
        if (!isPaused)
        {
            // ������ǰ�����ƶ�
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        }
        else
        {
            // ͣ��ʱ�ٶ�Ϊ0
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ����Ƿ�����ǽ
        if (collision.collider.CompareTag("Wall"))
        {
            StartCoroutine(PauseAndReverse());
        }
    }

    System.Collections.IEnumerator PauseAndReverse()
    {
        // ����ͣ��״̬
        isPaused = true;
        Debug.Log("Paused at wall.");

        // �ȴ�ָ����ͣ��ʱ��
        yield return new WaitForSeconds(pauseTime);

        // ͣ�ٽ��������ƶ�
        ReverseDirection();

        // �˳�ͣ��״̬
        isPaused = false;
    }

    void ReverseDirection()
    {
        // ��ת�ƶ�����
        moveDirection = -moveDirection;

        // ��תС�ֵĳ���
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        Debug.Log("Reversed direction. Now moving " + (moveDirection.x > 0 ? "right" : "left"));
    }
}

