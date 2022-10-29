using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class SetAnimationSpeed : MonoBehaviour
{
    private Animator anm;
    [SerializeField] private float scale;

    private void Start()
    {
        anm = GetComponent<Animator>();
        SetAnimatorSpeed(scale);
    }

    public void SetAnimatorSpeed(float val)
    {
        anm.speed = val;
    }
}
