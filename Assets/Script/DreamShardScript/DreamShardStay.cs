using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamShardStay : MonoBehaviour
{
    public GameObject DreamShard;
    
    public float minFloatHeight = 0.05f;  // ��С�����߶�
    public float maxFloatHeight = 0.1f;  // ��󸡶��߶�
    public float minFloatSpeed = 2f;   // ��С�����ٶ�
    public float maxFloatSpeed = 3f;   // ��󸡶��ٶ�

    private float floatHeight;            // ��ǰ�����߶�
    private float floatSpeed;             // ��ǰ�����ٶ�
    private Vector3 startPosition;        // ��ʼλ��

    void Start()
    {
        // ������ø����ĸ߶Ⱥ��ٶ�
        floatHeight = Random.Range(minFloatHeight, maxFloatHeight);
        floatSpeed = Random.Range(minFloatSpeed, maxFloatSpeed);
        startPosition = transform.position;
    }

    void Update()
    {
        // �������Ҳ��������¸���
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerHead.Life < 4)  // �жϽ��봥�����������Ƿ���Player
        {
            PlayerHead.dreamShard++; //���ξ���Ƭ
            Destroy(DreamShard);
        }
    }
}
