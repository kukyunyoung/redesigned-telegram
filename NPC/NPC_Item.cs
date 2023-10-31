using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Item : MonoBehaviour
{
    bool IsItem;
    public GameObject Item_Portion;

    public void ProvidePortion()
    {
        if (IsItem)
        {
            GameObject CreateItem;
            CreateItem = Instantiate(Item_Portion, new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z), Quaternion.identity);

            // 생성했던 오브젝트의 컴포넌트를 이용
            CreateItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 2f), ForceMode2D.Impulse);

            IsItem = false;
        }
    }

    void Start()
    {
        IsItem = true;
    }

    void Update()
    {
        
    }
}
