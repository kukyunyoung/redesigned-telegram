using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트를 가진 오브젝트는
// 특정 태그를 가진 오브젝트랑 부딪혔을때
// 1. 아이템 획득소리를 재생
// 2. 아이템 획득 -> 특정키를 누른다면 그 아이템을 발사하겠다

public class ItemThrow : MonoBehaviour
{
    private AudioSource PlayerAudio; // 소리재생기
    public AudioClip ItemPickClip;   // 획득소리
    public AudioClip ItemUseClip;

    public string Itemname = null;   // 획득한 아이템을 담아둔 변수
    public int ItemCount;

    public GameObject Frog_obj;           // 생성할 아이템 오브젝트 
    public float speed = 15f;
    public float att_speed;
    public float att_angle;

    public InPutMove IPM;

    private void ItemThrowObj()
    {
        // 아이템을 획득했다면
        // 특정키를 누른다면
        // 아이템을 발사하겠다
        if (IPM.IsLeft) { att_speed = -speed; att_angle = 90f; }
        else { att_speed = speed; att_angle = -90f; }

        if (Itemname != null && ItemCount>=1)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                // Instantiate(생성할 오브젝트, 위치, 회전값);
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
            // 아이템 획득소리 재생
            // 획득한 아이템은 파괴시킴

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
            // 코인을 먹은 뒤 -> 소리, 코인포인트증가, 코인사라짐
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
