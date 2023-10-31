using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ũ��Ʈ�� ���� ������Ʈ��
// �÷��̾� ��� ������Ʈ�� �浹������
// 1. �������� ���´�
// 2. ������ �ٲ��
// 3. �ε��������� ��� �����Ǳ� ������ �ѹ��� ����

public class ItemBox : MonoBehaviour
{
    public GameObject itemBoxPrefab;
    private bool IsItem = true;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // �� ����
            this.GetComponent<SpriteRenderer>().color = Color.gray;

            if (IsItem)
            {
                GameObject CreateItem;
                CreateItem = Instantiate(itemBoxPrefab, new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z), Quaternion.identity);

                // �����ߴ� ������Ʈ�� ������Ʈ�� �̿�
                CreateItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(4f, 2f),ForceMode2D.Impulse);

                IsItem = false;
            }

        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
