using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Start()
    {
        player = GameObject.FindWithTag("player").transform;
    }


    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x ,
        player.position.y + offset.y ,
        player.position.z + offset.z);
    }
}
