using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    public GameObject CoinBoxPrefab;
    private bool IsCoin = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // �� ����
            this.GetComponent<SpriteRenderer>().color = Color.gray;

            // ������ ����
            // ������ ������Ʈ�� �����ϴ� ����� ���� �Լ�
            // Instantiate(������ ������Ʈ, ������ ��ġ, ������ ȸ����);
            // Quaternion.identity << (0, 0, 0)���� ȸ������ �ʱ�ȭ �ϰڴ�
            // Quaternion.Euler(0, 0, 150) << (0, 0, 150)���� ȸ������ �ʱ�ȭ��
            // IsItem == false�϶� �����ȵ� -> �� �����۹ڽ��� �Ѱ��� ����
            if (IsCoin)
            {
                while (true)
                {
                    float Stop;
                    GameObject CreateItem;
                    CreateItem = Instantiate(CoinBoxPrefab, new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z), Quaternion.identity);

                    // �����ߴ� ������Ʈ�� ������Ʈ�� �̿�
                    CreateItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(1f,3f), Random.Range(5f,10f)), ForceMode2D.Impulse);

                    Destroy(CreateItem,8f);

                    Stop = Random.Range(0, 1f);
                    
                    if(Stop <= 0.2f) { break; }
                }
                IsCoin = false;
            }

            Invoke("IsCoinActive", 10f);
        }
    }

    void IsCoinActive()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
        IsCoin = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
