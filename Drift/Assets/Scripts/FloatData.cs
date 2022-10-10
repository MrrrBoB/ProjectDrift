using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
   private float num;

   public void SetNum(float val)
   {
      num = val;
   }
   public float GetNum()
   {
      return num;
   }

   public void ChangeNumByValue(float val)
   {
      num += val;
   }
}
