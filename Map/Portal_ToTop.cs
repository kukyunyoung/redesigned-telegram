using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal_ToTop : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Portal_Another;
    public GameObject Player;
    public CreateSlime CSL;
    public UserCamera US;

    Image image;

    GameObject[] Monster;
    GameObject[] Att;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(FadeOut_());
            StartCoroutine(FadeIn_());

            CSL.IsLeftSlimeZen = true;
        }
    }

    void Start()
    {
        image = Panel.GetComponent<Image>();
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
        yield return new WaitForSeconds(0.5f);

        Vector3 pos = Portal_Another.transform.position;
        Player.GetComponent<Transform>().position = new Vector3(pos.x, pos.y + 2, pos.z - 8);

        US.IsCameraState = 1;

        Player.GetComponent<PlayerHp1>().Fade_in(); // 포탈에서 빠져나오면 캐릭터 정지, 무적 해제
        float Fade_A = 1;

        while (Fade_A >= 0)
        {
            Fade_A -= 0.02f;
            Panel.GetComponent<Image>().color = new Color(0, 0, 0, Fade_A);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
