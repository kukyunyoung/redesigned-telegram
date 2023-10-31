using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // ���� �ʼ�

// UIâ ���� �����Ѵ�.
// ����, ���� ���� ȹ��, 

public class ScoreManager : MonoBehaviour
{
    // static ������ ����
    // �Ϲ� ������ �ٸ� �޸𸮿� �����
    // �ٷ� ���ٰ��� (ItemEffect.cs���� ���)
    public static int MonsterPoint;
    public static int CoinPoint;
    private float GTime = 180f;

    //MonsterPoint ���� �ؽ�Ʈ�� �����ش�
    public Text MonsterPoint_Text;
    public Text CoinPoint_Text;
    public Text Time_Text;
    
    public PlayerHp1 php;
    public Boss boss;
    public GameObject GameOverUI;
    public GameObject Bubble;

    float BT = 3f;
    float BT_Time = 3f;
    bool IsBarrier = false;

    void Init_var()
    {
        MonsterPoint = 0;
        GTime = 180f;
        CoinPoint = 0;
    }

    public void RestartBtn()
    {
        Init_var();
        SceneManager.LoadSceneAsync("Test8");
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!php.Return_IsDie())
        {
            if (GTime > 0)
            {
                GTime -= Time.deltaTime;
                Time_Text.text = GTime.ToString("F1"); // �Ҽ� ù��° �ڸ����� ǥ��
            }

            MonsterPoint_Text.text = "X " + MonsterPoint;
            CoinPoint_Text.text = "X " + CoinPoint;
        }
        TimeOver();
        BarrierTime();
    }

    void TimeOver()
    {
        if (GTime <=0)
        {
            php.Isdie();
        }
    }

    private void FixedUpdate()
    {
        // ���� �̻��϶� ���� ��ȯ
        if (MonsterPoint >= 1000 && boss.gameObject.GetComponent<Boss>().HP >0) 
        { 
            boss.gameObject.SetActive(true); 
        }

        // zŰ�� ���� ����5���� �Ҹ��Ͽ� 3�ʵ��� ������ ȿ��
        if (Input.GetKey(KeyCode.Z))
        {
            if (!IsBarrier && ScoreManager.CoinPoint>=5)
            {
                ScoreManager.CoinPoint -= 5;
                Bubble.SetActive(true);
                IsBarrier = true;
            }
        }

        if(!IsBarrier)
        {
            Bubble.SetActive(false);
        }
    }

    private void BarrierTime()
    {
        if (IsBarrier == true)
        {
            php.DamageTime = 1f;
            BT -= Time.deltaTime;

            if (BT <= 0)
            {
                php.DamageTime = 1.5f;
                BT = BT_Time;
                IsBarrier = false;
            }
        }
    }

}
