using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(Animator))]
public class CharacterInputRootMotion : MonoBehaviour
{
    //Referenced Objects
    private Animator cAnimator;
    private PlayerControls ctrls;
    private Rigidbody rBody;
    //speed boost
    [SerializeField] private float SpeedMultiplier;
    //recieving vector for input system
    private Vector2 move;
    //Legacy movement vectors, now are controlled via animation
    private Vector3 additionalMovement;
    private Vector3 rayOffset;
    private Vector3 jumpForce;
    private Vector3 jumpForceStationary;
    [SerializeField] [Range(0, 20)] private float jumpDistance, jumpHeight;
    [SerializeField] [Range(0, 100)] private float turnSensitivity;
    
    //Look and Turn
    private Vector2 lookInput;
    private float turnAmount;
    private float turnLock = 1;
    private Vector3 r;
    
    //Stored spawn coordinates
    private Vector3 startLocation;
    private Quaternion startRotation;
    private Transform startTransform;


    //ReCaching Animator Data
    private static readonly int RunDirectionFloat = Animator.StringToHash("RunDirectionFloat");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int OnGround = Animator.StringToHash("OnGround");
    private static readonly int Slide = Animator.StringToHash("Slide");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int TurnDirectionFloat = Animator.StringToHash("TurnDirectionFloat");

    void Awake()
    {
        cAnimator = GetComponent<Animator>();
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
        additionalMovement = new Vector3(0f, 0f, Time.deltaTime * .25f);
        jumpForce = new Vector3(0, jumpHeight, jumpDistance);
        jumpForceStationary = new Vector3(0, jumpHeight, 0f);
        r = new Vector3(0f, Time.deltaTime*turnSensitivity, 0f);
        rayOffset = new Vector3(0f, 0.5f, 0f);
        cAnimator.SetBool(OnGround,IsGrounded());
        SpeedMultiplier = 0;
        startLocation = gameObject.transform.position;
        startRotation = gameObject.transform.rotation;
    }
    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        cAnimator.SetFloat(RunDirectionFloat, move.y);
        if ( Mathf.Abs(move.y) >=0.25f)//artificial deadzone
        {
            if (move.y > .25)   //if forward
            {
                transform.Translate(additionalMovement * SpeedMultiplier, Space.Self);  //Add SpeedBoost if boost is active
                cAnimator.SetBool(IsMoving, true);
            }
            else if (move.y< (-.25))    //if reverse
            {
                cAnimator.SetBool(IsMoving, true);
            }
        }
        else
            cAnimator.SetBool(IsMoving, false);
    }

    private void HandleRotation()
    {
        turnAmount = move.x == 0 ? lookInput.x / 8 : move.x;
        
        //combine screenswipe and input i
        if (Mathf.Abs(turnAmount) >=0.15f)
        {
            cAnimator.SetFloat(TurnDirectionFloat, turnAmount);
            transform.Rotate(r * (turnAmount * (1+(SpeedMultiplier/2)) * turnLock), Space.World);               //rotate the character
        }
        else 
            cAnimator.SetFloat(TurnDirectionFloat, 0);
    }

    public void CharacterJump()
    {
        if (IsGrounded())
        {
            cAnimator.applyRootMotion = false;  //turns off root motion for jump
            rBody.velocity = Vector3.zero;  //stops character
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
    
    public void OnCollisionExit(Collision other)
    {
        if (!IsGrounded())
        {
            cAnimator.SetBool(OnGround, false);
            cAnimator.applyRootMotion = false;
            rBody.AddForce(rBody.velocity);
            turnLock = 0;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (IsGrounded())
        {
            cAnimator.applyRootMotion = true;
            cAnimator.SetBool(OnGround, true);
            turnLock = 1;
        }
    }

    public void SetSpeedMultiplier(float x)
    {
        SpeedMultiplier = x;
    }
    private bool IsGrounded()   //Ground check
    {
        return Physics.Raycast(transform.position+rayOffset, Vector3.down, .685f);
    }
    public void OnEnable()
    {
        ctrls.Player.Enable();
    }
    public void OnDisable()
    {
        ctrls.Player.Disable();
    }

    public void ResetCharacter()
    {
        transform.position = startLocation;
        transform.rotation = startRotation; 
    }
    
}
