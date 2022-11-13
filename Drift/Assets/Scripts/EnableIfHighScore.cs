using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableIfHighScore : MonoBehaviour
{
   public FloatData dataObj;
   public GameObject objectToEnable;

   public void checkEnable()
   {
      objectToEnable.SetActive(dataObj.IsNewBest());
   }
}
