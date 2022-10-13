using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LevelBuilderData : ScriptableObject
{
   public Vector3 buildCoordinates;
   public float currentRotationDegree;
   public Vector3 currentRotationVector;
   private float rotationSum;
   public GameObject[] levelPieces;
   [SerializeField]
   private GameObject nextPieceToBuild;
   [SerializeField]
   private GameObject startPiece;

   public void UpdateRotation(float newRotation)
   {
      rotationSum = currentRotationDegree + newRotation;
      currentRotationDegree += newRotation;
      currentRotationVector = new Vector3(0,currentRotationDegree,0 );
   }

   
   public float GetCurrentLevelRotation()
   {
      return currentRotationDegree;
   }

   
   public void UpdateNextCoordinates(Vector3 receivingCoord)
   {
      buildCoordinates = receivingCoord;
   }

   
   public Vector3 GetNextCoordinates()
   {
      return buildCoordinates;
   }

   public void BuildNextPiece()
   {
      nextPieceToBuild = levelPieces[Random.Range(0, levelPieces.Length)];
      Instantiate(nextPieceToBuild, buildCoordinates, Quaternion.Euler(currentRotationVector));
   }

   public void resetBuilderData()
   {
      currentRotationVector = Vector3.zero;
      currentRotationDegree = 0;
      buildCoordinates = Vector3.zero;
   }

   public void CreateBase()
   {
      resetBuilderData();
      Instantiate(startPiece, Vector3.zero, Quaternion.Euler(Vector3.zero));
   }

}
