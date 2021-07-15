using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float PlayerSpeed;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(new Vector2(move * PlayerSpeed,rigid.velocity.y));

        // 속도 제한하기
        if (rigid.velocity.x >= 8) rigid.velocity = new Vector2(8, rigid.velocity.y);
        else if (rigid.velocity.x <= -8) rigid.velocity = new Vector2(-8, rigid.velocity.y);
    }




}
