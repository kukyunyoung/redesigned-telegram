using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� ��ũ��Ʈ�� ���� ������Ʈ��
//�ִϸ��̼��� �� ��Ȳ�� �°� 
//ȣ���Ѵ� (�ִϸ��̼� �̸�)
public class PlayAnim : MonoBehaviour
{
    public string UP_Anim = "";//�� �ִϸ��̼� �̸�
    public string Down_Anim = "";//�Ʒ� �ִϸ��̼� �̸�
    public string Right_Anim = "";//������ �ִϸ��̼� �̸�
    public string Left_Anim = "";//���� �ִϸ��̼� �̸�

    private string NowAnim = "";//���� ������� �ִϸ��̼�

    void Start()
    {

    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            NowAnim = UP_Anim;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            NowAnim = Left_Anim;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            NowAnim = Right_Anim;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            NowAnim = Down_Anim;
        }

        this.GetComponent<Animator>().Play(NowAnim);


    }
}
