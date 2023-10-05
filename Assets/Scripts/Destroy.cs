using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    bool isDestroyed = false;
    public LayerMask VendingMachine;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isDestroyed = AnimatorController.VendingMachine(object);
    }
}
