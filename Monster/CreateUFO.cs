using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateUFO : MonoBehaviour
{
    public GameObject UFO;//생성할 오브젝트
    bool IsZen = false;
    //GameObject[] CreateObj;
    private int Count = 0;
    int Before;

    void Start()
    {
        ///ScoreManager.MonsterPoint ==500 , 1000 1500 2000
        ////                           0       1   2    3
        /*if (CreateObj[Count] == null)
        {
            CreateObj[Count] = Instantiate(UFO);
        }*/
    }

    //지정된 위치에서
    //담아웠던 오브젝트를 
    //생성해주는 함수다
    private void CreatePrefab()
    {
        if (ScoreManager.MonsterPoint == (Before + 100))
        {
            IsZen = false;
        }

        if (ScoreManager.MonsterPoint % 500 == 0 && !IsZen && ScoreManager.MonsterPoint > 0 ) {
            //정중앙
            IsZen =true;
            Vector3 CreatePos = this.transform.position;
            Before = ScoreManager.MonsterPoint;

            //Random.Range(a,b)
            //a와 b범위안에서 값을 랜덤으로 준다 
            CreatePos.x += Random.Range(-30, 30);
            CreatePos.y = Random.Range(6,8);
            CreatePos.z = -3f; //앞에 지정

            //생성할 오브젝트를 담아주는 변수
            GameObject CreateObj = Instantiate(UFO);

            //생성했던 오브젝트를 위치값을 지정
            CreateObj.transform.position = CreatePos;



            Count ++;
        }
    }

    void Update()
    {
        CreatePrefab();
    }
}
