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
    [SerializeField] private float SpeedMultiplier;
    private float turnLock = 1;
    private Vector2 move;
    private bool canJump;
    //Legacy movement vectors, now are controlled via animation
    private Vector3 m;
    private Vector3 rayOffset;
    private Vector3 r;
    private Vector3 jumpForce;
    private Vector3 jumpForceStationary;
    private Animator cAnimator;
    //look stuff
    private Vector2 lookInput;
    [Range(0.0f, 10.0f)]
    public float turnAmount;
    
    
    
    
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
        ctrls.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        ctrls.Player.Look.canceled += ctx => lookInput = Vector2.zero;

    }

    private void Start()
    {
        m = new Vector3(0f, 0f, Time.deltaTime * .25f);
        jumpForce = new Vector3(0, 6f, 5f);
        jumpForceStationary = new Vector3(0, 5f, 0f);
        r = new Vector3(0f, Time.deltaTime*20f, 0f);
        rayOffset = new Vector3(0f, 0.5f, 0f);
        cAnimator.SetBool("OnGround",IsGrounded());
        SpeedMultiplier = 0;
    }
    private void Update()
    {
        HandleMovement();
        HandleRotation();
        Debug.Log(move.y);
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
                transform.Translate(m * SpeedMultiplier, Space.Self);
                cAnimator.SetBool("IsMoving", true);
            }
            else if (move.y< (-.25))
            {
                cAnimator.SetBool("IsMoving", true);
            }
        }
        else
            cAnimator.SetBool("IsMoving", false);
    }

    private void HandleRotation()
    {
        turnAmount = (move.x + lookInput.x/2);
        if (Mathf.Abs(turnAmount) >=0.15f)
        {
            cAnimator.SetFloat("TurnDirectionFloat", turnAmount);
            transform.Rotate(r * (turnAmount * (1+(SpeedMultiplier/2)) * turnLock), Space.World);
        }
        else 
            cAnimator.SetFloat("TurnDirectionFloat", 0);
    }

    public void CharacterJump()
    {
        if (IsGrounded())
        {
            cAnimator.applyRootMotion = false;
            rBody.velocity = Vector3.zero;
            cAnimator.SetTrigger(Jump);
            if (move.y > .25)
                rBody.AddRelativeForce(jumpForce+(jumpForce*(SpeedMultiplier*.1f)), ForceMode.Impulse);
            else
                rBody.AddRelativeForce(jumpForceStationary, ForceMode.Impulse);

        }
        else Debug.Log("Not Grounded");
    }

    public void CharacterSlide()
    {
        if ( Mathf.Abs(move.y) >=0.25f)
        {
            cAnimator.SetTrigger(Slide);
            Debug.Log("Slide");
        }
    }
    
    
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position+rayOffset, Vector3.down, .685f);
    }

    public void OnCollisionExit(Collision other)
    {
        if (!IsGrounded())
        {
            //Set animator bool isFalling to true;
            //Debug.Log("Left the ground");
            cAnimator.SetBool(OnGround, false);
            cAnimator.applyRootMotion = false;
            rBody.AddForce(rBody.velocity);
            turnLock = 0;
        }
        //else Debug.Log("Still on ground");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (IsGrounded())
        {
            //Debug.Log("Back on ground");
            cAnimator.applyRootMotion = true;
            cAnimator.SetBool(OnGround, true);
            turnLock = 1;
            //Set animator bool is falling to false;
        }
        //else Debug.Log("Hit something midair");
    }

    public void SetSpeedMultiplier(float m)
    {
        SpeedMultiplier = m;
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
