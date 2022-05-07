using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessManager : MonoBehaviour
{
    private bool gameover = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Step1()
    {
        gameover = true;
    }

    private void Step2()
    {
        
    }
    public void ShutGameDown()
    {
        // gameover = true, duck走位，bgm淡出
        Step1();
        // chef dialog + flipX, 镜头变黑缩紧。
        Step2();
    }

    public bool isGameover()
    {
        return gameover;
    }
}
