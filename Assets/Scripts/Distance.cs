using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public Transform player;
    public Text distanceScore;

    // Update is called once per frame
    void Update()
    {
        distanceScore.text = player.position.x.ToString("0");
    }
}
