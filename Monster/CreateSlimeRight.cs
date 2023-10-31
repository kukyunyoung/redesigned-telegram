using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//지정한 범위 안(구름)에서
//담아뒀던 오브젝트를 생성한다
public class CreateSlimeRight: MonoBehaviour
{
    public GameObject Slime;//생성할 오브젝트
    bool IsDestroy = false;
    public bool IsRightSlimeZen;
    public GameObject Player;

    void Start()
    {
        InvokeRepeating("CreatePrefab", 1f, 1f);
    }

    //지정된 위치에서
    //담아웠던 오브젝트를 
    //생성해주는 함수다
    private void CreatePrefab()
    {
        if (ScoreManager.MonsterPoint <= 1000 && IsRightSlimeZen)
        {
            //정중앙
            Vector3 CreatePos
                = this.transform.position;

            //Random.Range(a,b)
            //a와 b범위안에서 값을 랜덤으로 준다 
            CreatePos.x += Random.Range(-20, 20);
            CreatePos.y += Random.Range(1, 20);
            CreatePos.z = -3f; //앞에 지정


            //생성할 오브젝트를 담아주는 변수
            GameObject CreateObj = Instantiate(Slime);

            //생성했던 오브젝트를 위치값을 지정
            CreateObj.transform.position = CreatePos;

            if (IsDestroy)
            {
                Destroy(CreateObj);
            }
        }
    }

    void Update()
    {
    }
}
