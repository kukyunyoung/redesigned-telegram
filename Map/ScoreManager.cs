using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 선언 필수

// UI창 점수 관리한다.
// 코인, 몬스터 점수 획득, 

public class ScoreManager : MonoBehaviour
{
    // static 변수로 선언
    // 일반 변수와 다른 메모리에 선언됨
    // 바로 접근가능 (ItemEffect.cs에서 사용)
    public static int MonsterPoint;
    public static int CoinPoint;
    private float GTime = 180f;

    //MonsterPoint 값을 텍스트로 보여준다
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
                Time_Text.text = GTime.ToString("F1"); // 소수 첫번째 자리까지 표기
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
        // 몇점 이상일때 보스 소환
        if (MonsterPoint >= 1000 && boss.gameObject.GetComponent<Boss>().HP >0) 
        { 
            boss.gameObject.SetActive(true); 
        }

        // z키를 눌러 코인5개를 소모하여 3초동안 베리어 효과
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
