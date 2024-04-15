using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parallax : MonoBehaviour
{
    public GameObject cam;
    public float parallaxEffect;
    private float lengh, startpos;
    void Start ()
    {
        startpos = transform.position.x;
        lengh = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + lengh)
        {
            startpos += lengh;
        }
        else if (temp < startpos - lengh)
        {
            startpos -= lengh;
        }
    }
}