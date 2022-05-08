using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadeout : MonoBehaviour
{
    //时长
    private float time=1f;
    //定时器
    private float timer;
    //透明度 alpha值 0-1
    private float Alpha = 1f;
    private bool beginFade = false;
 
    // Update is called once per frame
    void Update()
    {
        if (!beginFade) return;
        timer += Time.deltaTime;
        Alpha = (time - timer) / time;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, Alpha);
    }

    public void BeginFade()
    {
        beginFade = true;
    }
}
