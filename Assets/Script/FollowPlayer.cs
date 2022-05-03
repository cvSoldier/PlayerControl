using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private GameObject Player;

    private float Offset;
    [SerializeField] private int speed = 4;

    void Start()
    {
        Player = GameObject.Find("Player");
        Offset = Player.transform.position.x - transform.position.x;
    }

    void Update()
    {
        //调整相机与玩家之间的距离
        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x - Offset, transform.position.y, transform.position.z), speed * Time.deltaTime);
    }
}