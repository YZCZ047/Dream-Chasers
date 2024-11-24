using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTurnMonsterSimpleInstant : MonoBehaviour
{
    public float turnInterval = 5f;  // ÿ��������תһ��
    private float timer = 0f;        // ��ʱ��
    public bool facRight = false;

    void Update()
    {
        timer += Time.deltaTime; // �ۼ�ʱ��

        if (timer >= turnInterval) // ����ʱ���ﵽָ�����ʱ��
        {
            timer = 0f; // ���ü�ʱ��

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

