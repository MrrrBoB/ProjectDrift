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
    private Vector3 rayOffset;
    private Vector3 r;
    private Vector3 j;
    private Animator cAnimator;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int RunDirectionFloat = Animator.StringToHash("RunDirectionFloat");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int OnGround = Animator.StringToHash("OnGround");
    private static readonly int Slide = Animator.StringToHash("Slide");

    void Awake()
    {
        cAnimator = GetComponentInChildren<Animator>();
        ctrls = new PlayerControls();
        rBody = GetComponent<Rigidbody>();
        ctrls.Player.Jump.performed += ctx => CharacterJump();
        ctrls.Player.Slide.performed += ctx => CharacterSlide();
        ctrls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        ctrls.Player.Move.canceled += ctx => move = Vector2.zero;
        
    }

    private void Start()
    {
        m = new Vector3(0f, 0f, Time.deltaTime * 2f);
        j = new Vector3(0, 10f, 1f);
        r = new Vector3(0f, Time.deltaTime*20f, 0f);
        rayOffset = new Vector3(0f, 0.5f, 0f);
        cAnimator.SetBool("OnGround",IsGrounded());
    }
    private void Update()
    {
        HandleMovement();
        HandleRotation();
        //Debug.DrawRay(transform.position, Vector3.down, Color.green);
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
            transform.Rotate(r * (move.x * (1+(speedMultiplier/2))), Space.World);
        }
        else 
            cAnimator.SetFloat("TurnDirectionFloat", 0);
    }

    public void CharacterJump()
    {
        if (IsGrounded())
        {
            cAnimator.applyRootMotion = false;
            cAnimator.SetTrigger(Jump);
            rBody.AddRelativeForce(j, ForceMode.Impulse);
        }
        else Debug.Log("Not Grounded");
    }

    public void CharacterSlide()
    {
        cAnimator.SetTrigger(Slide);
        Debug.Log("Slide");
    }
    
    
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position+rayOffset, Vector3.down, .7f);
    }

    public void OnCollisionExit(Collision other)
    {
        if (!IsGrounded())
        {
            //Set animator bool isFalling to true;
            Debug.Log("Left the ground");
            cAnimator.SetBool(OnGround, false);
        }
        else Debug.Log("Still on ground");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (IsGrounded())
        {
            Debug.Log("Back on ground");
            cAnimator.applyRootMotion = true;
            cAnimator.SetBool(OnGround, true);
            //Set animator bool is falling to false;
        }
        else Debug.Log("Hit something midair");
    }
    
    
    
    private void OnEnable()
    {
        ctrls.Player.Enable();
    }
    private void OnDisable()
    {
        ctrls.Player.Disable();
    }
}
