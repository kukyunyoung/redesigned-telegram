using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트를 가진 오브젝트는
// 플레이어 라는 오브젝트랑 충돌했을때
// 1. 아이템이 나온다
// 2. 색깔이 바뀐다
// 3. 부딪힐때마다 계속 생성되기 때문에 한번만 생성

public class ItemBox : MonoBehaviour
{
    public GameObject itemBoxPrefab;
    private bool IsItem = true;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // 색 변경
            this.GetComponent<SpriteRenderer>().color = Color.gray;

            if (IsItem)
            {
                GameObject CreateItem;
                CreateItem = Instantiate(itemBoxPrefab, new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z), Quaternion.identity);

                // 생성했던 오브젝트의 컴포넌트를 이용
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
