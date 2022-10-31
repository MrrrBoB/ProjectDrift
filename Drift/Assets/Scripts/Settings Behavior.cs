using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;using UnityEngine.Rendering;using UnityEngine.UIElements;

public class SettingsBehavior : MonoBehaviour
{
   public Toggle PPtoggle;
   private bool toggleEnterState;
   [SerializeField] private Volume PPVolume;
   public void applySettings()
   {
      applyPPToggle();
   }

   public void revertSettings()
   {
      
   }

   private void OnEnable()
   {
      toggleEnterState = PPtoggle.value;
   }


   public void applyPPToggle()
   {
      PPVolume.enabled = PPtoggle.value;
   }
}
