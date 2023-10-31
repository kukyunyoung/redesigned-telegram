using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트를 가진 오브젝트는 시간이 지나면 파괴된다.
// 특정 오브젝트와 부딪혔을때 공격효과를 준다.
// 몬스터를 파괴할 시 점수를 획득한다.

public class ItemEffect : MonoBehaviour
{
    public GameObject AttEffect;   // 공격 효과
    private GameObject Att_Effect; // 생셩했던 공격효과를 담아둔다.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딪히는 오브젝트가 몬스터라는 태그라면
        if (collision.gameObject.tag == "Monster")
        {
            // 부딪히는 위치에서 공격효과를 생성한다
            Att_Effect = Instantiate(AttEffect, collision.transform.position, Quaternion.identity);

            Destroy(Att_Effect, 1f);

            // static 변수로 선언돼서 바로 사용가능
            ScoreManager.MonsterPoint += 100;

            // 부딪히는 오브젝트를 파괴
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
