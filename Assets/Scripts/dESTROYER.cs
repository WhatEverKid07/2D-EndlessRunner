using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dESTROYER : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CleanUp")
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "VendingMachine")
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
        
    }


}