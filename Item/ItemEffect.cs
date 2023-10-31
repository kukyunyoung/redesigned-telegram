using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ũ��Ʈ�� ���� ������Ʈ�� �ð��� ������ �ı��ȴ�.
// Ư�� ������Ʈ�� �ε������� ����ȿ���� �ش�.
// ���͸� �ı��� �� ������ ȹ���Ѵ�.

public class ItemEffect : MonoBehaviour
{
    public GameObject AttEffect;   // ���� ȿ��
    private GameObject Att_Effect; // �����ߴ� ����ȿ���� ��Ƶд�.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ε����� ������Ʈ�� ���Ͷ�� �±׶��
        if (collision.gameObject.tag == "Monster")
        {
            // �ε����� ��ġ���� ����ȿ���� �����Ѵ�
            Att_Effect = Instantiate(AttEffect, collision.transform.position, Quaternion.identity);

            Destroy(Att_Effect, 1f);

            // static ������ ����ż� �ٷ� ��밡��
            ScoreManager.MonsterPoint += 100;

            // �ε����� ������Ʈ�� �ı�
            //collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Boss")
        {
            Att_Effect = Instantiate(AttEffect, collision.transform.position, Quaternion.identity);

            Destroy(Att_Effect, 1f);
        }
    }

    void Start()
    {
        Destroy(this.gameObject, Random.Range(1.5f,2f));
    }

    void Update()
    {
        
    }
}
