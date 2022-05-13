using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{
    [SerializeField] private int times = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestory");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);
    }

    public void TimesPlusPlus()
    {
        times++;
    }

    public int GetTimes()
    {
        return times;
    }
}
