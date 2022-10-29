using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerGameAction : MonoBehaviour
{
   [SerializeField]
   private GameAction actionToRaise;
   public string cTag;
   public bool disableOnTrigger;
   private void OnTriggerEnter(Collider other)
   {
      if (cTag == null)
      {
         ExecuteAction();
         return;
      }
      if (other.CompareTag(cTag))
         ExecuteAction();
      
   }

   private void ExecuteAction()
   {
      actionToRaise.RaiseAction();
      if(disableOnTrigger)
         gameObject.SetActive(false);
   }
}
