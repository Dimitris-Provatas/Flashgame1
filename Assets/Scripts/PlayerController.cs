using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1f, 10f)]
    public float jumpForce;
    
    [Range(0.0f, 1.0f)]
    public float jumpTime;

    float startedToJump = 0f;

    public float fallMultiplier;
    public float lowJumpMultiplier;

    Rigidbody2D rb;

    public Transform GroundCheck;
    bool isGrounded = false;
    bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GroundCheck = GameObject.FindWithTag("ground").transform;
    }

    void Update()
    {
        #region Jump
        if (transform.position.y - 1.25f < GroundCheck.position.y) isGrounded = true;
        else                                                       isGrounded = false;

        if (isGrounded)
            canJump = true;

        if (Input.GetButtonUp("Jump"))
            canJump = false;
        
        if (Input.GetButtonDown("Jump") && isGrounded)
            startedToJump = (float)Time.time;

        if (canJump)
            if (Input.GetButton("Jump") && transform.position.y < 1.5f && (float)Time.time < startedToJump + jumpTime)
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        if (rb.velocity.y <= 0)
            rb.velocity = new Vector2(rb.velocity.x, Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
        else if (rb.velocity.y < 2 && !Input.GetButton("Jump"))
            rb.velocity = new Vector2(rb.velocity.x, Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
        #endregion

    }
}
