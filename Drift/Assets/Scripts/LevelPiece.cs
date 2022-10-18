using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class LevelPiece : MonoBehaviour
{
    public float levelRotationChange;
    public Vector3 nextLevelCoordinate;
    public GameObject nextPiecePlacer;
    public LevelBuilderData builderData;
    private int lifeCycles = 3;
    public UnityEvent deathEvent;
    public UnityEvent InitializeEvent;
    public GameObject[] listOfTraps;
    private GameObject currentTrap;
    public Vector3 localSpawnCoordinates;

    protected void Start()
    {
        localSpawnCoordinates = new Vector3(0, 1, 0);
        builderData.UpdateNextCoordinates(nextPiecePlacer.transform.position);
        builderData.UpdateRotation(levelRotationChange);
        if (listOfTraps.Length > 0) 
            currentTrap=Instantiate(listOfTraps[Random.Range(0, listOfTraps.Length)], gameObject.transform, true);
        currentTrap.transform.localPosition = localSpawnCoordinates;
    }

    public void PassCycle()
    {
        lifeCycles -= 1;
        if (lifeCycles <= 0)
        {
            deathEvent.Invoke();
            Destroy(gameObject);
        }
    }

    public void Initialize()
    {
        InitializeEvent.Invoke();
    }
}
