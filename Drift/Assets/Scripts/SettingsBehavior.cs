using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;
using Toggle = UnityEngine.UI.Toggle;


public class SettingsBehavior : MonoBehaviour
{
   public SettingsStorage dataReference;
   
   [SerializeField] private Toggle PPtoggle;
   [SerializeField] private Volume PPVolume;
   [SerializeField] private Slider sensitivitySlider;
   [SerializeField] private CharacterInputRootMotion characterController;

   private void Start()
   {
      PPVolume.enabled = dataReference.PostProccessingEnabled;
      characterController.setLookSensitivity(dataReference.characterSensitivity);
   }

   public void applySettings() //apply all settings
   {
      applyPPToggle();
      ApplySensitivity();
   }

   public void revertSettings() // reset the settings from storage
   {
      LoadSettings();
   }

   private void LoadSettings() //load settings from storage
   {
      PPtoggle.isOn = dataReference.PostProccessingEnabled;
      sensitivitySlider.value = dataReference.characterSensitivity;
   }


   public void applyPPToggle() //apply pp toggle with button
   {
      PPVolume.enabled = PPtoggle.isOn;
      dataReference.PostProccessingEnabled = PPtoggle.isOn;
   }

   public void ApplySensitivity()
   {
      characterController.setLookSensitivity(sensitivitySlider.value);
      dataReference.characterSensitivity = sensitivitySlider.value;
   }

   private void OnEnable()
   {
      LoadSettings();
   }
}
