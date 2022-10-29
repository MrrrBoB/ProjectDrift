using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
   [SerializeField] private Animation anim;


   public void PlayClip()
   {
      anim.Play();
   }
}
