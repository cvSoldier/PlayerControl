using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessManager : MonoBehaviour
{
    private bool gameover = false;

    private PlayerController _playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }


    // duck走位，bgm淡出
    public void Step1()
    {
        _playerController.GameoverSlowMove();
    }

    // chef dialog + flipX, 镜头变黑缩紧。
    public void Step2()
    {
        
    }
    public void ShutGameDown()
    {
        gameover = true;
        _playerController.StopMoving();
    }

    public bool isGameover()
    {
        return gameover;
    }
}
