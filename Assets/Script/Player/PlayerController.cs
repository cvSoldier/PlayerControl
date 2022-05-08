using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 8;
    [SerializeField] private float jumpSpeed = 6;
    private float fadeTime = 1f;

    private Rigidbody2D rb;
    private Collision _collision;
    private Animator playerAnimation;
    private Fadeout _fadeout;
    private ProcessManager _processManager;

    private bool isSqueezing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _collision = GetComponent<Collision>();
        playerAnimation = GetComponent<Animator>();
        _fadeout = GetComponent<Fadeout>();
        _processManager = GameObject.FindWithTag("ProcessManager").GetComponent<ProcessManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_processManager.isGameover()) return;
        Movement();
        TurnAround();
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * x, rb.velocity.y);

        if (!isSqueezing)
        {
            // 起跳
            if (Input.GetButtonDown("Jump") && _collision.onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                StartCoroutine(JumpSqueeze(0.5f, 1.2f, 0.1f));
                playerAnimation.SetBool("isJump", true);
            }
            // 落地
            if (!_collision.wasOnGround && _collision.onGround)
            {
                StartCoroutine(JumpSqueeze(1.25f, 0.8f, 0.05f));
                playerAnimation.SetBool("isJump", false);
            }
        }
    }

    void TurnAround()
    {
        float xRaw = Input.GetAxisRaw("Horizontal");
        
        if (xRaw == 1)
        {
            playerAnimation.SetBool("LookForward", true);
        } else if (xRaw == -1)
        {
            playerAnimation.SetBool("LookForward", false);
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

    IEnumerator slowMoveThreeSeconds()
    {
        rb.velocity = new Vector2(speed / 2, 0);
        yield return new WaitForSeconds(fadeTime);
        rb.velocity = Vector2.zero;
    }

    public void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    public void GameoverSlowMove()
    {
        StartCoroutine("slowMoveThreeSeconds");
        _fadeout.BeginFade();
    }
}
