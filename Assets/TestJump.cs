using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    //[SerializeField] private float jumpForce;
    //�������ֲ�ͬ״̬���������ý�ɫ����ʱ�����Ծʱ�����
    [SerializeField] private float jumpGS;
    [SerializeField] private float fallGS;

    [SerializeField] private float jumpHeight;

    //���ó�����ť���ٽ�ֵ
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
            //�ù�ʽ�����ɫÿ����Ծ��ͬ�߶ȵ�����µ���Ծ��Ӧ���Ƕ���
            jumpForce = Mathf.Sqrt(jumpHeight * (Physics.gravity.y * rb.gravityScale) * -2) * rb.mass;
            //������������
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
            //���ݰ��°�����ʱ���Լ�����Ƿ��ɿ���ť�����������Ĵ�С���Ӷ��ý�ɫʵ��������Ծ��Ч��
            if (pressedTime < pressedLine && Input.GetKeyUp(KeyCode.Space))
            {
                rb.gravityScale = fallGS;
            
            
            }
            //��������ʱ�����
            if (rb.velocity.y < 0) 
            {
                rb.gravityScale = fallGS;
                jumping = false;
            }
        
        }
    }
}
