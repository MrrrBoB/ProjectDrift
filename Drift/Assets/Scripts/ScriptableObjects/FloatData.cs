using System.Collections;
using System.Collections.Generic;
using TMPro;
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

   public void CompareValue(float val)
   {
      if (val > num)
      {
         num = val;
      }
   }

   public void CompareValue(FloatData dataObj)
   {
      if (dataObj.GetNum() > num)
      {
         SetNum(dataObj.GetNum());
      }
   }

   public void compareHighScore(FloatData HSData)
   {
      if (HSData.GetNum() < num)
      {
         HSData.SetNum(num);
      }
   }
}
