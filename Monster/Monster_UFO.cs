using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_UFO : MonoBehaviour
{
    public GameObject PlayerObj;
    public GameObject Laiser;
    bool IsPattern = false;
    float PT = 3f;

    // 플레이어 추격 상대방위치-내위치
    // 플레이어를 따라다님 (y축 고정, x축만 따라다님)
    void Tracing()
    {
        Vector2 TargetPos = PlayerObj.transform.position - this.transform.position;

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(TargetPos.x * Random.Range(1.8f, 2.2f), 0);
        //this.transform.position = TargetPos;
    }

    // 수직방향으로 공격을 함
    void Attack()
    {
        GameObject AttObj;
        if (!IsPattern)
        {
            AttObj = Instantiate(Laiser, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.Euler(0, 0, 90f));
            AttObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0.1f), ForceMode2D.Force);

            IsPattern = true;

            Destroy(AttObj, 5f);
        }
    }

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

    void Start()
    {
        PlayerObj = GameObject.Find("Player");
    }

    void Update()
    {
        Tracing();
        Attack();
        PatternTime(3f);
    }
}
