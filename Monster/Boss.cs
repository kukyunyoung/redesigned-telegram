using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int HP=5;
    float rand_x; 
    float rand_y;
    bool IsLeft = false;
    private float DamageTime = 1.5f;
    private float PT = 5f;
    bool IsHit = false;
    bool IsPattern = false;
    public Image HpBar;
    private float ptt = 5f;
    int Att_amount = 5;

    public GameObject SlimePrefab;

    // ������ �� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            Get_dmg();
            if(HP <= 2)
            {
                ptt = 2.5f;
                Att_amount = 8;
            }
        }
    }

    void JUMP(float rand_x, float rand_y)
    {
        if (IsLeft) { this.GetComponent<SpriteRenderer>().flipX = true; }
        else { this.GetComponent<SpriteRenderer>().flipX = false; }
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(rand_x, rand_y), ForceMode2D.Impulse);
    }

    void Att_Pattern(float rand_x, float rand_y, int Att_amount)
    {
        GameObject[] CreateItem = new GameObject[Att_amount];
        
        for (int i = 0; i < Att_amount; i++)
        {
            CreateItem[i] = Instantiate(SlimePrefab, new Vector3(this.transform.position.x * 1, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            CreateItem[i].GetComponent<BoxCollider2D>().isTrigger = true;
            CreateItem[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(rand_x , rand_y), Random.Range(rand_x, rand_y)), ForceMode2D.Impulse);
        }

        for (int i = 0; i < Att_amount; i ++)
        {
            Destroy(CreateItem[i], 5f);
        }
    }

    // bool ������ �̿��ؼ� PatternTime() �Լ��� �ð����� �༭ ���Ͻ�����
    void pattern()
    {
        rand_x = Random.Range(-10f, 10f);
        rand_y = Random.Range(10f, 20f);

        if (rand_x <= 0) { IsLeft = true; }
        else { IsLeft = false; }

        if (!IsPattern)
        {
            JUMP(rand_x, rand_y);
            Att_Pattern(rand_x, rand_y, Att_amount);
            IsPattern = true;
        }
    }

    public void Get_dmg()
    {
        if (!IsHit)
        {
            HP--;
            HpBar.rectTransform.localScale = new Vector3((float)HP / 5f, 1f, 1f);
            IsHit = true;
        }

        if(HP <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void HitTime()
    {
        if (IsHit == true)
        {
            DamageTime -= Time.deltaTime;
            this.GetComponent<SpriteRenderer>().color = Color.gray;

            if (DamageTime <= 0)
            {
                DamageTime = 1.5f;
                IsHit = false;
                if (HP > 2)
                {
                    this.GetComponent<SpriteRenderer>().color = Color.white;
                }
                else
                {
                    this.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
    }

    // IsPattern == true (������ ���������)
    // -> PT���� ���ҽ�Ŵ
    // -> 0�̵Ǹ� 5�� �ٲ� �� ���Ͻ��డ�� ���·� �ٲ���(false)
    private void PatternTime(float P_time)
    {
        if (IsPattern == true)
        {
            PT -= Time.deltaTime;

            if (PT <= 0)
            {
                PT = P_time;
                IsPattern = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        HitTime();
        PatternTime(ptt);
        pattern();
    }
}
