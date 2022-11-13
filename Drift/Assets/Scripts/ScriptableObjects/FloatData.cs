using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
   public float num;
   [SerializeField] private bool newBest;

   public void SetNum(float val)
   {
      num = val;
   }

   public void SetNewBest(bool val)
   {
      newBest = val;
   }
   public bool IsNewBest()
   {
      return newBest;
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
      Debug.Log(dataObj.num);
      if (dataObj.num > num)
      {
         SetNum(dataObj.GetNum());
         newBest = true;
      }
   }

   public void ResetNum()
   {
      SetNum(0);
      newBest = false;
   }

   public void compareHighScore(FloatData HSData)
   {
      if (HSData.GetNum() < num)
      {
         HSData.SetNum(num);
      }
   }
}
