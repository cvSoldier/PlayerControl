using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("layers")]
    public LayerMask groundLayer;
    
    public bool onGround;
    public bool wasOnGround;
    [SerializeField]
    private float gizmoLen = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wasOnGround = onGround;
        onGround = Physics2D.Raycast(transform.position, Vector3.down, gizmoLen, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * gizmoLen);
    }
}
