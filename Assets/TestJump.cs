using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private float jumpForce;
    //设置两种不同状态的重力，让角色下落时间比跳跃时间更短
    [SerializeField] private float jumpGS;
    [SerializeField] private float fallGS;

    [SerializeField] private float jumpHeight;

    //设置长按按钮的临界值
    [SerializeField] private float pressedLine = 0.5f;

    [SerializeField] private bool jumping;

    float pressedTime;
    float jumpForce;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale = jumpGS;
            //用公式求出角色每次跳跃相同高度的情况下的跳跃力应该是多少
            jumpForce = Mathf.Sqrt(jumpHeight * (Physics.gravity.y * rb.gravityScale) * -2) * rb.mass;
            //设置力的类型
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
            pressedTime = 0;
        }

        /*if (rb.velocity.y > 0.1f)
        {
            rb.gravityScale = jumpGS;
        }
        else
        {
            rb.gravityScale = fallGS;
        }*/

        if (jumping)
        {
            pressedTime += Time.deltaTime;
            //根据按下按键的时间以及检测是否松开按钮来控制重力的大小，从而让角色实现脉冲跳跃的效果
            if (pressedTime < pressedLine && Input.GetKeyUp(KeyCode.Space))
            {
                rb.gravityScale = fallGS;
            
            
            }
            //物体下落时间更快
            if (rb.velocity.y < 0) 
            {
                rb.gravityScale = fallGS;
                jumping = false;
            }
        
        }
    }
}
