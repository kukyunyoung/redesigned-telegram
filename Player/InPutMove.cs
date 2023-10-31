using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



//�� ��ũ��Ʈ�� ���� ������Ʈ��
//Ű ���� �����鼭 ���ϴ� ��������
//�̵��Ѵ�
public class InPutMove : MonoBehaviour
{
    public float speed = 2f;//�ӵ�

    private float Input_X = 0;
    private float Input_Y = 0;
    bool IsJump = false;

    public float JumpPower = 0;

    public Flatform flatform;
    public NPC_Item NPC;

    private Rigidbody2D PlayerRig;
    //Rigidbody2D �������ִ� �׸�
    //�� �׸��� �̸��� PlayerRig ����Ѵ�

    public AudioClip JumpClip;
    public bool IsLeft = false;

    Image space;

    private void FixedUpdate()
    {
        Input_X = 0;
        Input_Y = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Input_Y = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Input_X = -speed;
            IsLeft = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Input_X = speed;
            IsLeft = false;
        }

        if (Input.GetKey(KeyCode.C) && !IsJump)
        {
            PlayerJump();
        }

        this.transform.Translate(Input_X / 50, 0, 0);
    }

    void Start()
    {
        PlayerRig
         = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void PlayerJump()
    {
        IsJump = true;
        PlayerRig.AddForce(new Vector2(0, JumpPower), ForceMode2D.Impulse);
        this.GetComponent<AudioSource>().PlayOneShot(JumpClip);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Flatform")
        {
            IsJump = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flatform" && Input.GetKey(KeyCode.DownArrow))
        {
            flatform.GetComponent<BoxCollider2D>().isTrigger = true;
        }

        if(collision.gameObject.tag == "Portal")
        {
            flatform.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC" && Input.GetKey(KeyCode.Space))
        {
            // ĳ���� �Ӹ����� �����̽� �̹��� ǥ��
            NPC.ProvidePortion();
        }
    }
}

