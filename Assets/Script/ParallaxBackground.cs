using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPositoin;
    
    private float textureUnitSizex;
    [SerializeField] private float parallaxEffectMultipuler;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        // cameraTransform = GameObject.FindWithTag("Player").transform;
        lastCameraPositoin = cameraTransform.position;
        
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        // 背景图缩放过，需要 ✖️scale
        textureUnitSizex = transform.lossyScale.x * (texture.width / sprite.pixelsPerUnit);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPositoin;
        transform.position += deltaMovement * parallaxEffectMultipuler;
        lastCameraPositoin = cameraTransform.position;
        
        if (Mathf.Abs(transform.position.x - cameraTransform.position.x) >= textureUnitSizex)
        {
            float offsetPositionX = (transform.position.x - cameraTransform.position.x) % textureUnitSizex;
            
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
    }
}
