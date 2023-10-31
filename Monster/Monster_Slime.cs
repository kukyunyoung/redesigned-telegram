using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster_Slime : MonoBehaviour
{
    float rand_x;
    float rand_y;
    bool IsLeft = false;
    float JT = 5f;
    float Wait_JT = 5f;
    bool IsJump = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void JUMP()
    {
        rand_x = Random.Range(-5f, 5f);
        rand_y = Random.Range(1f, 5f);

        if (rand_x <= 0) { IsLeft = true; }
        else { IsLeft = false; }

        if (!IsJump)
        {
            if (IsLeft) { this.GetComponent<SpriteRenderer>().flipX = true; }
            else { this.GetComponent<SpriteRenderer>().flipX = false; }

            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(rand_x, rand_y), ForceMode2D.Impulse);
            IsJump = true;
        }
    }

    private void JumpTime(float J_time)
    {
        if (IsJump == true)
        {
            JT -= Time.deltaTime;

            if (JT <= 0)
            {
                JT = J_time;
                IsJump = false;
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        JumpTime(Wait_JT);
        JUMP();
    }
}
