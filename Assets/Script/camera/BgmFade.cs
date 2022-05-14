using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmFade : MonoBehaviour
{
    private AudioSource Music;
    private float volumeDelta;
    private float targetvolume ;
    private bool isFading = false;
    // Start is called before the first frame update
    void Start()
    {
        Music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFading) return;
        if(Math.Abs(Music.volume - targetvolume) >= Math.Abs(volumeDelta))
        {
            Music.volume += (float)volumeDelta;
        }
        else
        {
            Music.volume = targetvolume;
            isFading = false;
        }
    }

    private void fadeMusic(float targetVolume, float durtime)
    {
        targetvolume = targetVolume;
        float timedelta = durtime / Time.deltaTime;
        if(timedelta > 0)
            volumeDelta = (targetVolume - Music.volume) / timedelta;
        else
        {
            volumeDelta = (targetVolume - Music.volume);
        }

        isFading = true;
    }
    public void beginFadeBgm()
    {
        fadeMusic(0.5f,1f);
    }
}
