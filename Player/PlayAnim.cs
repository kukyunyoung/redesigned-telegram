using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이 스크립트를 가진 오브젝트는
//애니메이션을 각 상황에 맞게 
//호출한다 (애니메이션 이름)
public class PlayAnim : MonoBehaviour
{
    public string UP_Anim = "";//위 애니메이션 이름
    public string Down_Anim = "";//아래 애니메이션 이름
    public string Right_Anim = "";//오른쪽 애니메이션 이름
    public string Left_Anim = "";//왼쪽 애니메이션 이름

    private string NowAnim = "";//현재 재생중인 애니메이션

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
