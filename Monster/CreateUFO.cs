using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateUFO : MonoBehaviour
{
    public GameObject UFO;//������ ������Ʈ
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

    //������ ��ġ����
    //��ƿ��� ������Ʈ�� 
    //�������ִ� �Լ���
    private void CreatePrefab()
    {
        if (ScoreManager.MonsterPoint == (Before + 100))
        {
            IsZen = false;
        }

        if (ScoreManager.MonsterPoint % 500 == 0 && !IsZen && ScoreManager.MonsterPoint > 0 ) {
            //���߾�
            IsZen =true;
            Vector3 CreatePos = this.transform.position;
            Before = ScoreManager.MonsterPoint;

            //Random.Range(a,b)
            //a�� b�����ȿ��� ���� �������� �ش� 
            CreatePos.x += Random.Range(-30, 30);
            CreatePos.y = Random.Range(6,8);
            CreatePos.z = -3f; //�տ� ����

            //������ ������Ʈ�� ����ִ� ����
            GameObject CreateObj = Instantiate(UFO);

            //�����ߴ� ������Ʈ�� ��ġ���� ����
            CreateObj.transform.position = CreatePos;



            Count ++;
        }
    }

    void Update()
    {
        CreatePrefab();
    }
}
