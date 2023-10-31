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
            // 색 변경
            this.GetComponent<SpriteRenderer>().color = Color.gray;

            // 아이템 생성
            // 씬에서 오브젝트를 생성하는 기능을 가진 함수
            // Instantiate(생성할 오브젝트, 생성될 위치, 생성될 회전값);
            // Quaternion.identity << (0, 0, 0)으로 회전값을 초기화 하겠다
            // Quaternion.Euler(0, 0, 150) << (0, 0, 150)으로 회전값을 초기화함
            // IsItem == false일땐 생성안됨 -> 한 아이템박스당 한개만 생성
            if (IsCoin)
            {
                while (true)
                {
                    float Stop;
                    GameObject CreateItem;
                    CreateItem = Instantiate(CoinBoxPrefab, new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z), Quaternion.identity);

                    // 생성했던 오브젝트의 컴포넌트를 이용
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
