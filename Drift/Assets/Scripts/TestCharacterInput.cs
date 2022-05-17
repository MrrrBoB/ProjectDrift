using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]
public class TestCharacterInput : MonoBehaviour
{
    private PlayerControls ctrls;
    private Rigidbody rBody;
    private Vector2 move;

    void Awake()
    {
        ctrls = new PlayerControls();
        rBody = GetComponent<Rigidbody>();
        ctrls.Player.Jump.performed += ctx => CharacterJump();
        ctrls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        ctrls.Player.Move.canceled += ctx => move = Vector2.zero;
    }

    private void Update()
    {
        Vector2 r = new Vector2(0f, move.x) * Time.deltaTime*100f;
        transform.Rotate(r, Space.World);
        //transform.rotation = Quaternion.AngleAxis(move.x*-10, Vector3.forward);
        Vector3 m = new Vector3(0f, 0f, move.y) * Time.deltaTime*10f;
        transform.Translate(m, Space.Self);
    }

    public void MoveCharacter()
    {
        Debug.Log("Moved");
    }

    public void CharacterJump()
    {
        rBody.AddForce(Vector3.up* 5f, ForceMode.Impulse);
        Debug.Log("Boing");
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
