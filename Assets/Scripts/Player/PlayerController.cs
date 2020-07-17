using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Variables
    [Header("Scene References")]
    public CharacterController2D controller;

    [Header("Tuning")]
    public float runSpeed;
    public float jumpForce;
    #endregion

    #region Private Variables
    float horizontalMove = 0f;
    bool jump = false;
    GameManager gm;
    #endregion

    void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        #region Inputs
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Jump case
        if (Input.GetButtonDown("Jump"))
            jump = true;
        #endregion
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
