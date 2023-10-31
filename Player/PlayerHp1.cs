using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �÷��̾� ü���� UI�̹����� �����ش�
// ����(����, ����)
// �´¼Ҹ�
// ���ӿ��� -> ü���� �� ���Ͻ�

public class PlayerHp1 : MonoBehaviour
{
    public Image[] PlayerHP = new Image[3];
    private AudioSource AS;
    public AudioClip HitSound;
    public int HP_MAX = 2;
    public float DamageTime = 1.5f;
    public GameObject GameOverUI;
    private bool IsHit = false;

    private bool IsDie = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "BossAtt")
        {
            if (DamageTime >= 1.5f)
            {
                this.GetComponent<SpriteRenderer>().color = Color.gray;
                Invoke("ResetColor", 1f);

                AS.PlayOneShot(HitSound);
                PlayerHP[HP_MAX].color = Color.black;
                HP_MAX--;
                // �ǰ���Ÿ��
                IsHit = true;
            }
        }

        if (HP_MAX <= -1)
        {
            GameOverUI.SetActive(true);
            this.GetComponent<InPutMove>().enabled = false;
            this.GetComponent<PlayAnim>().enabled = false;
            IsDie = true;
        }

        if(collision.gameObject.tag == "Portion" && HP_MAX<2)
        {
            HP_MAX++;
            PlayerHP[HP_MAX].color = Color.white;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "BossAtt")
        {
            if (DamageTime >= 1.5f)
            {
                this.GetComponent<SpriteRenderer>().color = Color.gray;
                Invoke("ResetColor", 1f);

                AS.PlayOneShot(HitSound);
                PlayerHP[HP_MAX].color = Color.black;
                HP_MAX--;
                // �ǰ���Ÿ��
                IsHit = true;
            }
        }

        if (HP_MAX <= -1)
        {
            Isdie();
        }

    }

    // fade out ������ ����, �ൿ�Ұ�
    public void Fade_out() 
    {
        DamageTime = 1f;
        this.GetComponent<InPutMove>().enabled = false;
        this.GetComponent<PlayAnim>().enabled = false;
    }

    // fade in ������ ����, �ൿ�Ұ� ����
    public void Fade_in() 
    {
        DamageTime = 1.5f;
        this.GetComponent<InPutMove>().enabled = true;
        this.GetComponent<PlayAnim>().enabled = true;
    }

    private void ResetColor()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public bool Return_IsDie()
    {
        return IsDie;
    }

    // �ǰ���Ÿ��
    private void HitTime()
    {
        if (IsHit == true)
        {
            DamageTime -= Time.deltaTime;

            if (DamageTime <= 0)
            {
                DamageTime = 1.5f;
                IsHit = false;
            }
        }
    }

    public void Isdie()
    {
        GameOverUI.SetActive(true);
        this.GetComponent<InPutMove>().enabled = false;
        this.GetComponent<PlayAnim>().enabled = false;
        IsDie = true;
    }

    void Start()
    {
        AS = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HitTime();
    }
}
