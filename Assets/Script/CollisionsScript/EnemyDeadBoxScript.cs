using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadBoxScript : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rbbox;
    public GameObject Enemy;
    public float deadLessSpeed;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("StayIdle", true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box") && rbbox.velocity.y < -deadLessSpeed)  // 判断进入触发器的物体是否是Box
        {
            anim.SetBool("StayIdle", false);
            anim.SetBool("StayDead", true);
            Destroy(Enemy);
        }


    }
}
