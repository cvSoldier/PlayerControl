using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private GameObject Player;

    private Vector3 Offset;
    [SerializeField] private int speed = 4;

    void Start()
    {
        Player = GameObject.Find("Player");
        Offset = Player.transform.position - transform.position;
    }

    void Update()
    {
        //调整相机与玩家之间的距离
        transform.position = Vector3.Lerp(transform.position, Player.transform.position - Offset, speed * Time.deltaTime);
    }
}