using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 defaultOffset = new Vector3(6, 3, -31);
    Vector3 offset;
    public Vector3 secondOffset;
    public float num = 0;


    // Start is called before the first frame update
    void Start()
    {
        offset = defaultOffset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset + new Vector3(0, num, 0) + secondOffset;
        
        if(player.transform.position.y <= -2.59){
            offset = new Vector3(6, -player.transform.position.y + 0.4f, 0);

        } else {
            offset = defaultOffset;
        }
    }
}
