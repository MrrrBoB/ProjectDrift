using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(Animator))]
public class CharacterInputRootMotion : MonoBehaviour
{
    private PlayerControls ctrls;
    private Rigidbody rBody;
    public float speedMultiplier;
    private Vector2 move;
    private bool canJump;
    //Legacy movement vectors, now are controlled via animation
    private Vector3 m;
    private Vector3 v;
    private Vector3 r;
    private Vector3 j;
    private Animator cAnimator;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int RunDirectionFloat = Animator.StringToHash("RunDirectionFloat");

    void Awake()
    {
        cAnimator = GetComponentInChildren<Animator>();
        ctrls = new PlayerControls();
        rBody = GetComponent<Rigidbody>();
        ctrls.Player.Jump.performed += ctx => CharacterJump();
        ctrls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        ctrls.Player.Move.canceled += ctx => move = Vector2.zero;
        
    }

    private void Start()
    {
        m = new Vector3(0f, 0f, Time.deltaTime * 2f);
        j = new Vector3(0, 10f, 10f);
        r = new Vector3(0f, Time.deltaTime*20f, 0f);
        SetJump(IsGrounded());
    }
    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    public void MoveCharacter()
    {
        Debug.Log("Moved");
    }

    private void HandleMovement()
    {
        cAnimator.SetFloat(RunDirectionFloat, move.y);
        if ( Mathf.Abs(move.y) >=0.25f)
        {
            if (move.y > .25)
            {
                transform.Translate(m * speedMultiplier, Space.Self);
                cAnimator.SetBool("IsMoving", true);
            }
            else if (move.y< (-.25))
            {
                //transform.Translate(v, Space.Self);
                cAnimator.SetBool("IsMoving", true);
            }
        }
        else
            cAnimator.SetBool("IsMoving", false);
    }

    private void HandleRotation()
    {
        if (Mathf.Abs(move.x) >=0.5f)
        {
            cAnimator.SetFloat("TurnDirectionFloat", move.x);
            transform.Rotate(r*move.x*(1+speedMultiplier), Space.World);
        }
        else 
            cAnimator.SetFloat("TurnDirectionFloat", 0);
    }

    public void CharacterJump()
    {
        if (IsGrounded())
        {
            rBody.AddForce(j, ForceMode.Impulse);
            cAnimator.SetTrigger("Jump");
            Debug.Log("Boing");
        }
        else Debug.Log("Not Grounded");
    }

    private void SetJump(bool val)
    {
        canJump = val;
        cAnimator.SetBool("OnGround", val);
    }
    private void OnEnable()
    {
        ctrls.Player.Enable();
    }
    private void OnDisable()
    {
        ctrls.Player.Disable();
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, .1f);
    }
}
