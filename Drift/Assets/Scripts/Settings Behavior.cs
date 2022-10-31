using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;using UnityEngine.Rendering;using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;


public class SettingsBehavior : MonoBehaviour
{
   public SettingsStorage dataReference;
   
   
   public Toggle PPtoggle;
   private bool currentPostProcessToggleState;
   [SerializeField] private Volume PPVolume;
   [SerializeField] private Slider audioSlider, sensitivitySlider;
   [SerializeField] private AudioSource musicPlayer;

   private void Start()
   {
      currentPostProcessToggleState = dataReference.PostProccessingEnabled;
   }

   public void applySettings()
   {
      applyPPToggle();
      applyAudioSlider();
   }

   public void revertSettings()
   {
      OnEnable();
   }

   private void OnEnable()
   {
      PPtoggle.value = dataReference.PostProccessingEnabled;
      audioSlider.value = dataReference.audioLevelPercentage;
   }


   public void applyPPToggle()
   {
      PPVolume.enabled = PPtoggle.value;
      dataReference.PostProccessingEnabled = PPtoggle.value;
   }

   public void applyAudioSlider()
   {
      musicPlayer.volume = audioSlider.value;
      dataReference.audioLevelPercentage = audioSlider.value;
   }
}
