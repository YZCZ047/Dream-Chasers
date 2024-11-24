using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamShardStay : MonoBehaviour
{
    public GameObject DreamShard;
    
    public float minFloatHeight = 0.05f;  // 最小浮动高度
    public float maxFloatHeight = 0.1f;  // 最大浮动高度
    public float minFloatSpeed = 2f;   // 最小浮动速度
    public float maxFloatSpeed = 3f;   // 最大浮动速度

    private float floatHeight;            // 当前浮动高度
    private float floatSpeed;             // 当前浮动速度
    private Vector3 startPosition;        // 初始位置

    void Start()
    {
        // 随机设置浮动的高度和速度
        floatHeight = Random.Range(minFloatHeight, maxFloatHeight);
        floatSpeed = Random.Range(minFloatSpeed, maxFloatSpeed);
        startPosition = transform.position;
    }

    void Update()
    {
        // 根据正弦波进行上下浮动
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerHead.Life < 4)  // 判断进入触发器的物体是否是Player
        {
            PlayerHead.dreamShard++; //加梦境碎片
            Destroy(DreamShard);
        }
    }
}
