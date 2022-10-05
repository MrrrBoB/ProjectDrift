using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
 public GameAction gameActionObj;
 public UnityEvent respondEvent;

 public void Start()
 {
     gameActionObj.raise += Respond;
 }

 public void Respond()
 {
   respondEvent.Invoke();
 }
}
