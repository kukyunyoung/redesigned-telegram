using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//������ ���� ��(����)����
//��Ƶ״� ������Ʈ�� �����Ѵ�
public class CreateSlime : MonoBehaviour
{
    public GameObject Slime;//������ ������Ʈ
    bool IsDestroy = false;
    public bool IsLeftSlimeZen;

    void Start()
    {
        InvokeRepeating("CreatePrefab", 1f, 1f);
    }

    //������ ��ġ����
    //��ƿ��� ������Ʈ�� 
    //�������ִ� �Լ���
    private void CreatePrefab()
    {
        if (ScoreManager.MonsterPoint <= 1000 && IsLeftSlimeZen)
        {
            //���߾�
            Vector3 CreatePos
                = this.transform.position;

            //Random.Range(a,b)
            //a�� b�����ȿ��� ���� �������� �ش� 
            CreatePos.x += Random.Range(-25, 25);
            CreatePos.y += Random.Range(1, 20);
            CreatePos.z = -3f; //�տ� ����


            //������ ������Ʈ�� ����ִ� ����
            GameObject CreateObj = Instantiate(Slime);

            //�����ߴ� ������Ʈ�� ��ġ���� ����
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
