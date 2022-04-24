using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpSpeed = 7;
    // private float jumpSpeed = 10;

    private Rigidbody2D rb;
    private Collision _collision;

    private bool isSqueezing = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _collision = GetComponent<Collision>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float xRaw = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * x, rb.velocity.y);
        if (xRaw != 0)
        {
            transform.localScale = new Vector3(xRaw * Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (!isSqueezing)
        {
            // 起跳
            if (Input.GetButtonDown("Jump") && _collision.onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                StartCoroutine(JumpSqueeze(0.5f, 1.2f, 0.1f));
            }
            // 落地
            if (!_collision.wasOnGround && _collision.onGround)
            {
                StartCoroutine(JumpSqueeze(1.25f, 0.8f, 0.05f));
            }
        }
    }

    IEnumerator JumpSqueeze(float xSqueeze, float ySqueeze, float seconds)
    {
        isSqueezing = true;
        Vector3 originSize = transform.localScale;
        Vector3 nowSize = new Vector3(xSqueeze * originSize.x, ySqueeze * originSize.y, originSize.z);
        float t = 0;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.localScale = Vector3.Lerp(originSize, nowSize, t);
            yield return null;
        }

        t = 0;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.localScale = Vector3.Lerp(nowSize, originSize, t);
            yield return null;
        }

        isSqueezing = false;
    }
}
