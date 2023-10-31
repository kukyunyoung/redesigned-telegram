using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

// 슬라임 ufo 삭제

public class Portal1 : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Portal_Another;
    public GameObject Player;
    public CreateSlimeRight CSR;
    public CreateSlime CSL;
    public UserCamera US;

    Image image;

    GameObject[] Monster;
    GameObject[] Att;

    private void OnCollisionEnter2D(Collision2D collision)
    { 

        if(collision.gameObject.name == "Player")
        {
            StartCoroutine(FadeOut_());
            StartCoroutine(FadeIn_());

            CSR.IsRightSlimeZen = false;
            CSL.IsLeftSlimeZen = true;
        }
    }

    void Start()
    {
        image = Panel.GetComponent<Image>();
        CSR.IsRightSlimeZen = false;
    }

    void Update()
    {
        Monster = GameObject.FindGameObjectsWithTag("Monster");
        Att = GameObject.FindGameObjectsWithTag("BossAtt");
    }

    private IEnumerator FadeOut_()
    {
        Player.GetComponent<PlayerHp1>().Fade_out(); // 포탈에 닿으면 캐릭터 정지, 무적


        float Fade_A = 0;
        foreach (var slime in Monster)
        {
            Destroy(slime);
        }

        foreach (var att in Att)
        {
            Destroy(att);
        }


        while (Fade_A <= 1)
        {
            Fade_A += 0.02f;
            Panel.GetComponent<Image>().color = new Color(0, 0, 0, Fade_A);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator FadeIn_()
    {
        Vector3 pos = Portal_Another.transform.position;

        yield return new WaitForSeconds(0.5f);
        Player.GetComponent<Transform>().position = new Vector3(pos.x - 1f, pos.y, pos.z - 8);
        US.IsCameraState = 1;

        Player.GetComponent<PlayerHp1>().Fade_in();
        float Fade_A = 1;

        while (Fade_A >= 0)
        {
            Fade_A -= 0.02f;
            Panel.GetComponent<Image>().color = new Color(0, 0, 0, Fade_A);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
