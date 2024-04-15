using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CleanUp" || collision.gameObject.tag == "VendingMachine" || collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
    }
}