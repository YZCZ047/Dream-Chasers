using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonster : MonoBehaviour
{
    public float moveDistance = 3f;  // ���η��еľ��루���·ɵķ�Χ��
    public float moveSpeed = 2f;    // �����ٶ�
    public float pauseDuration = 1f; // ÿ�ε���Ŀ��λ�ú��ͣ��ʱ��

    private Vector3 startPosition;  // ��ʼλ��
    private Vector3 targetPosition; // ��ǰĿ��λ��
    private bool movingUp = true;   // �Ƿ��������Ϸ�
    private float pauseTimer = 0f;  // ͣ����ʱ��

    void Start()
    {
        // ��ʼ����ʼλ��
        startPosition = transform.position;

        // ��ʼ��Ŀ��λ�ã������Ϸɣ�
        targetPosition = startPosition + Vector3.up * moveDistance;
    }

    void Update()
    {
        // �������ͣ��������ʱ�� 0 ��ָ�����
        if (pauseTimer > 0f)
        {
            pauseTimer -= Time.deltaTime;
            return;
        }

        // �ƶ���Ŀ��λ��
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // �������Ŀ��λ��
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            // ��ʼͣ��
            pauseTimer = pauseDuration;

            // �л�Ŀ��λ�ã������л���
            if (movingUp)
                targetPosition = startPosition + Vector3.down * moveDistance; // ���·�
            else
                targetPosition = startPosition + Vector3.up * moveDistance;   // ���Ϸ�

            movingUp = !movingUp; // ��ת���з���
        }
    }
}

