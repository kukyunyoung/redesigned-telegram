using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ũ��Ʈ�� ���� ������Ʈ��
// Ư�� �±׸� ���� ������Ʈ�� �ε�������
// 1. ������ ȹ��Ҹ��� ���
// 2. ������ ȹ�� -> Ư��Ű�� �����ٸ� �� �������� �߻��ϰڴ�

public class ItemThrow : MonoBehaviour
{
    private AudioSource PlayerAudio; // �Ҹ������
    public AudioClip ItemPickClip;   // ȹ��Ҹ�
    public AudioClip ItemUseClip;

    public string Itemname = null;   // ȹ���� �������� ��Ƶ� ����
    public int ItemCount;

    public GameObject Frog_obj;           // ������ ������ ������Ʈ 
    public float speed = 15f;
    public float att_speed;
    public float att_angle;

    public InPutMove IPM;

    private void ItemThrowObj()
    {
        // �������� ȹ���ߴٸ�
        // Ư��Ű�� �����ٸ�
        // �������� �߻��ϰڴ�
        if (IPM.IsLeft) { att_speed = -speed; att_angle = 90f; }
        else { att_speed = speed; att_angle = -90f; }

        if (Itemname != null && ItemCount>=1)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                // Instantiate(������ ������Ʈ, ��ġ, ȸ����);
                GameObject Obj = Instantiate(Frog_obj, this.transform.position, Quaternion.Euler(0, 0, att_angle));
                Obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(att_speed, 0), ForceMode2D.Impulse);
                PlayerAudio.PlayOneShot(ItemUseClip);

                ScoreManager.CoinPoint--;
                //Itemname = null;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            PlayerAudio.PlayOneShot(ItemPickClip);
            // ������ ȹ��Ҹ� ���
            // ȹ���� �������� �ı���Ŵ

            Itemname = collision.gameObject.name;
            Destroy(collision.gameObject);
        }

        else if(collision.gameObject.tag == "Portion")
        {
            PlayerAudio.PlayOneShot(ItemPickClip);
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Coin")
        {
            // ������ ���� �� -> �Ҹ�, ��������Ʈ����, ���λ����
            PlayerAudio.PlayOneShot(ItemPickClip);

            ScoreManager.CoinPoint++;

            Destroy(collision.gameObject);
        }
    }

    void Start()
    {
        PlayerAudio = this.GetComponent<AudioSource>();
        IPM = this.GetComponent<InPutMove>();
    }

    void Update()
    {
        ItemThrowObj();
        ItemCount = ScoreManager.CoinPoint;
    }
}
