using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [Range(1, 5)]
    public float ForceJump = 4; // req = 4

    [Range(1, 5)]
    public float SpeedWalk = 3; //req = 3

    private Rigidbody2D rb;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public bool isGrounded;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rigid;
    private Vector2 _startPos;

    private int extraJumpsValue;
    public int extraJumps;
    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    private float h;
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
        _startPos = transform.position;
    }
   private void Update()
    {
        isGrounded = Physics2D.OverlapPoint(groundCheck.position, whatIsGround);

        extraJumps = extraJumpsValue;

        h = Input.GetAxis("Horizontal");
        if (h < 0)
        {
            _sprite.flipX = true;
        }
        if (h > 0)
        {
            _sprite.flipX = false;
        }

        _rigid.velocity = new Vector2(h * SpeedWalk, _rigid.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, 0);
            _rigid.AddForce(Vector2.up * ForceJump, ForceMode2D.Impulse);
        } else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * ForceJump;
        }
    }

    public void ResetPosition()
    {
        transform.position = _startPos;
    }
}
