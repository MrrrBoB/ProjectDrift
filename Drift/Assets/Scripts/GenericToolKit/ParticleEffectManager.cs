using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectManager : MonoBehaviour
{
   [SerializeField] private ParticleSystem thisParticle;

   public void PlayParticles()
   {
      thisParticle.Play();
   }

   public void StopParticles()
   {
      thisParticle.Stop();
   }
}
