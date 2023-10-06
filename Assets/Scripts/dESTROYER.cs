using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dESTROYER : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("bumbed into something");

        if (collision.gameObject.tag == "CleanUp")
        {
            Destroy(collision.gameObject);
            Debug.Log("object destroyed");

        }
    }


}