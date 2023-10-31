using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_shield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BossAtt")
        {
            Destroy(collision.gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
