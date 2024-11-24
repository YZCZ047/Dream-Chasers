using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpeedScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float xSpeedMax;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VelocityContral();
    }
    #region VelocityContral
    public void VelocityContral()
    {
        if (rb.velocity.x < -xSpeedMax)
        {
            rb.velocity = new Vector2(-xSpeedMax, rb.velocity.y);
        }
        else if (rb.velocity.x > xSpeedMax)
        {
            rb.velocity = new Vector2(xSpeedMax, rb.velocity.y);
        }

    }
    #endregion
}
